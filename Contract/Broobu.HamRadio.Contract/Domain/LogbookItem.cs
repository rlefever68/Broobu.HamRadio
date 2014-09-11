using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Iris.Fx.Domain;
using Iris.Fx.Validation;

namespace Broobu.HamRadio.Contract.Domain
{
    [DataContract]
    public class LogbookItem : DomainObject<LogbookItem>
    {

        [DataMember]
        public string MyCallId { get; set; }
        [DataMember]
        public string MyCallModifier { get; set; }
        [DataMember]
        public DateTime Started { get;set; }
        [DataMember]
        public DateTime Ended { get; set; }
        [DataMember]
        public string WorkedStationId { get; set; }
        [DataMember]
        public string WorkedStationIdModifier { get; set; }
        [DataMember]
        public string Band { get; set; }
        [DataMember]
        public double Frequency { get; set; }
        [DataMember]
        public string Modulation { get; set; }
        [DataMember]
        public string RxReport { get; set; }
        [DataMember]
        public string TxReport { get; set; }
        [DataMember]
        public string ExtraInfo { get; set; }


        protected override string Validate(string columnName)
        {
            return DataErrorInfoValidator<LogbookItem>.Validate(this, columnName);
        }

        protected override ICollection<string> Validate()
        {
            return DataErrorInfoValidator<LogbookItem>.Validate(this);
        }
    }
}
