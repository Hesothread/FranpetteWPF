using FranpetteLib.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FranpetteLib.Serialisation.XMLSerialisation
{
    class XMLSerialisationClient : ISerialisation
    {
        private String _path;

        public XMLSerialisationClient(String path)
        {
            _path = path;
        }
        public String GetFObjectType()
        {
            return "FClient";
        }

        public void Serialise(IFranpetteObject fobject)
        {

        }
        public IFranpetteObject Deserialise()
        {
            return new FClient();
        }
    }
}
