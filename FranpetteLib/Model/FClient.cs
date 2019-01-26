using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranpetteLib.Model
{
    public class FClient : AFranpetteObject
    {
        private String _news;
        public String News
        {
            get { return _news; }
            set
            {
                _news = value;
                OnPropertyChanged("News");
            }
        }
        private FUser _newsOwner;
        public FUser NewsOwner
        {
            get { return _newsOwner; }
            set
            {
                _newsOwner = value;
                OnPropertyChanged("NewsOwner");
            }
        }

        private FUser _currentUser;
        public FUser CurrentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;
                OnPropertyChanged("CurrentUser");
            }
        }

        private EConnectionState _connectionState;
        public EConnectionState ConnectionState
        {
            get { return _connectionState; }
            set
            {
                _connectionState = value;
                OnPropertyChanged("ConnectionState");
            }
        }
        private int _errorCode;
        public int ErrorCode
        {
            get { return _errorCode; }
            set
            {
                _errorCode = value;
                OnPropertyChanged("ErrorCode");
            }
        }

        private String _ip;
        public String Ip
        {
            get { return _ip; }
            set
            {
                _ip = value;
                OnPropertyChanged("Ip");
            }
        }
        private int _ping;
        public int Ping
        {
            get { return _ping; }
            set
            {
                _ping = value;
                OnPropertyChanged("Ping");
            }
        }

        private String _localVersion;
        public String LocalVersion
        {
            get { return _localVersion; }
            set
            {
                _localVersion = value;
                OnPropertyChanged("LocalVersion");
            }
        }
        private String _serverVersion;
        public String ServerVersion
        {
            get { return _serverVersion; }
            set
            {
                _serverVersion = value;
                OnPropertyChanged("ServerVersion");
            }
        }
        private String _serverAddress;
        public String ServerAddress
        {
            get { return _serverAddress; }
            set
            {
                _serverAddress = value;
                OnPropertyChanged("ServerAddress");
            }
        }
        private int _serverPort;
        public int ServerPort
        {
            get { return _serverPort; }
            set
            {
                _serverPort = value;
                OnPropertyChanged("ServerPort");
            }
        }

        private List<FApplication> _applicationsList;
        public List<FApplication> ApplicationsList
        {
            get { return _applicationsList; }
            set
            {
                _applicationsList = value;
                OnPropertyChanged("ApplicationsList");
            }
        }
        private List<FUser> _usersList;
        public List<FUser> UsersList
        {
            get { return _usersList; }
            set
            {
                _usersList = value;
                OnPropertyChanged("UsersList");
            }
        }
        
        public override String GetFType()
        {
            return "FClient";
        }
    }
}
