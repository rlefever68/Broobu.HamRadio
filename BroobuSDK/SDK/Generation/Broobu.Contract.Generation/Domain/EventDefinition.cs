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
    public class EventDefinition : NameItemDefinitionBase
    {
        private TypeDefinition _ActionTemplate;
        private AttributeDefinition[] _Attributes = new AttributeDefinition[] { };
        private Modifier _Modifier = Modifier.Private;

        [XmlIgnore]
        public virtual TypeDefinition Type
        {
            get 
            { 
                return new TypeDefinition 
                       { 
                           Namespace = "System", 
                           Name = "Action", 
                           Template = ActionTemplate, 
                           IsEnum = false, 
                           IsStruct = false
                       };
            }
        }
        [XmlElement(typeof(TypeDefinition))]
        public virtual TypeDefinition ActionTemplate
        {
            get { return _ActionTemplate; }
            set
            {
                if (value == _ActionTemplate) return;
                _ActionTemplate = value;
                OnPropertyChanged("ActionTemplate");
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
        [XmlIgnore]
        public virtual string Signature
        {
            get
            {
                var signature = String.Format("{0} event {1} {2}", Modifier.ToXmlName(),Type.FullName, Name).Trim();
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
                if (this.ActionTemplate != null)
                    list.AddRange(ActionTemplate.UsedNamespaces);
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
                XmlSerializer xs = new XmlSerializer(typeof(EventDefinition));
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
                XmlSerializer xs = new XmlSerializer(typeof(EventDefinition));
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

        public static EventDefinition Deserialize(String xml)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(EventDefinition));
                MemoryStream memoryStream = new MemoryStream(UTF8Helper.StringToUTF8ByteArray(xml));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                return xs.Deserialize(memoryStream) as EventDefinition;
            }
            catch
            {
                return null;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("event ");
            sb.Append(Type);
            sb.Append(" ");
            sb.Append(Name);
            return sb.ToString();
        }
    }
}
