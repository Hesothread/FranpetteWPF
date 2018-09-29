using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FranpetteWPF.FranpetteWindow.HomeControls.CenterServerList
{
    class CServerListDataContext : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<CServer> _serverList;
        public ObservableCollection<CServer> ServerList
        {
            get { return _serverList; }
            set
            {
                _serverList = value;
                OnPropertyChanged("ServerList");
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
