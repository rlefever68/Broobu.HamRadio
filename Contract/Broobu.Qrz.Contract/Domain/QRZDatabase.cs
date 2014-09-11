using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Broobu.Qrz.Contract.Domain
{
    [DataContract( Name = "QRZDatabase", Namespace = "http://www.qrz.com")]
    [XmlRoot(Namespace = "http://www.qrz.com", ElementName = "QRZDatabase", DataType = "string", IsNullable=true)]
    public class QRZDatabase
    {
        [DataMember(Name = "version")]
        public string version { get; set; }

        [DataMember(Name = "Session")]
        public Session Session { get; set; }

        [DataMember(Name = "Callsign")]
        public CallSign Callsign { get; set; }
    }
}
