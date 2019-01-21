using FranpetteLib.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FranpetteLib.Serialisation.XMLSerialisation
{
    class XMLSerialisationApplication : ISerialisation
    {
        private String _name;
        private String _path;

        public XMLSerialisationApplication(String path, string name)
        {
            _path = path;
            _name = name;
        }

        public String GetFObjectType()
        {
            return "FApplication_" + _name;
        }

        public void Serialise(IFranpetteObject fobject)
        {

        }
        public IFranpetteObject Deserialise()
        {
            return new FApplication();
        }
    }
}
