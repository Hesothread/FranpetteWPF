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
        public string Path { get => _path; set => _path = value; }

        public XMLSerialisationApplication(String path, string name)
        {
            Path = path;
            _name = name;
        }

        public String GetFType()
        {
            return "FApplication_" + _name;
        }

        public void Serialise(IFranpetteObject fobject, String path)
        {
        }
        public IFranpetteObject Deserialise(String path)
        {
            return new FApplication();
        }
    }
}
