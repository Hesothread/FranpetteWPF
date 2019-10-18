using FranpetteClient.FranpetteWindow.HomeControls;
using FranpetteClient.FranpetteWindow.LoginControls;
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

namespace FranpetteClient.FranpetteWindow
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class Franpette : Window
    {
        private FranpetteDataContext _franpetteContext =  new FranpetteDataContext();

        //private FClient _client;
        //private NetworkClient _server;

        private Login _login;
        private Home _home;

        public Franpette()
        {
            //_client = XMLSerialisation.Serialise("FranpetteUser.conf");

            InitializeComponent();
            this.Root_Franpette.DataContext = _franpetteContext;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //_server = new NetworkClient(_client);

            //_login = new Login(_server);

            _login.OnConnected += OnLoginAccepted;
            _franpetteContext.MainWindow = _login;
        }

        //EventHandler
        private void OnLoginAccepted()
        {
            //_home = new Home(_server);
            _franpetteContext.MainWindow = _home;
        }
    }
}
