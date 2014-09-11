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
    public class ClassDefinition : NamespaceItemDefinitionBase
    {
        private AttributeDefinition[] _Attributes = new AttributeDefinition[] { };
        private TypeDefinition _BaseClass;
        private EventDefinition[] _Events = new EventDefinition[] { };
        private FieldDefinition[] _Fields = new FieldDefinition[] { };
        private TypeDefinition[] _Interfaces = new TypeDefinition[] { };
        private bool _IsPartial;
        private MethodDefinition[] _Methods = new MethodDefinition[] { };
        private Modifier _Modifier = Modifier.Internal;
        private PropertyDefinition[] _Properties = new PropertyDefinition[] { };
        private ConstructorDefinition[] _constructors = new ConstructorDefinition[] { };

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
        [XmlElement(typeof(TypeDefinition))]
        public virtual TypeDefinition BaseClass
        {
            get { return _BaseClass; }
            set
            {
                if (value == _BaseClass) return;
                _BaseClass = value;
                OnPropertyChanged("BaseClass");
            }
        }
        [XmlArrayItem("Event", typeof(EventDefinition), IsNullable = false)]
        public virtual EventDefinition[] Events
        {
            get { return _Events; }
            set
            {
                if (value == _Events) return;
                _Events = value;
                OnPropertyChanged("Events");
            }
        }
        [XmlArrayItem("Field", typeof(FieldDefinition), IsNullable = false)]
        public virtual FieldDefinition[] Fields
        {
            get
            {
                return _Fields;
            }
            set
            {
                if (value == _Fields) return;
                _Fields = value;
                OnPropertyChanged("Fields");
            }
        }
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
        [XmlArrayItem("Constructor", typeof(ConstructorDefinition), IsNullable = false)]
        public virtual ConstructorDefinition[] Constructors
        {
            get { return _constructors; }
            set
            {
                if (ReferenceEquals(value, _constructors)) return;
                _constructors = value;
                OnPropertyChanged("Constructors");
            }
        }
        [XmlArrayItem("Method", typeof(MethodDefinition), IsNullable = false)]
        public virtual MethodDefinition[] Methods
        {
            get { return _Methods; }
            set
            {
                if (ReferenceEquals(value, _Methods)) return;
                _Methods = value;
                OnPropertyChanged("Methods");
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
        [XmlArrayItem("Property", typeof(PropertyDefinition), IsNullable = false)]
        public virtual PropertyDefinition[] Properties
        {
            get
            {
                return _Properties;
            }
            set
            {
                if (value == _Properties) return;
                _Properties = value;
                var prefix = "_";
                foreach (var item in _Properties.Where(x => String.IsNullOrWhiteSpace(x.FieldName)))
                    item.FieldName = String.Format("{0}{1}{2}",prefix,item.Name.Substring(0,1).ToLower(),item.Name.Substring(1));
                while (_Properties.Any(x => Fields.Select(y => y.Name).Contains(x.FieldName)))
                {
                    foreach (var item in _Properties.Where(x => Fields.Select(y => y.Name).Contains(x.FieldName)))
                    {
                        item.FieldName = item.FieldName.Insert(0, prefix);
                    }
                }
                OnPropertyChanged("Properties");
            }
        }
        [XmlIgnore]
        public virtual string Signature
        {
            get
            {
                StringBuilder interfaces = new StringBuilder();
                if (BaseClass != null)
                    interfaces.AppendFormat(": {0}", BaseClass.FullName);
                foreach (var item in Interfaces)
                {
                    if (BaseClass == null && item == Interfaces.First())
                        interfaces.AppendFormat(": {0}", item.FullName);
                    else
                        interfaces.AppendFormat(", {0}", item.FullName);
                }
                var signature = String.Format("{0}{1} class {2}{3}", Modifier.ToXmlName(), IsPartial ? " partial" : String.Empty, Name, interfaces.ToString()).Trim();
                return signature;
            }
        }
        [XmlIgnore]
        public override List<string> UsedNamespaces
        {
            get
            {
                var list = new List<string>();
                if (Attributes != null)
                    list.AddRange(Attributes.SelectMany(x => x.UsedNamespaces));
                if (BaseClass != null)
                    list.AddRange(BaseClass.UsedNamespaces);
                if (Events != null)
                    list.AddRange(Events.SelectMany(x => x.UsedNamespaces));
                if (Fields != null)
                    list.AddRange(Fields.SelectMany(x => x.UsedNamespaces));
                if (Interfaces != null)
                    list.AddRange(Interfaces.SelectMany(x => x.UsedNamespaces));
                if (Methods != null)
                    list.AddRange(Methods.SelectMany(x => x.UsedNamespaces));
                if (Properties != null)
                    list.AddRange(Properties.SelectMany(x => x.UsedNamespaces));
                return base.UsedNamespaces.Union(list).Where(x => x != Namespace).Distinct().OrderBy(x => x).ToList();
            }
        }

        public virtual String Serialize()
        {
            try
            {
                String XmlizedString = null;
                MemoryStream memoryStream = new MemoryStream();
                XmlSerializer xs = new XmlSerializer(typeof(ClassDefinition));
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
                XmlSerializer xs = new XmlSerializer(typeof(ClassDefinition));
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

        public static ClassDefinition Deserialize(String xml)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(ClassDefinition));
                MemoryStream memoryStream = new MemoryStream(UTF8Helper.StringToUTF8ByteArray(xml));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                return xs.Deserialize(memoryStream) as ClassDefinition;
            }
            catch
            {
                return null;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Name);
            sb.AppendLine(" ( class )");
            if (BaseClass != null)
            {
                sb.AppendFormat("Inherits:   {0}", BaseClass.FullName);
                sb.AppendLine();
            }
            if (Interfaces != null && Interfaces.Count() > 0)
            {
                sb.Append("Implements: ");
                foreach (var item in Interfaces)
                {

                    if (item != Interfaces.First())
                        sb.Append("            ");
                    sb.AppendLine(item.FullName);
                }
            }
            if (Events != null && Events.Count() > 0)
            {
                sb.Append("Events:     ");
                foreach (var item in Events)
                {

                    if (item != Events.First())
                        sb.Append("            ");
                    sb.AppendLine(item.ToString());
                }
            }
            if (Properties != null && Properties.Count() > 0)
            {
                sb.Append("Properties: ");
                foreach (var item in Properties)
                {

                    if (item != Properties.First())
                        sb.Append("            ");
                    sb.AppendLine(item.ToString());
                }
            }
            if (Methods != null && Methods.Count() > 0)
            {
                sb.Append("Methods:    ");
                foreach (var item in Methods)
                {

                    if (item != Methods.First())
                        sb.Append("            ");
                    sb.AppendLine(item.ToString());
                }
            }
            return sb.ToString();
        }

        public string GenerateCode()
        {
            ClassTemplate t = new ClassTemplate();
            t.Class = this;
            return t.TransformText();
        }
    }
}
