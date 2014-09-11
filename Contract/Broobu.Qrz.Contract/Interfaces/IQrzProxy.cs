using System;
using System.ServiceModel;
using Broobu.Qrz.Contract.Domain;


namespace Broobu.Qrz.Contract.Interfaces
{
    [ServiceKnownType(typeof(QRZDatabase))]
    [ServiceKnownType(typeof(CallSign))]
    [ServiceKnownType(typeof(Session))]
    [ServiceContract(Namespace = QrzConst.ServiceNamespace)]
    public interface IQrzProxy
    {
        [OperationContract]
        Session DoLogin();

        [OperationContract]
        CallSign GetCallSign(string callSign);
    }


}