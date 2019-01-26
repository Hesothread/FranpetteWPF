using FranpetteLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FranpetteWPFClient.Network
{
    public enum ERequestPacket
    {
        SERV_CONECT     = 10,   // + version
        SERV_DISCONECT  = 11,   // 

        AUTH_LOGIN      = 20,   // + login + password
        AUTH_LOGOUT     = 21,

        USER_GETLIST    = 30,
        USER_GET        = 31,
        USER_SET        = 32,

        APPLICATION_GETLIST = 40,
        APPLICATION_GET     = 41,
        APPLICATION_SET     = 42,

        INFO_GET        = 50,
        INFO_SET        = 51
    }

    public class NetworkClient
    {
        public char SEPARATOR = ':';

        FClient _client = new FClient();
        UdpClient _udpClient;
        FranpetteDaemon _daemon;

        public FClient Connect(String address, int port)
        {

            try
            {
                if ((_daemon != null && !_daemon.isDone) || _udpClient != null)
                    Disconnect();
                _client.ServerAddress = address;
                _client.ServerPort = port;
                _client.Ip = new WebClient().DownloadString("http://icanhazip.com");

                if (!StartDaemon())
                {
                    Disconnect();
                    return _client;
                }

                _udpClient = new UdpClient(port);
                IPAddress[] addressesIP = Dns.GetHostAddresses(address);
                IPEndPoint groupEP = new IPEndPoint(addressesIP[0], port);
                _udpClient.Connect(address, port);
                sendMessage(ERequestPacket.SERV_CONECT.ToString() + SEPARATOR + _client.LocalVersion);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Disconnect();
            }

            return _client;
        }

        private Boolean StartDaemon()
        {
            if (_daemon == null)
            {
                _daemon = new FranpetteDaemon();
                if (!_daemon.isDone)
                    return false;
            }
            if (_daemon.StartDaemon(_client))
                return true;
            return false;
        }

        public void Disconnect()
        {
            if (_udpClient != null)
                _udpClient.Dispose();
            if (_daemon == null)
                return;
            _daemon.StopDaemon();
            _daemon = null;
            _udpClient = null;
        }


        private void sendMessage(String message)
        {
            Byte[] sendBytes = Encoding.ASCII.GetBytes(message);
            try
            {
                _udpClient.Send(sendBytes, sendBytes.Length);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void Login(String login, String password)
        {
            if (_daemon == null || _daemon.isDone || _udpClient == null)
                return;
            sendMessage(ERequestPacket.AUTH_LOGIN.ToString() + SEPARATOR + login + SEPARATOR + SHA1.Create().ComputeHash(Encoding.ASCII.GetBytes(password)));
            return;
        }
        public void Logout()
        {
            if (_daemon == null || _daemon.isDone || _udpClient == null || _client.CurrentUser == null)
                return;
            sendMessage(ERequestPacket.AUTH_LOGOUT.ToString() + SEPARATOR + _client.CurrentUser.Id);
            return;
        }

        public void GetUsersList()
        {
            if (_daemon == null || _daemon.isDone || _udpClient == null || _client.CurrentUser == null)
                return;
            sendMessage(ERequestPacket.USER_GETLIST.ToString() + SEPARATOR + _client.CurrentUser.Id);
            return;
        }
        public void GetUser(int id)
        {
            if (_daemon == null || _daemon.isDone || _udpClient == null || _client.CurrentUser == null)
                return;
            sendMessage(ERequestPacket.USER_GETLIST.ToString() + SEPARATOR + _client.CurrentUser.Id + SEPARATOR + id);
            return;
        }
        public void UpdateUser(FUser user)
        {
            if (_daemon == null || _daemon.isDone || _udpClient == null || _client.CurrentUser == null)
                return;
            sendMessage(ERequestPacket.USER_GETLIST.ToString() + SEPARATOR + _client.CurrentUser.Id + SEPARATOR
                + user.Id + SEPARATOR
                + user.Name + SEPARATOR
                + user.Description + SEPARATOR
                + user.ConnectionState.ToString() + SEPARATOR
                + user.Ip);
            return;
        }

        public void GetServerInfo()
        {
            if (_daemon == null || _daemon.isDone || _udpClient == null || _client.CurrentUser == null)
                return;
            sendMessage(ERequestPacket.INFO_GET.ToString() + SEPARATOR + _client.CurrentUser.Id);
            return;
        }
        public void UpdateServerInfo(FClient client)
        {
            if (_daemon == null || _daemon.isDone || _udpClient == null || _client.CurrentUser == null)
                return;
            sendMessage(ERequestPacket.INFO_SET.ToString() + SEPARATOR + _client.CurrentUser.Id + SEPARATOR
                + client.Id + SEPARATOR
                + client.Name + SEPARATOR
                + client.NewsOwner.Id + SEPARATOR
                + client.News);
            return;
        }

        public void GetApplicationsList()
        {
            if (_daemon == null || _daemon.isDone || _udpClient == null || _client.CurrentUser == null)
                return;
            sendMessage(ERequestPacket.APPLICATION_GETLIST.ToString() + SEPARATOR + _client.CurrentUser.Id);
            return;
        }
        public void GetApplication(int id)
        {
            if (_daemon == null || _daemon.isDone || _udpClient == null || _client.CurrentUser == null)
                return;
            sendMessage(ERequestPacket.USER_GETLIST.ToString() + SEPARATOR + _client.CurrentUser.Id + SEPARATOR + id);
            return;
        }
        public void UpdateApplication(FApplication application)
        {
            if (_daemon == null || _daemon.isDone || _udpClient == null || _client.CurrentUser == null)
                return;
            sendMessage(ERequestPacket.USER_GETLIST.ToString() + SEPARATOR + _client.CurrentUser.Id + SEPARATOR
                + application.Id + SEPARATOR
                + application.Name + SEPARATOR
                + application.Description + SEPARATOR
                + application.ConnectionState.ToString() + SEPARATOR
                + application.StartedUser.Id + SEPARATOR
                + application.Ip + SEPARATOR
                + application.LocalVersion + SEPARATOR
                + application.StartedDate + SEPARATOR
                + application.Owner.Id + SEPARATOR
                + application.CreationDate + SEPARATOR
                + application.LastUser.Id + SEPARATOR
                + application.LastDate + SEPARATOR);
            return;
        }

        public void DowloadApplication(FApplication application, String localPath)
        {
            if (_daemon == null || _daemon.isDone || _udpClient == null || _client.CurrentUser == null)
                return;

            return;
        }
        public void UploadApplication(FApplication application)
        {
            if (_daemon == null || _daemon.isDone || _udpClient == null || _client.CurrentUser == null)
                return;

            return;
        }
        public void StartApplication(FApplication application)
        {
            if (_daemon == null || _daemon.isDone || _udpClient == null || _client.CurrentUser == null)
                return;

            return;
        }
        public void StopApplication(FApplication application)
        {
            if (_daemon == null || _daemon.isDone || _udpClient == null || _client.CurrentUser == null)
                return;

            return;
        }
    }
}
