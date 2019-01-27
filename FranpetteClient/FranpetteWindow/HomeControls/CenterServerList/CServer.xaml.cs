using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FranpetteClient.FranpetteWindow.HomeControls.CenterServerList
{
    /// <summary>
    /// Logique d'interaction pour CServer.xaml
    /// </summary>
    public partial class CServer : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _serverIcon = "/Ressources/minecraft.jpg";
        public string ServerIcon
        {
            get { return _serverIcon; }
            private set
            {
                _serverIcon = value;
                OnPropertyChanged("ServerIcon");
            }
        }

        private string _serverName;
        public string ServerName
        {
            get { return "Title : " + _serverName; }
            private set
            {
                _serverName = value;
                OnPropertyChanged("ServerName");
            }
        }

        private bool _isStarted = false;
        public bool IsStarted
        {
            get { return _isStarted; }
            private set
            {
                _isStarted = value;
                OnPropertyChanged("IsStarted");
            }
        }

        private string _startedUserName;
        public string StartedUserName
        {
            get { return "Last user : " + _startedUserName; }
            private set
            {
                _startedUserName = value;
                OnPropertyChanged("StartedUserName");
            }
        }

        private string _startedIp;
        public string StartedIP
        {
            get { return "Last ip : " + _startedIp; }
            private set
            {
                _startedIp = value;
                OnPropertyChanged("StartedIP");
            }
        }

        public CServer(bool started = false, string name = "Inconnu", string user = "Inconnu", string ip = "Inconnu")
        {
            InitializeComponent();
            DataContext = this;

            _isStarted = started;
            _serverName = name;
            _startedUserName = user;
            _startedIp = ip;
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
