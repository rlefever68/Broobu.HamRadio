using System;
using System.Runtime.Serialization;

namespace Broobu.Hamdroid.Contract.Domain
{
    [DataContract]
    public class CallSignInfo
    {
        [DataMember]
        public string CallSign;
        [DataMember]
        public string DisplayName;
        [DataMember]
        public string DisplayLocation;
        [DataMember]
        public double Longitude;
        [DataMember]
        public double Latitude;
        [DataMember]
        public string DisplayLongitude;
        [DataMember]
        public string DisplayLatitude;
        [DataMember]
        public string Grid;
        [DataMember]
        public string BioUrl;
        [DataMember]
        public string ImageUrl;
        [DataMember]
        public string Bearing;
        [DataMember]
        public string LongPath;
        [DataMember]
        public string ShortPath;
        [DataMember]
        public string YourDisplayLongitude;
        [DataMember]
        public string YourDisplayLatitude;
        [DataMember]
        public string YourGrid;
    }
}
