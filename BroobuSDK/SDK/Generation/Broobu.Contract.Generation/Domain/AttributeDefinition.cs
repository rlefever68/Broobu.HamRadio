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
    public class AttributeDefinition: NameItemDefinitionBase
    {
        private TypeDefinition _Type;
        private string _Value;

        [XmlElement("Type")]
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
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public virtual string Value
        {
            get { return _Value; }
            set
            {
                if (value == _Value) return;
                _Value = value;
                OnPropertyChanged("Value");
            }
        }
        [XmlIgnore]
        public override List<string> UsedNamespaces
        {
            get
            {
                var list = base.UsedNamespaces;
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
                XmlSerializer xs = new XmlSerializer(typeof(AttributeDefinition));
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
                XmlSerializer xs = new XmlSerializer(typeof(AttributeDefinition));
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

        public static AttributeDefinition Deserialize(String xml)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(AttributeDefinition));
                MemoryStream memoryStream = new MemoryStream(UTF8Helper.StringToUTF8ByteArray(xml));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                return xs.Deserialize(memoryStream) as AttributeDefinition;
            }
            catch
            {
                return null;
            }
        }

        public override string ToString()
        {
            return String.Format("[{0}{1}]", Name, Value!=null?String.Format("({0})",Value):String.Empty);
        }

    }
}
