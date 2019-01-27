using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranpetteClient.FranpetteWindow.HomeControls.RightFriends
{
    class RFriendsDataContext : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Friend> _friendList = new ObservableCollection<Friend>();
        public ObservableCollection<Friend> FriendList
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
