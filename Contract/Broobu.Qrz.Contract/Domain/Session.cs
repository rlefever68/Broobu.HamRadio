using System.Runtime.Serialization;

namespace Broobu.Qrz.Contract.Domain
{
    [DataContract(Namespace = "http://www.qrz.com")]
    public class Session
    {
        [DataMember]
        public string Error { get; set; }

        [DataMember]
        public string Key { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string GMTTime { get; set; }

        [DataMember]
        public string Count { get; set; }

        [DataMember]
        public string Subexp { get; set; }

        [DataMember]
        public string Remark { get; set; }
    }
}