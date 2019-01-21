using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FranpetteLib.Model
{
    public class FUser : AFranpetteObject
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
        private List<FUser> _friendsList;
        public List<FUser> FriendsList
        {
            get { return _friendsList; }
            set
            {
                _friendsList = value;
                OnPropertyChanged("FriendsList");
            }
        }

        public override String GetFType()
        {
            return "FUser";
        }
    }
}
