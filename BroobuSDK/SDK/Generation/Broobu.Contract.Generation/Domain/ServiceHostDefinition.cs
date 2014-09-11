using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Iris.Contract.Generation.Common;
using Iris.Contract.Generation.Templates;

namespace Iris.Contract.Generation.Domain
{
    [Serializable]
    public class ServiceHostDefinition : NamespaceItemDefinitionBase
    {
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
            sb.Append("service host ");
            sb.Append(Name);
            return sb.ToString();
        }

        public virtual string GenerateCode()
        {
            ServiceHostTemplate t = new ServiceHostTemplate();
            t.ServiceHostDefinition = this;
            return t.TransformText();
        }
    }
}
