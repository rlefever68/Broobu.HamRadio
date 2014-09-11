using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Iris.Contract.Generation.Common;

namespace Iris.Contract.Generation.Domain
{
    [Serializable]
    public class ParameterDefinition : NameItemDefinitionBase
    {
        private TypeDefinition _Type;
        private ParameterModifier _Modifier;
        private string _DefaultValue;

        [XmlElement(typeof(TypeDefinition))]
        public virtual TypeDefinition Type
        {
            get { return _Type; }
            set
            {
                if (value == _Type) return;
                _Type = value;
                OnPropertyChanged("Type");
            }
        }
        [XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public virtual string DefaultValue
        {
            get { return _DefaultValue; }
            set
            {
                if (value == _DefaultValue) return;
                _DefaultValue = value;
                OnPropertyChanged("DefaultValue");
            }
        }
        [XmlAttribute()]       
        public virtual ParameterModifier Modifier
        {
            get { return _Modifier; }
            set
            {
                if (value == _Modifier) return;
                _Modifier = value;
                OnPropertyChanged("Modifier");
            }
        }
        [XmlIgnore]
        public override List<string> UsedNamespaces
        {
            get
            {
                var list = base.UsedNamespaces;
                if (Type != null)
                    list.AddRange(Type.UsedNamespaces);
                return list.Distinct().OrderBy(x => x).ToList();
            }
        }

        public virtual String Serialize()
        {
            try
            {
                String XmlizedString = null;
                MemoryStream memoryStream = new MemoryStream();
                XmlSerializer xs = new XmlSerializer(typeof(PropertyDefinition));
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
                XmlSerializer xs = new XmlSerializer(typeof(PropertyDefinition));
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

        public static PropertyDefinition Deserialize(ref String xml)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(PropertyDefinition));
                MemoryStream memoryStream = new MemoryStream(UTF8Helper.StringToUTF8ByteArray(xml));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                return xs.Deserialize(memoryStream) as PropertyDefinition;
            }
            catch
            {
                return null;
            }
        }

        public override string ToString()
        {
            return String.Format
                   (
                        "{0}{1} {2}{3}", 
                        (Modifier != ParameterModifier.None ? String.Format("{0} ", Modifier.ToString().ToLower()) : String.Empty), 
                        Type.FullName, 
                        Name,String.IsNullOrWhiteSpace(DefaultValue)?String.Empty:String.Format(" = {0}",DefaultValue));
        }
    }
}
