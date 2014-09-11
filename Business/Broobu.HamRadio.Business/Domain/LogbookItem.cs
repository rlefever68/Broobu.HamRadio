using System.Collections.Generic;
using System.Runtime.Serialization;
using Iris.Fx.Domain;
using Iris.Fx.Validation;

namespace Broobu.HamRadio.Business.Domain
{
    [DataContract]
    public class LogbookItem : DomainObject<LogbookItem>
    {

        
        [DataMember]
        public string CallId { get; set; }

        public DateTime Started
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public DateTime Ended
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public string StationId
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }


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
