using Broobu.SweNet.Adapter.SweNet;
using Broobu.SweNet.Adapter.Worker;

namespace Broobu.SweNet.Adapter
{
    public static class SweNetAdapter
    {
        public static ISwenetDataProviderPortType Proxy {
            get { 
                return new SweNetProxy();
            }
        }
    }
}
