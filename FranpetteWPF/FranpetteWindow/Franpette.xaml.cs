using FranpetteWPF.FranpetteWindow.HomeControls;
using FranpetteWPF.FranpetteWindow.LoginControls;
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

namespace FranpetteWPF.FranpetteWindow
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class Franpette : Window
    {
        private FranpetteDataContext _franpetteContext =  new FranpetteDataContext();

        private Login _login;
        private Home _home;

        public Franpette()
        {
            InitializeComponent();
            DataContext = _franpetteContext;
        }

        private void OnLoginAccepted()
        {
            _home = new Home();
            _franpetteContext.MainWindow = _home;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _login = new Login();
            _login.MyPersonalizedUCEvent += OnLoginAccepted;
            _franpetteContext.MainWindow = _login;
        }
    }
}
