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
    public class DomainObjectClassDefinition : ClassDefinition
    {
        [XmlIgnore]
        public override List<string> UsedNamespaces
        {
            get
            {
                var list = new List<string>();
                list.Add("Iris.Fx.Validation");
                foreach (var item in Properties)
                {
                    list.AddRange(item.Type.UsedNamespaces);
                }
                return base.UsedNamespaces.Union(list).Distinct().OrderBy(x => x).Where(x=>x!=this.Namespace).ToList();
            }
        }

        public override String Serialize()
        {
            try
            {
                String XmlizedString = null;
                MemoryStream memoryStream = new MemoryStream();
                XmlSerializer xs = new XmlSerializer(typeof(DomainObjectClassDefinition));
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
                XmlSerializer xs = new XmlSerializer(typeof(DomainObjectClassDefinition));
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

        public static new DomainObjectClassDefinition Deserialize(String xml)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(DomainObjectClassDefinition));
                MemoryStream memoryStream = new MemoryStream(UTF8Helper.StringToUTF8ByteArray(xml));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                return xs.Deserialize(memoryStream) as DomainObjectClassDefinition;
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
            return sb.ToString();
        }
    }
}
