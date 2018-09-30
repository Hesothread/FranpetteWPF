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
        private UserControl _centerOptions;
        private UserControl _centerPage;

        public UserControl CenterNews
        {
            get { return _centerNews; }
            set
            {
                _centerNews = value;
                OnPropertyChanged("CenterNews");
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

        public UserControl CenterPage
        {
            get { return _centerPage; }
            set
            {
                _centerPage = value;
                OnPropertyChanged("CenterPage");
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
