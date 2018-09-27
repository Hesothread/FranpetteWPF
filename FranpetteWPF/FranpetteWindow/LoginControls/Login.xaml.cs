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

namespace FranpetteWPF.FranpetteWindow.LoginControls
{
    /// <summary>
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        public delegate void MyPersonalizedUCEventHandler();

        public event MyPersonalizedUCEventHandler MyPersonalizedUCEvent;

        public void RaiseMyEvent()
        {
            // Your logic
            if (MyPersonalizedUCEvent != null)
            {
                MyPersonalizedUCEvent.Invoke();
            }
        }

        public Login()
        {
            InitializeComponent();
         }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RaiseMyEvent();
        }
    }
}
