using System;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;
using Broobu.Hamdroid.Contract.Domain;

namespace Broobu.Hamdroid.Contract.Interfaces
{
    [ServiceKnownType(typeof(CallSignInfo))]
    [ServiceContract(Namespace = HamdroidSentryConst.Namespace)]
    public interface IHamdroid
    {
        [OperationContract]
        [WebGet(UriTemplate = "CallSign?id={id}&Lat={clientLat}&Lon={clientLon}&unit={unit}", ResponseFormat = WebMessageFormat.Json)]
        CallSignInfo GetCallSignInfo(string id, double clientLat,double clientLon, string unit);


        [OperationContract]
        [WebGet(UriTemplate = "avatar?url={url}&w={width}&h={height}", ResponseFormat = WebMessageFormat.Json)]
        string GetAvatar(string url, int width, int height);


        [OperationContract]
        [WebGet(UriTemplate = "location?id={device}&lat={latitude}&lon={longitude}&alt={altitude}&bea={bearing}&spe={speed}",
            ResponseFormat = WebMessageFormat.Json)]
        DeviceLocation RegisterDeviceLocation(string device, double latitude, double longitude, double altitude, float bearing, float speed);

    }
}
