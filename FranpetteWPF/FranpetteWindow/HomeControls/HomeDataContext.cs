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

        private UserControl _centerNews;
        private UserControl _centerServerList;
        private UserControl _centerOptions;
        private UserControl _homeContent;

        public UserControl CenterNews
        {
            get { return _centerNews; }
            set
            {
                _centerNews = value;
                OnPropertyChanged("CenterNews");
            }
        }

        public UserControl CenterServerList
        {
            get { return _centerServerList; }
            set
            {
                _centerServerList = value;
                OnPropertyChanged("CenterServerList");
            }
        }

        public UserControl CenterOptions
        {
            get { return _centerOptions; }
            set
            {
                _centerOptions = value;
                OnPropertyChanged("CenterOptions");
            }
        }

        public UserControl HomeContent
        {
            get { return _homeContent; }
            set
            {
                _homeContent = value;
                OnPropertyChanged("HomeContent");
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
