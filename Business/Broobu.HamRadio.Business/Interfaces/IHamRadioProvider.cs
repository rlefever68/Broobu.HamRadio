using Broobu.HamRadio.Contract.Interfaces;

namespace Broobu.HamRadio.Business.Interfaces
{
    public interface IHamRadioProvider : IHamRadio
    {
        void InflateDomain();
    }
}