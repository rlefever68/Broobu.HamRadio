using System;
using System.Xml.Serialization;

namespace Iris.Contract.Generation.Domain
{
    [Serializable]
    public enum Modifier
    {
        [XmlEnum(Name = "")]
        None,
        [XmlEnum(Name = "public")]        
        Public,
        [XmlEnum(Name = "private")]
        Private,
        [XmlEnum(Name = "internal")]
        Internal,
        [XmlEnum(Name = "protected")]
        Protected,
        [XmlEnum(Name = "protected internal")]
        ProtectedInternal
    }
}
