using FranpetteLib.Model;
using FranpetteLib.JsonManager;
using FranpetteLib.Network;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FranpetteClient.Network
{
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

                _udpClient = new UdpClient(port);
                IPAddress[] addressesIP = Dns.GetHostAddresses(address);
                IPEndPoint groupEP = new IPEndPoint(addressesIP[0], port);
                _udpClient.Connect(address, port);
                if (!StartDaemon())
                {
                    Disconnect();
                    return _client;
                }

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
            if (_daemon.StartDaemon(_client, _udpClient))
                return true;
            return false;
        }

        public void Disconnect()
        {
            if (_udpClient != null)
            {
                sendMessage(ERequestPacket.SERV_DISCONECT.ToString());
                _udpClient.Dispose();
            }
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
            string pass = "";
            if (password != null)
            {
                var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(password));
                pass = SEPARATOR + string.Concat(hash.Select(b => b.ToString("x2")));
            }
            sendMessage(ERequestPacket.AUTH_LOGIN.ToString() + SEPARATOR + login + pass);
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

            String localStream = Json.GetStream(localPath);
            //String serverStream = Json.GetStream(application.Path); A faire coté serveur !

            foreach (var elem in Json.MissingFiles(localStream, serverStream))
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + serverAddress + "/" + elem.Item2);
                request.Credentials = new NetworkCredential(login, password);
                request.Method = WebRequestMethods.Ftp.DownloadFile;

                try
                {
                    using (Stream ftpStream = request.GetResponse().GetResponseStream())
                    using (Stream fileStream = File.Create(elem.Item1))
                    {
                        byte[] buffer = new byte[102400];
                        int read;
                        while ((read = ftpStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            fileStream.Write(buffer, 0, read);
                        }
                    }
                }
                catch (WebException e)
                {
                    return;
                }
            }

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
