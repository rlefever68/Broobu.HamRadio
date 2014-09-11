using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Iris.Contract.Generation.Domain
{
    [Serializable]
    public class NamespaceItemDefinitionBase : NameItemDefinitionBase
    {
        private string _Namespace;

        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public virtual string Namespace
        {
            get { return _Namespace; }
            set
            {
                if (value == _Namespace) return;
                _Namespace = value;
                OnPropertyChanged("Namespace");
            }
        }

        [XmlIgnore]
        public override List<string> UsedNamespaces
        {
            get
            {
                var list = base.UsedNamespaces;
                if (!String.IsNullOrWhiteSpace(Namespace))
                    list.Add(Namespace);
                return list.Distinct().OrderBy(x=>x).ToList();
            }
        }
    }
}
