using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Iris.Contract.Generation.Common;
using Iris.Contract.Generation.Templates;

namespace Iris.Contract.Generation.Domain
{
    [Serializable]
    public class InterfaceDefinition : NamespaceItemDefinitionBase
    {
        private TypeDefinition[] _Interfaces = new TypeDefinition[] { };
        private AttributeDefinition[] _Attributes = new AttributeDefinition[] { };
        private MethodDefinition[] _Methods = new MethodDefinition[] { };
        private EventDefinition[] _Events = new EventDefinition[] { };
        private Modifier _Modifier;
        private bool _IsPartial;

        [XmlArrayItem("Type", typeof(TypeDefinition), IsNullable = false)]
        public virtual TypeDefinition[] Interfaces
        {
            get { return _Interfaces; }
            set
            {
                if (value == _Interfaces) return;
                _Interfaces = value;
                OnPropertyChanged("Interfaces");
            }
        }
        [XmlArrayItem("Attribute", typeof(AttributeDefinition), IsNullable = false)]
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
        [XmlArrayItem("Method", typeof(MethodDefinition), IsNullable = false)]
        public virtual MethodDefinition[] Methods
        {
            get
            {
                _Methods.ToList().ForEach(x => x.Modifier = Modifier.None);
                return _Methods;
            }
            set
            {
                if (value == _Methods) return;
                _Methods = value;
                OnPropertyChanged("Methods");
            }
        }
        [XmlArrayItem("Event", typeof(EventDefinition), IsNullable = false)]
        public virtual EventDefinition[] Events
        {
            get
            {
                _Events.ToList().ForEach(x => x.Modifier = Modifier.None);
                return _Events;
            }
            set
            {
                if (value == _Events) return;
                _Events = value;
                OnPropertyChanged("Events");
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
        public virtual bool IsPartial
        {
            get { return _IsPartial; }
            set
            {
                if (value == _IsPartial) return;
                _IsPartial = value;
                OnPropertyChanged("IsPartial");
            }
        }
        [XmlIgnore]
        public virtual string Signature
        {
            get
            {
                StringBuilder interfaces = new StringBuilder();
                foreach (var item in Interfaces)
                {
                    if (item == Interfaces.First())
                        interfaces.AppendFormat(": {0}", item.FullName);
                    else
                        interfaces.AppendFormat(", {0}", item.FullName);
                }
                var signature = String.Format("{0}{1} interface {2}{3}", Modifier.ToXmlName(), IsPartial ? " partial" : String.Empty, Name, interfaces.ToString()).Trim();
                return signature;
            }
        }
        [XmlIgnore]
        public override List<string> UsedNamespaces
        {
            get
            {
                var list = new List<string>();
                if (this._Events != null)
                    list.AddRange(Events.SelectMany(x => x.UsedNamespaces));
                if (Interfaces != null && Interfaces.Count() > 0)
                    list.AddRange(Interfaces.SelectMany(x => x.UsedNamespaces));
                if (Attributes != null && Attributes.Count() > 0)
                    list.AddRange(Attributes.SelectMany(x => x.UsedNamespaces));
                if (Methods != null && Methods.Count() > 0)
                    list.AddRange(Methods.SelectMany(x => x.UsedNamespaces));
                return base.UsedNamespaces.Union(list).Where(x => x != Namespace).Distinct().OrderBy(x => x).ToList();
            }
        }

        public virtual String Serialize()
        {
            try
            {
                String XmlizedString = null;
                MemoryStream memoryStream = new MemoryStream();
                XmlSerializer xs = new XmlSerializer(typeof(InterfaceDefinition));
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
                XmlSerializer xs = new XmlSerializer(typeof(InterfaceDefinition));
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

        public static InterfaceDefinition Deserialize(String xml)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(InterfaceDefinition));
                MemoryStream memoryStream = new MemoryStream(UTF8Helper.StringToUTF8ByteArray(xml));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                return xs.Deserialize(memoryStream) as InterfaceDefinition;
            }
            catch
            {
                return null;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("interface ");
            sb.Append(Name);
            foreach (var item in Interfaces)
            {
                if (item == Interfaces.First())
                    sb.Append(": ");
                else
                    sb.Append(", ");
                sb.Append(item.FullName);
            }
            return sb.ToString();
        }

        public virtual string GenerateCode()
        {
            InterfaceTemplate t = new InterfaceTemplate();
            t.Interface = this;
            return t.TransformText();
        }
    }
}
