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

namespace FranpetteWPFClient.Network
{
    public enum EResponsePacket
    {
        SERV_CONECTED,
        SERV_DISCONECTED,

        USER_PING,
        USER_LOGED,
        USER_DISCONNECTED,

    }

    public class FranpetteDaemon
    {
        private Thread _thread;
        private FClient _client;
        private Dispatcher _fdispatcher;
        private string _rmessage;
        private Boolean _done = true;

        public bool isDone { get => _done; private set => _done = value; }

        public Boolean StartDaemon(FClient client, UdpClient udpClient)
        {
            if (_done == false)
                return false;
            _fdispatcher = Dispatcher.CurrentDispatcher;
            _client = client;
            Task.Factory.StartNew(() => FDaemon(client, udpClient));
            _done = false;
            return true;
        }
        public void StopDaemon()
        {
            if (_done == true)
                return;
            _fdispatcher = null;
            _client = null;
            _done = true;
        }

        private void FDaemon(FClient client, UdpClient udpClient)
        {
            try
            {
                IPAddress[] addressesIP = Dns.GetHostAddresses(client.ServerAddress);
                IPEndPoint groupEP = new IPEndPoint(addressesIP[0], client.ServerPort);
                
                while (!_done)
                {
                    byte[] pdata = udpClient.Receive(ref groupEP);
                    string _rmessage = Encoding.ASCII.GetString(pdata);
                    Console.WriteLine(_rmessage);
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
            /*if (!_fdispatcher.CheckAccess())
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
            }*/
        }
    }
}
