using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Iris.Contract.Generation.Domain
{
    [Serializable]
    public class NameItemDefinitionBase : INotifyPropertyChanged
    {
        private string _Name;

        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public virtual String Name
        {
            get { return _Name; }
            set
            {
                if (value == _Name) return;
                _Name = value;
                OnPropertyChanged("Name");
            }
        }

        [XmlIgnore]
        public virtual List<string> UsedNamespaces
        {
            get
            {
                return new List<string>();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
