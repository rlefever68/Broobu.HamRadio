using System.Runtime.Serialization;

namespace Broobu.Hamdroid.Contract.Domain
{
    [DataContract]
    public class DeviceLocation
    {
        [DataMember]
        public string Device { get; set; }

        [DataMember]
        public double Latitude { get; set; }

        [DataMember]
        public double Longitude { get; set; }

        [DataMember]
        public float Accuracy { get; set; }

        [DataMember]
        public double Altitude { get; set; }

        [DataMember]
        public float Bearing { get; set; }

        [DataMember]
        public float Speed { get; set; }

        [DataMember]
        public long Time { get; set; }

        [DataMember]
        public string DisplayGrid { get; set; }

        [DataMember]
        public string DisplayLongitude { get; set; }

        [DataMember]
        public string DisplayLatitude { get; set; }

        [DataMember]
        public string DisplayBearing { get; set; }

        [DataMember]
        public string DisplaySpeed { get; set; }

        [DataMember]
        public string DisplayAltitude { get; set; }
    }
}