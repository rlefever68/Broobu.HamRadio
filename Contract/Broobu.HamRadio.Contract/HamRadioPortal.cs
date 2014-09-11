using Broobu.HamRadio.Contract.Agent;
using Broobu.HamRadio.Contract.Interfaces;

namespace Broobu.HamRadio.Contract
{
    public class HamRadioPortal
    {
        public static IHamRadioAgent Agent
        {
            get 
            {
                return new HamRadioAgent();
            }
        }
    }
}
