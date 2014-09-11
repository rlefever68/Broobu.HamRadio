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
    public class ConstructorDefinition : NameItemDefinitionBase
    {
        private ParameterDefinition[] _parameters=new ParameterDefinition[]{};
        private AttributeDefinition[] _attributes = new AttributeDefinition[] { };
        private string _body;
        private Modifier _modifier=Modifier.Private;
        private bool _isStatic;
        private CalledConstructorDefinition _calledConstructor;
        
        [XmlArrayItem("Parameter", IsNullable = false)]
        public virtual ParameterDefinition[] Parameters
        {
            get { return _parameters; }
            set
            {
                if (value == _parameters) return;
                _parameters = value;
                OnPropertyChanged("Parameters");
            }
        }
        [XmlArrayItem("Attribute", IsNullable = false)]
        public virtual AttributeDefinition[] Attributes
        {
            get { return _attributes; }
            set
            {
                if (value == _attributes) return;
                _attributes = value;
                OnPropertyChanged("Attributes");
            }
        }
        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public virtual string Body
        {
            get { return _body; }
            set
            {
                if (value == _body) return;
                _body = value;
                OnPropertyChanged("Body");
            }
        }
        [XmlElement(typeof(Modifier))]
        public virtual Modifier Modifier
        {
            get { return _modifier; }
            set
            {
                if (value == _modifier) return;
                _modifier = value;
                OnPropertyChanged("Modifier");
            }
        }
        [XmlElement(typeof(CalledConstructorDefinition))]
        public virtual CalledConstructorDefinition CalledConstructor
        {
            get { return _calledConstructor; }
            set
            {
                if (ReferenceEquals(_calledConstructor,value)) return;
                _calledConstructor = value;
                OnPropertyChanged("CalledConstructor");
            }
        }
        [XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
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
        [XmlIgnore]
        public override List<string> UsedNamespaces
        {
            get
            {
                var list = base.UsedNamespaces;
                if (this.Attributes != null)
                    list.AddRange(Attributes.SelectMany(x => x.UsedNamespaces)); 
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
                                    "{0} {1}{2}({3}){4}", 
                                    Modifier.ToXmlName(), 
                                    IsStatic ? "static " : String.Empty,                                     
                                    Name, 
                                    parameters.ToString(),
                                    CalledConstructor!=null? String.Format(": {0}",CalledConstructor): string.Empty
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
                XmlSerializer xs = new XmlSerializer(typeof(ConstructorDefinition));
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

        public static ConstructorDefinition Deserialize(String xml)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(MethodDefinition));
                MemoryStream memoryStream = new MemoryStream(UTF8Helper.StringToUTF8ByteArray(xml));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                return xs.Deserialize(memoryStream) as ConstructorDefinition;
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
