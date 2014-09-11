using System.ServiceModel;

namespace Broobu.HamRadio.Contract.Interfaces
{
    [ServiceContract(Namespace = HamRadioConst.ServiceNamespace)]
    public interface IHamRadioAgent : IHamRadio
    {
    }
}