using FranpetteLib.Model;
using FranpetteLib.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace FranpetteClient.Network
{
    public class FranpetteDaemon
    {
        public static Semaphore _semaphore { get; set; }

        public char SEPARATOR = ':';
        
        private FClient _client;
        private Dispatcher _fdispatcher;
        public string _rmessage;

        private Boolean _done = true;
        public bool isDone { get => _done; private set => _done = value; }

        public Boolean StartDaemon(FClient client, UdpClient udpClient)
        {
            if (_done == false)
                return false;
            _fdispatcher = Dispatcher.CurrentDispatcher;
            _client = client;
            _semaphore = new Semaphore(0,1);
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
            if (!_fdispatcher.CheckAccess())
            {
                _fdispatcher.Invoke(() => { MessageRecieve(rawData); });
                return;
            }

            if (rawData == null || rawData == "")
                return;

            String[] rawsData = rawData.Split(SEPARATOR);


            EResponsePacket code;
            if (!Enum.TryParse(rawsData[0], out code))
                return;

            switch (code)
            {
                case EResponsePacket.SERV_CONECTED:
                    MsgServConnected(rawsData);
                    break;
                case EResponsePacket.SERV_DISCONECTED:
                    MsgServDisconnected(rawsData);
                    break;
                case EResponsePacket.AUTH_CONNECT:
                    MsgAuthConnected(rawsData);
                    break;
                case EResponsePacket.AUTH_DISCONNECTED:
                    MsgAuthDisconnected(rawsData);
                    break;
                case EResponsePacket.USER_INFO:
                    MsgUserInfo(rawsData);
                    break;
                case EResponsePacket.APPLICTION_INFO:
                    MsgApplicationInfo(rawsData);
                    break;
                case EResponsePacket.SERVER_INFO:
                    MsgServerInfo(rawsData);
                    break;
                case EResponsePacket.APPLICTION_HEADER:
                    MsgApplicationHeader(rawsData);
                    break;
                case EResponsePacket.SERVER_ERROR:
                    MsgServerError(rawsData);
                    break;
                default:
                    MsgUnreadable(rawsData);
                    break;
            }
        }

        public void MsgServConnected(String[] datas)
        {
            if (datas == null || datas.Count() != 3)
                return;
            _client.ServerVersion = datas[1];
            _client.Name = datas[2];
            _client.ConnectionState = EConnectionState.Connected;
        }
        public void MsgServDisconnected(String[] datas)
        {
            if (datas == null || datas.Count() != 1)
                return;
            _client.ConnectionState = EConnectionState.Disconnected;
        }
        public void MsgAuthConnected(String[] datas)
        {
            if (datas == null || datas.Count() != 2)
                return;
            int tmp;
            if (!int.TryParse(datas[1], out tmp))
                return;
            _client.Id = tmp;
            _client.ServerVersion = datas[1];
        }
        public void MsgAuthDisconnected(String[] datas)
        {
            if (datas == null || datas.Count() != 1)
                return;
        }
        public void MsgUserInfo(String[] datas)
        {
            if (datas == null || datas.Count() != 6)
                return;
            FUser user = new FUser();
            int tmp;
            EConnectionState etmp;
            if (!int.TryParse(datas[1], out tmp))
                return;
            if (!Enum.TryParse(datas[3], out etmp))
                return;
            user.Id = tmp;
            user.Name = datas[2];
            user.ConnectionState = etmp;
            user.Description = datas[4];
            user.Ip = datas[5];

            if (_client.Id == user.Id)
            {
                if (_client.CurrentUser != null)
                {
                    _client.CurrentUser.Name = user.Name;
                    _client.CurrentUser.Ip = user.Ip;
                    _client.CurrentUser.ConnectionState = user.ConnectionState;
                    _client.CurrentUser.Description = user.Description;
                }
                else
                    _client.CurrentUser = user;
            }
            else
            {
                foreach(FUser fuser in _client.UsersList)
                {
                    if (fuser.Id == user.Id)
                    {
                        fuser.Name = user.Name;
                        fuser.Ip = user.Ip;
                        fuser.ConnectionState = user.ConnectionState;
                        fuser.Description = user.Description;
                        return;
                    }
                }
                _client.UsersList.Add(user);
            }
        }
        public void MsgApplicationInfo(String[] datas)
        {                                             
            if (datas == null || datas.Count() != 13) 
                return;
            FApplication application = new FApplication();
            int tmp;
            int tmpStarted;
            int tmplast;
            int tmpowner;
            EConnectionState etmp;
            if (!int.TryParse(datas[1], out tmp))
                return;
            if (!int.TryParse(datas[5], out tmpStarted))
                return;
            if (!int.TryParse(datas[8], out tmplast))
                return;
            if (!int.TryParse(datas[11], out tmpowner))
                return;
            if (!Enum.TryParse(datas[4], out etmp))
                return;
            foreach (FUser fuser in _client.UsersList)
                if (fuser.Id == tmpStarted)
                    application.StartedUser = fuser;
            foreach (FUser fuser in _client.UsersList)
                if (fuser.Id == tmplast)
                    application.LastUser = fuser;
            foreach (FUser fuser in _client.UsersList)
                if (fuser.Id == tmpowner)
                    application.Owner = fuser;
            application.Id = tmp;
            application.ConnectionState = etmp;
            application.Name = datas[2];
            application.Description = datas[3];
            application.StartedDate = datas[6];
            application.Ip = datas[7];
            application.LastDate = datas[9];
            application.ServerVersion = datas[10];
            application.CreationDate = datas[12];


            foreach (FApplication fapplication in _client.ApplicationsList)
            {
                if (fapplication.Id == application.Id)
                {
                    fapplication.Name = application.Name;
                    fapplication.Ip = application.Ip;
                    fapplication.ConnectionState = application.ConnectionState;
                    fapplication.Description = application.Description;
                    fapplication.StartedUser = application.StartedUser;
                    fapplication.LastUser = application.LastUser;
                    fapplication.Owner = application.Owner;
                    fapplication.StartedDate = application.StartedDate;
                    fapplication.LastDate = application.LastDate;
                    fapplication.ServerVersion = application.ServerVersion;
                    fapplication.CreationDate = application.CreationDate;
                    fapplication.Description = application.Description;
                    return;
                }
            }
            _client.ApplicationsList.Add(application);
        }
        public void MsgServerInfo(String[] datas)
        {
            if (datas == null || datas.Count() != 5)
                return;
            int tmpowner;
            if (!int.TryParse(datas[3], out tmpowner))
                return;
            foreach (FUser fuser in _client.UsersList)
                if (fuser.Id == tmpowner)
                    _client.NewsOwner = fuser;
            _client.Name = datas[1];
            _client.News = datas[2];
            _client.ServerVersion = datas[4];
        }
        public void MsgApplicationHeader(String[] datas)
        {
            if (datas == null || datas.Count() != 5)
                return;
            _rmessage = datas[1];
        }
        public void MsgServerError(String[] datas)
        {
            if (datas == null || datas.Count() != 2)
                return;
            int tmp;
            if (!int.TryParse(datas[1], out tmp))
                return;
            _client.ConnectionState = EConnectionState.Error;
            _client.ErrorCode = tmp;
        }
        public void MsgUnreadable(String[] datas)
        {
            if (datas == null || datas.Count() != 2)
                return;
            Console.WriteLine(datas);
        }
    }
}
