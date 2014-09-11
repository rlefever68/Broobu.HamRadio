using System;
using System.Xml.Serialization;

namespace Iris.Contract.Generation.Domain
{
    [Serializable]
    public enum ParameterModifier
    {
        [XmlEnum(Name = "")]        
         None,
        [XmlEnum(Name = "ref")]
        REF,
        [XmlEnum(Name = "out")]
        OUT
    }
}
