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
    public class MethodDefinition : NameItemDefinitionBase
    {
        private TypeDefinition _ReturnType;
        private ParameterDefinition[] _Parameters=new ParameterDefinition[]{};
        private AttributeDefinition[] _Attributes = new AttributeDefinition[] { };
        private AttributeDefinition[] _InterfaceAttributes = new AttributeDefinition[] { };
        private AttributeDefinition[] _ServiceAttributes = new AttributeDefinition[] { };
        private string _Body;
        private Modifier _Modifier=Modifier.Private;
        private bool _IsPartial;
        private bool _IsStatic;
        private bool _IsAbstract; 
        private bool _IsOverride;

        [XmlElement(typeof(TypeDefinition))]
        public virtual TypeDefinition ReturnType
        {
            get { return _ReturnType != null ? _ReturnType : new TypeDefinition { Name = "void" }; }
            set
            {
                if (value == _ReturnType) return;
                _ReturnType = value;
                OnPropertyChanged("ReturnType");
            }
        }
        [XmlArrayItem("Parameter",IsNullable=false)]
        public virtual ParameterDefinition[] Parameters
        {
            get { return _Parameters; }
            set
            {
                if (value == _Parameters) return;
                _Parameters = value;
                OnPropertyChanged("Parameters");
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
        [XmlArrayItem("InterfaceAttribute", IsNullable = false)]
        public virtual AttributeDefinition[] InterfaceAttributes
        {
            get { return _InterfaceAttributes; }
            set
            {
                if (value == _InterfaceAttributes) return;
                _InterfaceAttributes = value;
                OnPropertyChanged("InterfaceAttributes");
            }
        }
        [XmlArrayItem("ServiceAttribute", IsNullable = false)]
        public virtual AttributeDefinition[] ServiceAttributes
        {
            get { return _ServiceAttributes; }
            set
            {
                if (value == _ServiceAttributes) return;
                _ServiceAttributes = value;
                OnPropertyChanged("ServiceAttributes");
            }
        }
        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public virtual string Body
        {
            get { return _Body; }
            set
            {
                if (value == _Body) return;
                _Body = value;
                OnPropertyChanged("Body");
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
        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public virtual bool IsStatic
        {
            get { return _IsStatic; }
            set
            {
                if (value == _IsStatic) return;
                _IsStatic = value;
                OnPropertyChanged("IsStatic");
            }
        }
        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public virtual bool IsAbstract
        {
            get { return _IsAbstract; }
            set
            {
                if (value == _IsAbstract) return;
                _IsAbstract = value;
                OnPropertyChanged("IsAbstract");
            }
        }
        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public virtual bool IsOverride
        {
            get { return _IsOverride; }
            set
            {
                if (value == _IsOverride) return;
                _IsOverride = value;
                OnPropertyChanged("IsOverride");
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
                if (ReturnType != null)
                    list.AddRange(ReturnType.UsedNamespaces);
                if (Parameters != null && Parameters.Count() > 0)
                    list.AddRange(Parameters.SelectMany(x => x.UsedNamespaces));
                return list.Distinct().OrderBy(x => x).ToList();
            }
        }
        [XmlIgnore]
        public virtual string Signature
        {
            get
            {
                StringBuilder parameters = new StringBuilder();
                foreach (var item in Parameters)
                {
                    if (item != Parameters.First())
                        parameters.Append(", ");
                    parameters.Append(item.ToString());//String.Format("{0} {1} {2}",item.Modifier.ToXmlName(),item.Type.FullName,item.Name).Trim());
                }
                var signature = String.Format
                                (
                                    "{0} {1}{2}{3}{4} {5}({6})", 
                                    Modifier.ToXmlName(), 
                                    IsOverride ? "override " : String.Empty, 
                                    IsStatic ? "static " : String.Empty, 
                                    IsPartial ? "partial " : String.Empty, 
                                    ReturnType.FullName, 
                                    Name, 
                                    parameters.ToString()
                                )
                                .Trim(); 
                return signature;
            }
        }

        public virtual String Serialize()
        {
            try
            {
                String XmlizedString = null;
                MemoryStream memoryStream = new MemoryStream();
                XmlSerializer xs = new XmlSerializer(typeof(MethodDefinition));
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
                XmlSerializer xs = new XmlSerializer(typeof(MethodDefinition));
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

        public static MethodDefinition Deserialize(String xml)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(MethodDefinition));
                MemoryStream memoryStream = new MemoryStream(UTF8Helper.StringToUTF8ByteArray(xml));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                return xs.Deserialize(memoryStream) as MethodDefinition;
            }
            catch
            {
                return null;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(ReturnType);
            sb.Append(" ");
            sb.Append(Name);
            sb.Append("(");
            if (Parameters != null)
                foreach (var item in Parameters)
                {
                    if (item != Parameters.First())
                        sb.Append(", ");
                    sb.Append(item);
                }
            sb.Append(")");
            return sb.ToString();
        }
    }
}
