using Broobu.Qrz.Contract.Agent;
using Broobu.Qrz.Contract.Interfaces;

namespace Broobu.Qrz.Contract
{
    public class QrzDotComPortal
    {
        public static IQrzProxyAgent Proxy
        {
            get 
            {
                return new QrzProxyAgent();
            }
        }
    }
}
