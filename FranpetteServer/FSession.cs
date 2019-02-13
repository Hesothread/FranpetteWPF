using FranpetteLib.Model;
using FranpetteLib.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace FranpetteServer
{
    class FSession
    {
        public char SEPARATOR = ':';

        private FClient _server;
        private FClient _client;
        private UdpClient _udpClient;
        private IPEndPoint _ipClient;
        
        public void Daemon(FClient server, IPEndPoint sender, UdpClient udpClient, string rmessage)
        {
            _server = server;
            _ipClient = sender;
            _udpClient = udpClient;
            ERequestPacket code;
            _client = new FClient();
            _client.CurrentUser = new FUser();
            _client.CurrentUser.Name = "UnknowUser";
            String[] rawsData = rmessage.Split(SEPARATOR);

            if (!Enum.TryParse(rawsData[0], out code))
                return;

            if (code != ERequestPacket.SERV_CONECT)
                return;
            _client.Ip = _ipClient.Address.ToString();
            _client.ServerPort = _ipClient.Port;
            MsgServConnect(rawsData);
            while (_client.ConnectionState == EConnectionState.Connected)
            {
                byte[] pdata = _udpClient.Receive(ref _ipClient);
                rmessage = Encoding.ASCII.GetString(pdata);
                rawsData = rmessage.Split(SEPARATOR);

                //decrypte rmessage -- if null return

                Console.WriteLine("Client " + _client.CurrentUser.Name + " : " + rmessage);

                Enum.TryParse(rawsData[0], out code);

                switch (code)
                {
                    case ERequestPacket.APPLICATION_GET:
                        MsgApplicationGet(rawsData);
                        break;
                    case ERequestPacket.APPLICATION_GETHEADER:
                        MsgApplicationGetHeader(rawsData);
                        break;
                    case ERequestPacket.APPLICATION_GETLIST:
                        MsgApplicationGetList(rawsData);
                        break;
                    case ERequestPacket.APPLICATION_SET:
                        MsgApplicationSet(rawsData);
                        break;
                    case ERequestPacket.AUTH_LOGIN:
                        MsgAuthLogin(rawsData);
                        break;
                    case ERequestPacket.AUTH_LOGOUT:
                        MsgAuthLogout(rawsData);
                        break;
                    case ERequestPacket.INFO_GET:
                        MsgInfoGet(rawsData);
                        break;
                    case ERequestPacket.INFO_SET:
                        MsgInfoSet(rawsData);
                        break;
                    case ERequestPacket.SERV_DISCONECT:
                        MsgServDisconect(rawsData);
                        break;
                    case ERequestPacket.USER_GET:
                        MsgUserGet(rawsData);
                        break;
                    case ERequestPacket.USER_GETLIST:
                        MsgUserGetList(rawsData);
                        break;
                    case ERequestPacket.USER_SET:
                        MsgUserSet(rawsData);
                        break;
                    default:
                        MsgUnreadable(rawsData);
                        break;
                }
            }
        }

        public void MsgApplicationGet(String[] datas)
        {
            if (datas == null || datas.Count() != 3)
                return;
        }
        public void MsgApplicationGetHeader(String[] datas)
        {
            if (datas == null || datas.Count() != 1)
                return;
        }
        public void MsgApplicationGetList(String[] datas)
        {
            if (datas == null || datas.Count() != 2)
                return;
            int tmp;
            if (!int.TryParse(datas[1], out tmp))
                return;
        }
        public void MsgApplicationSet(String[] datas)
        {
            if (datas == null || datas.Count() != 1)
                return;
        }
        public void MsgAuthLogin(String[] datas)
        {

        }
        public void MsgAuthLogout(String[] datas)
        {

        }
        public void MsgInfoGet(String[] datas)
        {
        }
        public void MsgInfoSet(String[] datas)
        {
            if (datas == null || datas.Count() != 2)
                return;
            int tmp;
            if (!int.TryParse(datas[1], out tmp))
                return;
            _client.ConnectionState = EConnectionState.Error;
            _client.ErrorCode = tmp;
        }
        public void MsgServConnect(String[] datas)
        {
            string smessage;
            byte[] data;
            string version = "toto\n";

            if (datas == null || datas.Count() != 2)
                return;
            if (datas[1] != version)
            {
                smessage = EResponsePacket.SERVER_ERROR + SEPARATOR + "Version differ   your : " + datas[1] + "current : " + version;
                data = Encoding.ASCII.GetBytes(smessage);
                _udpClient.Send(data, data.Length, _ipClient);
                _client.ConnectionState = EConnectionState.Disconnected;
                Console.WriteLine("Client : Disconnected - version differ");
                return;
            }
            smessage = EResponsePacket.SERV_CONECTED + SEPARATOR + version + SEPARATOR + _server.Name;
            data = Encoding.ASCII.GetBytes(smessage);
            _udpClient.Send(data, data.Length, _ipClient);
            _client.ConnectionState = EConnectionState.Connected;
            Console.WriteLine("Client : Connected");
            return;
        }
        public void MsgServDisconect(String[] datas)
        {
            if (datas == null || datas.Count() != 2)
                return;
            int tmp;
            if (!int.TryParse(datas[1], out tmp))
                return;
            _client.ConnectionState = EConnectionState.Error;
            _client.ErrorCode = tmp;
        }
        public void MsgUserGet(String[] datas)
        {
            if (datas == null || datas.Count() != 2)
                return;
            int tmp;
            if (!int.TryParse(datas[1], out tmp))
                return;
            _client.ConnectionState = EConnectionState.Error;
            _client.ErrorCode = tmp;
        }
        public void MsgUserGetList(String[] datas)
        {
            if (datas == null || datas.Count() != 2)
                return;
            int tmp;
            if (!int.TryParse(datas[1], out tmp))
                return;
            _client.ConnectionState = EConnectionState.Error;
            _client.ErrorCode = tmp;
        }
        public void MsgUserSet(String[] datas)
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
