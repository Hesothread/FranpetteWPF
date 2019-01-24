using FranpetteLib.Model;
using System;
using System.Collections.Generic;

namespace FranpetteLib.Serialisation
{
    public interface ISerialisation
    {
        String GetFType();

        void Serialise(IFranpetteObject fobject, String path);
        IFranpetteObject Deserialise(String path);
    }
}
