using System.Net;

namespace Broobu.Hamdroid.Contract.Interfaces
{
    public class HamdroidSentryConst
    {
        public const string Namespace = "http://broobu.com/hamradio/hamdroid/14/01";
        public const string GetCallSingInfoUrl = "http://www.broobu.com/services/business.hamradio/hamdroid/hamdroid.svc/callsign?id={0}&Lat={1}&Lon={2}&unit={3}";
        public const string GetAvatarUrl = "http://www.broobu.com/services/business.hamradio/hamdroid/hamdroid.svc/avatar?url={0}&w={1}&h={2}";
        public const string RegisterDeviceLocationUrl = "http://www.broobu.com/services/business.hamradio/hamdroid/hamdroid.svc/location?id={0}&lat={1}&lon={2}&alt={3}&bea={4}&spe={5}";
    }
}