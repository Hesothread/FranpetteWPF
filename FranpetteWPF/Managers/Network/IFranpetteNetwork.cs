using System;
using System.ComponentModel;

namespace Franpette.Sources.Network
{
    public enum ETarget
    {
        FRANPETTE,
        MINECRAFT
    }
    
    interface IFranpetteNetwork
    {
        Boolean connect(String address);
        Boolean login(String login, String password);

        Boolean downloadFile(ETarget target, BackgroundWorker worker);
        Boolean uploadFile(ETarget target, BackgroundWorker worker);
    }
}
