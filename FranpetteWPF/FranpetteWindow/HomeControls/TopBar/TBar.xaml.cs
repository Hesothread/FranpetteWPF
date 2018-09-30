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

namespace FranpetteWPF.FranpetteWindow.HomeControls.TopBar
{
    /// <summary>
    /// Logique d'interaction pour TBar.xaml
    /// </summary>
    public partial class TBar : UserControl
    {
        public delegate void UCEventHandler();

        public event UCEventHandler NewsUCEvent;
        public event UCEventHandler ServerListUCEvent;
        public event UCEventHandler OptionsUCEvent;

        public TBar()
        {
            InitializeComponent();
        }

        public void GoToNews()
        {
            if (NewsUCEvent != null) NewsUCEvent.Invoke();
        }
        
        private void NewsBtn_Click(object sender, RoutedEventArgs e)
        {
            GoToNews();
        }

        public void GoToServerList()
        {
            if (ServerListUCEvent != null) ServerListUCEvent.Invoke();
        }

        private void ServerListBtn_Click(object sender, RoutedEventArgs e)
        {
            GoToServerList();
        }

        public void GoToOptions()
        {
            if (OptionsUCEvent != null) OptionsUCEvent.Invoke();
        }

        private void OptionsBtn_Click(object sender, RoutedEventArgs e)
        {
            GoToOptions();
        }
    }
}
