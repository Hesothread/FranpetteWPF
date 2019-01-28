using FranpetteLib.Model;
using FranpetteLib.Serialisation.XMLSerialisation;
using FranpetteLib.JsonManager;
using FranpetteClient.Network;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FranpetteLib.Network;
using System.Net;
using System.Net.Sockets;

namespace UnitTests
{
    class Program
    {
        static public char SEPARATOR = ':';

        static void Main(string[] args)
        {
            //FClient client = XMLSerialisation.Serialise("franpette.xml");
            deshtros();
            Console.ReadLine();
        }

        static void deshtros()
        {
            NetworkClient nclient = new NetworkClient();

            FClient client = nclient.Connect("82.243.249.234", 4245);
            nclient.Login("plop", "totito");
            nclient.DowloadApplication(new FApplication() { Id = 2 }, "D:\\Projet\\Hesothread\\ranpetteWPF\\AppTest");
            Console.WriteLine("End");
        }

        static UdpClient _udpClient;

        static void manustrozor()
        {
            int port = 4245;
            String address = "86.238.58.47";
            FClient client = new FClient();
            client.ServerAddress = address;
            client.ServerPort = port;
            client.Ip = new WebClient().DownloadString("http://icanhazip.com");

            _udpClient = new UdpClient(port);
            IPAddress[] addressesIP = Dns.GetHostAddresses(address);
            IPEndPoint groupEP = new IPEndPoint(addressesIP[0], port);
            _udpClient.Connect(address, port);


            Console.WriteLine("Send msg 1");
            sendMessage(EResponsePacket.SERV_CONECTED.ToString() + SEPARATOR + "Toto");
            Console.ReadLine();
            Console.WriteLine("Send msg 2");
            sendMessage(EResponsePacket.AUTH_CONNECT.ToString() + SEPARATOR + 42);
            Console.ReadLine();
            Console.WriteLine("Send msg 3");
            Console.ReadLine();
        }


        static private void sendMessage(String message)
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
    }
}
