using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Iris.Contract.Generation.Common;

namespace Iris.Contract.Generation.Domain
{
    [Serializable]
    public class CalledConstructorDefinition : INotifyPropertyChanged
    {
        private bool _callBase;
        private string[] _parameterValues = new string[] { };

        [XmlElement(typeof(bool))]
        public virtual bool CallBase
        {
            get
            {
                return _callBase;
            }
            set
            {
                if (value == _callBase) return;
                _callBase = value;
                OnPropertyChanged("CallBase");
            }
        }
        [XmlArrayItem(typeof(string), IsNullable = true)]
        public virtual String[] ParameterValues
        {
            get { return _parameterValues; }
            set
            {
                if (ReferenceEquals(value, _parameterValues)) return;
                _parameterValues = value;
                OnPropertyChanged("ParameterValues");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public virtual String Serialize()
        {
            try
            {
                String XmlizedString = null;
                MemoryStream memoryStream = new MemoryStream();
                XmlSerializer xs = new XmlSerializer(typeof(EventDefinition));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

                xs.Serialize(xmlTextWriter, this);
                memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                XmlizedString = UTF8Helper.UTF8ByteArrayToString(memoryStream.ToArray());
                return XmlizedString;
            }
            catch
            {
                return String.Empty;
            }
        }

        public static String Serialize(object obj)
        {
            try
            {
                String XmlizedString = null;
                MemoryStream memoryStream = new MemoryStream();
                XmlSerializer xs = new XmlSerializer(typeof(EventDefinition));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

                xs.Serialize(xmlTextWriter, obj);
                memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                XmlizedString = UTF8Helper.UTF8ByteArrayToString(memoryStream.ToArray());
                return XmlizedString;
            }
            catch
            {
                return String.Empty;
            }
        }

        public static EventDefinition Deserialize(String xml)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(EventDefinition));
                MemoryStream memoryStream = new MemoryStream(UTF8Helper.StringToUTF8ByteArray(xml));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                return xs.Deserialize(memoryStream) as EventDefinition;
            }
            catch
            {
                return null;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(_callBase ? "base(" : "this(");
            if (ParameterValues != null)
                foreach (var parameterValue in ParameterValues)
                {
                    if (parameterValue != ParameterValues.FirstOrDefault())
                        sb.Append(",");
                    sb.Append(parameterValue);
                }
            sb.Append(")");
            return sb.ToString();

        }

    }
}
