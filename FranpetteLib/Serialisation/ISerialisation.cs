using FranpetteLib.Model;
using System;
using System.Collections.Generic;

namespace FranpetteLib.Serialisation
{
    public interface ISerialisation
    {
        String GetFObjectType();

        void Serialise(IFranpetteObject fobject);
        IFranpetteObject Deserialise();
    }
}
