using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranpetteWPF.FranpetteWindow.HomeControls.BottomBar
{
    class BBarDataContext : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _version = "3.0.1";

        public string CurrentVersion
        {
            get { return _version; }
            set
            {
                _version = value;
                OnPropertyChanged("CurrentVersion");
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
