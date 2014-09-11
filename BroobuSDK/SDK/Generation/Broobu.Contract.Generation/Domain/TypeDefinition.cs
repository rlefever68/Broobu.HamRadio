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
    public class TypeDefinition : NamespaceItemDefinitionBase
    {
        private TypeDefinition _Template;
        private bool _IsEnum;
        private bool _IsStruct;

        [XmlElement(typeof(TypeDefinition))]
        public virtual TypeDefinition Template
        {
            get { return _Template; }
            set
            {
                if (value == _Template) return;
                _Template = value;
                OnPropertyChanged("Template");
            }
        }
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public virtual bool IsEnum
        {
            get { return _IsEnum; }
            set
            {
                if (value == _IsEnum) return;
                _IsEnum = value;
                OnPropertyChanged("IsEnum");
            }
        }
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public virtual bool IsStruct
        {
            get { return _IsStruct; }
            set
            {
                if (value == _IsStruct) return;
                _IsStruct = value;
                OnPropertyChanged("IsStruct");
            }
        }
        [XmlIgnore]
        public virtual bool IsValueType
        {
            get
            {
                if (IsStruct || IsEnum)
                    return true;
                else
                    if (!String.IsNullOrWhiteSpace(Namespace) && Namespace.ToLower() == "system")
                    {
                        switch (Name.ToLower())
                        {
                            case "sbyte":
                            case "byte":
                            case "char":
                            case "short":
                            case "ushort":
                            case "int":
                            case "int16":
                            case "int32":
                            case "int64":
                            case "uint16":
                            case "uint32":
                            case "uint64":
                            case "intptr":
                            case "uintptr":
                            case "uint":
                            case "long":
                            case "ulong":
                            case "bool":
                            case "single":
                            case "double":
                            case "decimal":
                                return true;
                        }
                    }

                return false;
            }
        }
        [XmlIgnore]
        public virtual string FullName
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(Name);
                if (Template != null && Template.Name != "void")
                    sb.AppendFormat("<{0}>", Template.FullName);
                return sb.ToString();
            }
        }
        [XmlIgnore]
        public override List<string> UsedNamespaces
        {
            get
            {
                var list = base.UsedNamespaces;
                if (Template != null)
                    list.AddRange(Template.UsedNamespaces);
                return list.Distinct().OrderBy(x => x).ToList();
            }
        }

        public virtual String Serialize()
        {
            try
            {
                String XmlizedString = null;
                MemoryStream memoryStream = new MemoryStream();
                XmlSerializer xs = new XmlSerializer(typeof(TypeDefinition));
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
                XmlSerializer xs = new XmlSerializer(typeof(TypeDefinition));
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

        public static TypeDefinition Deserialize(String xml)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(TypeDefinition));
                MemoryStream memoryStream = new MemoryStream(UTF8Helper.StringToUTF8ByteArray(xml));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                return xs.Deserialize(memoryStream) as TypeDefinition;
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
            if (Template != null)
                sb.AppendFormat("<{0}>", Template.ToString());
            return sb.ToString();
        }
    }
}
