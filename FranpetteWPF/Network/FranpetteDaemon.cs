using FranpetteLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace FranpetteWPF.Network
{
    class FranpetteDaemon
    {
        private Thread _thread;
        private FClient _client;
        private Dispatcher _fdispatcher;
        private string _rmessage;
        private string _smessage;

        public void StartDaemon(FClient client)
        {
            _fdispatcher = Dispatcher.CurrentDispatcher;
            _client = client;
            Task.Factory.StartNew(FDaemon);
        }

        private void FDaemon()
        {
            String addresse = "Hesothread.com";
            int port = 4242;
            UdpClient udpClient = new UdpClient(port);

            try
            {
                IPAddress[] addressesIP = Dns.GetHostAddresses(addresse);
                IPEndPoint groupEP = new IPEndPoint(addressesIP[0], port);

                udpClient.Connect(addresse, port);

                bool done = false;
                while (!done)
                {
                    byte[] pdata = udpClient.Receive(ref groupEP);
                    string _rmessage = Encoding.ASCII.GetString(pdata);
                    MessageRecieve(_rmessage);
                }
            }
            finally
            {
                udpClient.Close();
            }
        }

        private void MessageRecieve(string rawData)
        {
            if (!_fdispatcher.CheckAccess())
            {
                _fdispatcher.BeginInvoke(DispatcherPriority.Normal, () => { MessageRecieve(rawData); });
                return;
            }
            switch ()
            {
                case enum logged
                case enum logged
                case enum logged
                case enum logged
                case enum logged
                case enum logged
                case enum logged
                case enum logged
                case enum logged
                case enum logged
                case enum logged
                case enum logged
            }
        }
    }
}
