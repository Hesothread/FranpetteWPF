using System;
using System.Collections.Generic;
using System.Text;

namespace FranpetteLib.Model
{
    public class FApplication : AFranpetteObject
    {
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
        private String _description;
        public String Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }
        private FUser _startedUser;
        public FUser StartedUser
        {
            get { return _startedUser; }
            set
            {
                _startedUser = value;
                OnPropertyChanged("StartedUser");
            }
        }
        private String _startedDate;
        public String StartedDate
        {
            get { return _startedDate; }
            set
            {
                _startedDate = value;
                OnPropertyChanged("StartedDate");
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
        
        private FUser _lastUser;
        public FUser LastUser
        {
            get { return _lastUser; }
            set
            {
                _lastUser = value;
                OnPropertyChanged("LastUser");
            }
        }
        private String _lastDate;
        public String LastDate
        {
            get { return _lastDate; }
            set
            {
                _lastDate = value;
                OnPropertyChanged("LastDate");
            }
        }

        private String _path;
        public String Path
        {
            get { return _path; }
            set
            {
                _path = value;
                OnPropertyChanged("Path");
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

        private FUser _owner;
        public FUser Owner
        {
            get { return _owner; }
            set
            {
                _owner = value;
                OnPropertyChanged("Owner");
            }
        }
        private String _creationDate;
        public String CreationDate
        {
            get { return _creationDate; }
            set
            {
                _creationDate = value;
                OnPropertyChanged("CreationDate");
            }
        }

        public override String GetFType()
        {
            return "FApplication_" + _name;
        }
    }
}
