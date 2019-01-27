using System;
using System.Collections.Generic;
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

namespace FranpetteClient.FranpetteWindow.HomeControls.MenuBar
{
    /// <summary>
    /// Logique d'interaction pour MBar.xaml
    /// </summary>
    public partial class MBar : UserControl
    {
        public delegate void UCEventHandler();

        public event UCEventHandler NewsUCEvent;
        public event UCEventHandler ServerListUCEvent;
        public event UCEventHandler OptionsUCEvent;
        public event UCEventHandler FriendsUCEvent;

        private bool _RFState = false;

        public MBar()
        {
            InitializeComponent();
        }

        public void GoToNews()
        {
            if (NewsUCEvent != null) NewsUCEvent.Invoke();
        }

        private void NewsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NewsUCEvent != null) NewsUCEvent.Invoke();
        }

        public void GoToServerList()
        {
            if (ServerListUCEvent != null) ServerListUCEvent.Invoke();
        }

        private void ServerListBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ServerListUCEvent != null) ServerListUCEvent.Invoke();
        }

        public void GoToOptions()
        {
            if (OptionsUCEvent != null) OptionsUCEvent.Invoke();
        }

        private void OptionsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (OptionsUCEvent != null) OptionsUCEvent.Invoke();
        }

        public void OpenFriends()
        {
            if (FriendsUCEvent != null) FriendsUCEvent.Invoke();
        }

        private void FriendsBtn_Click(object sender, RoutedEventArgs e)
        {
            _RFState = !_RFState;

            if (_RFState == true)
                FriendsBtn.Content = "🞂";
            else
                FriendsBtn.Content = "🞀 Amis";

            if (FriendsUCEvent != null) FriendsUCEvent.Invoke();
        }
    }
}
