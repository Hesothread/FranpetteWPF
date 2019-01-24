using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FranpetteWPF.Managers.Network
{
    private enum EResponsePacket
    {
        CLIENT_CONECTED,
        CLIENT_PING,
        CLIENT_DISCONECTED,

        USER_PING,
        USER_LOGED,
        USER_DISCONNECTED,

    }
    private enum ERequestPacket
    {
        CLIENT_CONECTED,
        CLIENT_PING,
        CLIENT_DISCONECTED,

        USER_PING,
        USER_LOGED,
        USER_DISCONNECTED,

    }

    public class NetworkClient
    {
        FClient _client = new FClient();

        private const int portNum = 13;
        private const string hostName = "host.contoso.com";

        public FClient Connect(String addresse)
        {

            try
            {
                TcpClient client = new TcpClient(hostName, portNum);

                NetworkStream ns = client.GetStream();

                byte[] bytes = new byte[1024];
                int bytesRead = ns.Read(bytes, 0, bytes.Length);

                Console.WriteLine(Encoding.ASCII.GetString(bytes, 0, bytesRead));

                client.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return 0;
        }
        private void FranpetteDaemon();
        public void Disconnect();

        public FUser Login(String login, String password);
        public void Logout();
        
        public List<FUser> GetUsersList();
        public FClient GetServerInfo();

        public List<FApplication> GetApplicationsList();
        public Boolean RefreshApplicationList();
        public Boolean RefreshApplication(FApplication application);

        public Boolean StartApplication(FApplication application);
        public Boolean StopApplication(FApplication application);
    }
}
