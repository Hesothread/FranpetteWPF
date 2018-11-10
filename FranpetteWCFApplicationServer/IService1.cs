using FranpetteWCFServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace FranpetteWCFServer
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        // Credential
        [OperationContract] ServerInfo Connect(String Addresse);

        [OperationContract] UserInfo LogIn(String Username, String Password);
        [OperationContract] Boolean LogOut(String Message);

        // User Service
        [OperationContract] List<UserInfo> GetUserList();
        [OperationContract] Boolean GetUserInfo(int UserId);
        [OperationContract] Boolean SetUserInfo(UserInfo User);

        [OperationContract] Boolean SendMessage(int UserId);

        // Server service
        [OperationContract] ServerInfo GetServerInfo();
        [OperationContract] ServerInfo SetServerInfo(ServerInfo Server);

        [OperationContract] String GetWelcome();
        [OperationContract] void SetWelcome(String Message);

        // Application service
        [OperationContract] List<ApplicationInfo> GetApplicationList();
        [OperationContract] ApplicationInfo GetApplicationInfo(int Id);
        [OperationContract] ApplicationInfo SetApplicationInfo(ApplicationInfo Application);

        [OperationContract] ApplicationInfo AddApplication(ApplicationInfo Application);
        [OperationContract] Boolean RemoveApplication(int Id);

        [OperationContract] ApplicationInfo ApplicationStarted(int Id, int UserId);
        [OperationContract] ApplicationInfo ApplicationStoped(int Id, int UserId);

       

        // TODO: ajoutez vos opérations de service ici
    }
}
