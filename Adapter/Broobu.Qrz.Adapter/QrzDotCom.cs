using Broobu.Qrz.Contract.Interfaces;

namespace Broobu.Qrz.Adapter
{
    public static class QrzDotCom
    {
        public static IQrzProxy Proxy
        {
            get { return new QrzProxy(); }
        }
    }
}