using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranpetteWPF.FranpetteWindow.HomeControls.RightFriends
{
    class RFriendsDataContext : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<RFriend> _friendList = new ObservableCollection<RFriend>();
        public ObservableCollection<RFriend> FriendList
        {
            get { return _friendList; }
            set
            {
                _friendList = value;
                OnPropertyChanged("FriendList");
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
