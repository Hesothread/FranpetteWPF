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

        // Server service
        [OperationContract] ServerInfo GetServerInfo();
        [OperationContract] String GetWelcome();
        [OperationContract] void SetWelcome(String Message);

        // Application service
        [OperationContract] List<ApplicationInfo> GetApplicationList();

        [OperationContract] ApplicationInfo GetApplicationInfo(String Name);
        [OperationContract] ApplicationInfo GetApplicationInfo(int Id);
        [OperationContract] ApplicationInfo SetApplicationInfo(ApplicationInfo Application);

        [OperationContract] ApplicationInfo ApplicationStarted(int Id);
        [OperationContract] ApplicationInfo ApplicationStoped(int Id);

       

        // TODO: ajoutez vos opérations de service ici
    }
}
