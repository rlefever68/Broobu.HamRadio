using System.Runtime.Serialization;

namespace Broobu.Qrz.Contract.Domain
{
    [DataContract(Namespace = "http://www.qrz.com")]
    public class CallSign
    {
        [DataMember]
        public string call { get; set; }

        [DataMember]
        public string fname { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string addr1 { get; set; }

        [DataMember]
        public string addr2 { get; set; }


        [DataMember]
        public string state { get; set; }

        [DataMember]
        public string zip { get; set; }

        [DataMember]
        public string country { get; set; }

        [DataMember]
        public string lat { get; set; }

        [DataMember]
        public string lon { get; set; }

        [DataMember]
        public string grid { get; set; }

        [DataMember]
        public string county { get; set; }

        [DataMember]
        public string land { get; set; }

        [DataMember]
        public string efdate { get; set; }


        [DataMember]
        public string expdate { get; set; }


        [DataMember]
        public string p_call { get; set; }


        [DataMember]
        public string born { get; set; }

        [DataMember]
        public string trustee { get; set; }

        [DataMember]
        public string Class { get; set; }

        [DataMember]
        public string codes { get; set; }

        [DataMember]
        public string qslmgr { get; set; }

        [DataMember]
        public string email { get; set; }

        [DataMember]
        public string url { get; set; }

        [DataMember]
        public string u_views { get; set; }

        [DataMember]
        public string bio { get; set; }

        [DataMember]
        public string image { get; set; }


        [DataMember]
        public string moddate { get; set; }

        [DataMember]
        public string AreaCode { get; set; }

        [DataMember]
        public string TimeZone { get; set; }

        [DataMember]
        public string GMTOffset { get; set; }

        [DataMember]
        public string DST { get; set; }

        [DataMember]
        public string eqsl { get; set; }

        [DataMember]
        public string mqsl { get; set; }

        [DataMember]
        public string cqzone { get; set; }

        [DataMember]
        public string ituzone { get; set; }

        [DataMember]
        public string locref { get; set; }

        [DataMember]
        public string iota { get; set; }

        [DataMember]
        public string lotw { get; set; }

        [DataMember]
        public string user { get; set; }


        [DataMember]
        public string fips { get; set; }

        [DataMember]
        public string MSA { get; set; }
    }
}