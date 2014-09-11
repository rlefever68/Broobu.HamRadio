using System.ServiceModel;

namespace Broobu.Qrz.Contract.Interfaces
{
    [ServiceContract(Namespace = QrzConst.ServiceNamespace)]
    public interface IQrzProxyAgent : IQrzProxy
    {
    }
}