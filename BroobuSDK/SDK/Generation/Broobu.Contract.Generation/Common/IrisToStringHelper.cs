using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iris.Contract.Generation.Common
{
    public class IrisToStringHelper
    {
        public string ToStringWithCulture(object convertToCulture)
        {
            return Microsoft.VisualStudio.TextTemplating.ToStringHelper.ToStringWithCulture(convertToCulture);
        }
    }
}
