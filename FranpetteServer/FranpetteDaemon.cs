using FranpetteLib.Model;
using FranpetteLib.Network;
using FranpetteLib.Serialisation.XMLSerialisation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FranpetteServer
{
    public class FranpetteDaemon
    {
        public char SEPARATOR = ':';
        
        private FClient _server;
        private Boolean _done = true;

        public Boolean StartDaemon()
        {
            if (_done == false)
                return false;
            //_server = XMLSerialisation.Serialise("franpette.xml");
            _server = new FClient();
            _server.Name = "Franpette premier du nom !";
            _server.ServerPort = 4242;
            _server.Ip = new WebClient().DownloadString("http://icanhazip.com");
            _done = false;
            FDaemon();
            return true;
        }
        public void StopDaemon()
        {
            if (_done == true)
                return;
            _done = true;
        }

        private void FDaemon()
        {
            IPEndPoint sender;
            IPEndPoint ServerListener = new IPEndPoint(IPAddress.Any, _server.ServerPort);
            UdpClient udpClient = new UdpClient(ServerListener);
            try
            {
                Console.WriteLine("SERVER : Franpette start " + _server.Ip + " : " + _server.ServerPort);
                while (!_done)
                {
                    sender = new IPEndPoint(IPAddress.Any, 0);
                    byte[] pdata = udpClient.Receive(ref sender);
                    string _rmessage = Encoding.ASCII.GetString(pdata);
                    Console.WriteLine("SERVER : New client connection " + sender.Address.ToString() + "/" + sender.Port + " : " + _rmessage);
                    
                    MessageRecieve(new IPEndPoint(sender.Address, sender.Port), udpClient, _rmessage);
                }
            }
            finally
            {
                udpClient.Close();
                _server = null;
                Console.WriteLine("SERVER : Franpette stop ");
            }
        }

        public void MessageRecieve(IPEndPoint sender, UdpClient udpClient, string message)
        {
            FSession session = new FSession();
            Task.Factory.StartNew(() => session.Daemon(_server, sender, udpClient, message));
        }

    }
}
