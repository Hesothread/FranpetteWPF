using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace FranpetteClient.FranpetteWindow.LoginControls
{
    /// <summary>
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        public delegate void MyPersonalizedUCEventHandler();

        public event MyPersonalizedUCEventHandler OnConnected;

        private LoginDataContext _context = new LoginDataContext();
        //private NetworkClient _server = new NetworkClient(null);

        /*public Login(NetworkClient server)
        {
            if (server == null)
            {
                _server = server;
                _context.UserName = _server.Client.CurrentUser.Name;
                _context.Address = _server.Client.ServerAddress;
                _context.Remember = true;
            }
            else
            {
                _context.Remember = false;
            }

            _server.Client.PropertyChanged += _client_PropertyChanged;
            InitializeComponent();
            this.Root_LoginGrid.DataContext = _context;
        }*/

        private void ButtonConnection_Click(object sender, RoutedEventArgs e)
        {
            String address;
            int port;

            if (_context.Address.Split(':').Count() == 2)
            {
                address = _context.Address.Split(':')[0];
                if (!int.TryParse(_context.Address.Split(':')[1], out port))
                {
                    //FLog.Print("err_bad_port");
                    return;
                }
            }
            else if (_context.Address.Split(':').Count() == 1)
            {
                address = _context.Address.Split(':')[0];
                port = 4242;
            }
            else
            {
                //FLog.Print("err_bad_address");
                return;
            }
            
            //_server.Connect(address, port);
            Thread.Sleep(200);
           // _server.Login(_context.UserName, UserPassword.Password);
        }

        private void _client_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ConnectionState")
            {
                //if (_server.Client.ConnectionState == EConnectionState.Connected)
                {
                    if (OnConnected != null)
                    {
                        //FLog.Print("Connected");
                        OnConnected.Invoke();
                    }
                    else
                    {
                        //FLog.Print("can't connect : " + _server.Client.ErrorCode);
                    }
                }
            }
        }
    }
}
