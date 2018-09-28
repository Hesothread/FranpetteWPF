using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FranpetteWPF.FranpetteWindow.HomeControls
{
    class HomeDataContext : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private UserControl _centerMenu;
        public UserControl CenterMenu
        {
            get { return _centerMenu; }
            set
            {
                _centerMenu = value;
                OnPropertyChanged("CenterMenu");
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
