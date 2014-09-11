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
    public class PropertyDefinition : NameItemDefinitionBase
    {
        private TypeDefinition _Type;
        private AttributeDefinition[] _Attributes = new AttributeDefinition[] { };
        private Modifier _Modifier = Modifier.Private;
        private string _FieldName;
        private string _GetBody;
        private string _SetBody;

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
        [XmlArrayItem("Attribute",typeof(AttributeDefinition))]
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
        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public virtual string FieldName
        {
            get
            {
                return _FieldName;
            }
            set
            {
                if (value == _FieldName) return;
                _FieldName = value;
                OnPropertyChanged("FieldName");
            }
        }
        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public virtual string GetBody
        {
            get
            {
                return _GetBody;
            }
            set
            {
                if (value == _GetBody) return;
                _GetBody = value;
                OnPropertyChanged("GetBody");
            }
        }
        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public virtual string SetBody
        {
            get
            {
                return _SetBody;
            }
            set
            {
                if (value == _SetBody) return;
                _SetBody = value;
                OnPropertyChanged("SetBody");
            }
        }
        [XmlIgnore]
        public virtual string Signature
        {
            get
            {
                var signature = String.Format("{0} {1} {2}", Modifier.ToXmlName(), Type.FullName, Name).Trim();
                return signature;
            }
        }
        [XmlIgnore]
        public override List<string> UsedNamespaces
        {
            get
            {
                var list = base.UsedNamespaces;
                if (this.Attributes != null)
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
    }
}
