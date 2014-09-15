using System.Collections.Generic;
using System.Runtime.Serialization;
using Wulka.Domain.Base;
using Wulka.Validation;

namespace Broobu.HamRadio.Contract.Domain
{
    [DataContract]
    public class StationItem : DomainObject<StationItem>
    {
        [DataMember]
        public string CallId { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Address1 { get; set; }

        [DataMember]
        public string Address2 { get; set; }

        [DataMember]
        public string State { get; set; }

        [DataMember]
        public string Zip { get; set; }

        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public string Latitude { get; set; }

        [DataMember]
        public string Longitude { get; set; }

        [DataMember]
        public string Grid { get; set; }

        [DataMember]
        public string County { get; set; }

        [DataMember]
        public string Land { get; set; }

        [DataMember]
        public string EfDate { get; set; }

        [DataMember]
        public string ExpDate { get; set; }

        [DataMember]
        public string PCall { get; set; }

        [DataMember]
        public string Born { get; set; }

        [DataMember]
        public string Trustee { get; set; }

        [DataMember]
        public string Class { get; set; }

        [DataMember]
        public string Codes { get; set; }

        [DataMember]
        public string QslManager { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Url { get; set; }

        [DataMember]
        public string UViews { get; set; }

        [DataMember]
        public string Bio { get; set; }

        [DataMember]
        public string ImageUrl { get; set; }

        [DataMember]
        public string ModDate { get; set; }

        [DataMember]
        public string AreaCode { get; set; }

        [DataMember]
        public string TimeZone { get; set; }

        [DataMember]
        public string GmtOffset { get; set; }

        [DataMember]
        public string DST { get; set; }

        [DataMember]
        public string EQsl { get; set; }

        [DataMember]
        public string MQsl { get; set; }

        [DataMember]
        public string CqZone { get; set; }

        [DataMember]
        public string ItuZone { get; set; }

        [DataMember]
        public string LocRef { get; set; }

        [DataMember]
        public string Iota { get; set; }

        [DataMember]
        public string Lotw { get; set; }

        [DataMember]
        public string User { get; set; }

        [DataMember]
        public string Fips { get; set; }

        [DataMember]
        public string Msa { get; set; }

        [DataMember]
        public byte[] Avatar { get; set; }

        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<StationItem>.Validate(this, columnName);
        }

        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<StationItem>.Validate(this);
        }
    }
}