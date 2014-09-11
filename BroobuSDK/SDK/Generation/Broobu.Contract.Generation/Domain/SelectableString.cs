using System;
using System.ComponentModel;

namespace Iris.Contract.Generation.Domain
{
    public class SelectableString:INotifyPropertyChanged
    {
        
        private String _Text;
        
        private Boolean _IsSelected;
        
        public String Text
        {
            get { return _Text; }
            set
            {
                if (value == _Text) return;
                _Text = value;
                OnPropertyChanged("Text");
            }
        }
        public Boolean IsSelected
        {
            get { return _IsSelected; }
            set
            {
                if (value == _IsSelected) return;
                _IsSelected = value;
                OnPropertyChanged("IsSelected");
                if (SelectionChanged != null)
                {
                    SelectionChanged(this, new EventArgs());
                }
            }
        }

        void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(propertyName));
            }
        }

        public event EventHandler SelectionChanged;
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
