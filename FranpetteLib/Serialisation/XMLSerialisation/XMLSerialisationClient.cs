using FranpetteLib.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FranpetteLib.Serialisation.XMLSerialisation
{
    class XMLSerialisationClient : ISerialisation
    {
        public String GetFType()
        {
            return "FClient";
        }

        public void Serialise(IFranpetteObject fobject, String path)
        {

        }
        public IFranpetteObject Deserialise(String path)
        {
            return new FClient();
        }
    }
}
