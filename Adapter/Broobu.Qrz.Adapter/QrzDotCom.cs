using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
