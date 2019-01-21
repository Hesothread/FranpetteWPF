using System;
using System.Collections.Generic;
using System.Text;

namespace FranpetteLib.Model
{
    public enum EConnectionState
    {
        Connected = 1,
        Disconnected = 2,
        Error = 0
    };

    public interface IFranpetteObject
    {
        String GetFType();
        int GetId();
    }
}
