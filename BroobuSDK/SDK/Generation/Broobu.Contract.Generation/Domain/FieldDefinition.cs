using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Iris.Contract.Generation.Common;

namespace Iris.Contract.Generation.Domain
{
    [Serializable]
    public class FieldDefinition : NameItemDefinitionBase
    {
        private TypeDefinition _Type;
        private AttributeDefinition[] _Attributes = new AttributeDefinition[] { };
        private Modifier _Modifier = Modifier.Private;
        private bool _isReadOnly;
        private bool _isStatic;
        private PropertyDefinition _LinkedProperty;
        private string _initialValueString;

        [XmlElement(typeof(TypeDefinition))]
        public virtual TypeDefinition Type
        {
            get { return _Type; }
            set
            {
                if (value == _Type) return;
                _Type = value;
                OnPropertyChanged("Type");
            }
        }
        [XmlArrayItem("Attribute", IsNullable = false)]
        public virtual AttributeDefinition[] Attributes
        {
            get { return _Attributes; }
            set
            {
                if (value == _Attributes) return;
                _Attributes = value;
                OnPropertyChanged("Attributes");
            }
        }
        [XmlElement(typeof(Modifier))]
        public virtual Modifier Modifier
        {
            get { return _Modifier; }
            set
            {
                if (value == _Modifier) return;
                _Modifier = value;
                OnPropertyChanged("Modifier");
            }
        }
        [XmlElement(typeof(bool))]
        public virtual bool IsReadOnly
        {
            get { return _isReadOnly; }
            set
            {
                if (value == _isReadOnly) return;
                _isReadOnly = value;
                OnPropertyChanged("IsReadOnly");
            }
        }
        [XmlElement(typeof(bool))]
        public virtual bool IsStatic
        {
            get { return _isStatic; }
            set
            {
                if (value == _isStatic) return;
                _isStatic = value;
                OnPropertyChanged("IsStatic");
            }
        }
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public virtual String InitialValueString
        {
            get { return _initialValueString; }
            set
            {
                if (value == _initialValueString) return;
                _initialValueString = value;
                OnPropertyChanged("InitialValueString");
            }
        }
        [XmlIgnore]
        public virtual PropertyDefinition LinkedProperty
        {
            get { return _LinkedProperty; }
            set
            {
                if (value == _LinkedProperty) return;
                _LinkedProperty = value;
                OnPropertyChanged("Modifier");
            }
        }
        [XmlIgnore]
        public virtual string Signature
        {
            get
            {
                var signature = String.Format("{0} {1}{2}{3} {4}{5}",
                                                Modifier.ToXmlName(),
                                                IsStatic ? "static " : string.Empty,
                                                IsReadOnly ? "readonly " : string.Empty,
                                                Type.FullName,
                                                Name,
                                                String.IsNullOrWhiteSpace(InitialValueString) ? string.Empty : String.Format(" = {0}",InitialValueString)).Trim();
                return signature;
            }
        }
        [XmlIgnore]
        public override List<string> UsedNamespaces
        {
            get
            {
                var list = base.UsedNamespaces;
                if (Attributes != null)
                    list.AddRange(Attributes.SelectMany(x => x.UsedNamespaces));
                if (Type != null)
                    list.AddRange(Type.UsedNamespaces);
                return list.Distinct().OrderBy(x => x).ToList();
            }
        }

        public virtual String Serialize()
        {
            try
            {
                String XmlizedString = null;
                MemoryStream memoryStream = new MemoryStream();
                XmlSerializer xs = new XmlSerializer(typeof(PropertyDefinition));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

                xs.Serialize(xmlTextWriter, this);
                memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                XmlizedString = UTF8Helper.UTF8ByteArrayToString(memoryStream.ToArray());
                return XmlizedString;
            }
            catch
            {
                return String.Empty;
            }
        }

        public static String Serialize(object obj)
        {
            try
            {
                String XmlizedString = null;
                MemoryStream memoryStream = new MemoryStream();
                XmlSerializer xs = new XmlSerializer(typeof(PropertyDefinition));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

                xs.Serialize(xmlTextWriter, obj);
                memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                XmlizedString = UTF8Helper.UTF8ByteArrayToString(memoryStream.ToArray());
                return XmlizedString;
            }
            catch
            {
                return String.Empty;
            }
        }

        public static PropertyDefinition Deserialize(String xml)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(PropertyDefinition));
                MemoryStream memoryStream = new MemoryStream(UTF8Helper.StringToUTF8ByteArray(xml));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                return xs.Deserialize(memoryStream) as PropertyDefinition;
            }
            catch
            {
                return null;
            }
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", Type, Name);
        }

        public static implicit operator FieldDefinition(PropertyDefinition property)
        {
            if (property == null || System.String.IsNullOrWhiteSpace(property.FieldName))
                return null;

            var field = new FieldDefinition
            {
                Name = property.FieldName,
                Modifier = Modifier.Private,
                Type = property.Type,
                LinkedProperty = property,
                Attributes = new AttributeDefinition[] { }
            };
            return field;
        }

    }
}
