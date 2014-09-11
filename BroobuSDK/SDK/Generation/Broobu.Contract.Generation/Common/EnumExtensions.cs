using System;
using System.Reflection;
using System.Xml.Serialization;

namespace Iris.Contract.Generation.Common
{

    public static class EnumExtensions
    {
        public static string ToXmlName(this Enum en)
        {
            //Type type = en.GetType();
            MemberInfo[] mi = en.GetType().GetMember(en.ToString());
            if (mi != null && mi.Length > 0)
            {
                object[] x = mi[0].GetCustomAttributes(true);
                object[] att = mi[0].GetCustomAttributes(typeof(XmlEnumAttribute), false);
                if (att != null && att.Length > 0)
                    return ((XmlEnumAttribute)att[0]).Name;
            }
            return en.ToString();
        }
    }

}
