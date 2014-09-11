using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Iris.Contract.Generation.Common;

namespace Iris.Contract.Generation.Domain
{
    [Serializable]
    public partial class ContractServiceDefinition : InterfaceDefinition
    {
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ServiceContractNamespace { get; set; }

        [XmlArrayItem("Attribute", IsNullable = false)]
        public override AttributeDefinition[] Attributes
        {
            get
            {
                return base.Attributes;
            }
            set
            {
                if (ReferenceEquals(base.Attributes, value) != true)
                    base.Attributes = value;
            }
        }
        //[XmlArrayItem("ServiceInterfaceMethod",  , IsNullable = false)]
        [XmlArrayItem("Method", Type = typeof(MethodDefinition[]))]
        public override MethodDefinition[] Methods
        {
            get
            {
                return base.Methods;
            }
            set
            {
                if (ReferenceEquals(base.Methods, value) != true)
                    base.Methods = value;

            }
        }

        public override String Serialize()
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

        public static new String Serialize(object obj)
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

        public static new InterfaceDefinition Deserialize(String xml)
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
    }
}
