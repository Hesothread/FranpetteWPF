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

namespace FranpetteWPF.FranpetteWindow.HomeControls.RightFriends
{
    /// <summary>
    /// Logique d'interaction pour RFriend.xaml
    /// </summary>
    public partial class RFriend : UserControl
    {
        private string _fName = "Inconnu";
        private bool _fOnline;
        private bool _fAfk;

        public string FName
        {
            get { return _fName; }
            set { _fName = value; }
        }

        public bool FOnline
        {
            get { return _fOnline; }
            set { _fOnline = value; }
        }

        public bool FAfk
        {
            get { return _fAfk; }
            set { _fAfk = value; }
        }

        public string StatusIcon
        {
            get { return (_fOnline) ? "/Ressources/onlinex32.png" : "/Ressources/offlinex32.png"; }
        }

        public RFriend(string name, bool online = true, bool afk = false)
        {
            FName = name;
            FOnline = online;
            FAfk = afk;
            InitializeComponent();
        }
    }
}
