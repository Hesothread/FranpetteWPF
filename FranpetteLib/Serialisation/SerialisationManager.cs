using FranpetteLib.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FranpetteLib.Serialisation
{
    public class SerialisationFileManager
    {
        Dictionary<String, ISerialisation> _SerialisationList = new Dictionary<string, ISerialisation>();

        public void AddSerialisation(ISerialisation serialisation)
        {
            if (serialisation == null)
                return;
            String ftype = serialisation.GetFType();

            if (!_SerialisationList.ContainsKey(ftype))
                _SerialisationList.Add(ftype, serialisation);
        }
        public void RemoveSerialisation(String ftype)
        {
            if (ftype != null && _SerialisationList.ContainsKey(ftype))
                _SerialisationList.Remove(ftype);
        }
        public ISerialisation GetSerialisation(String ftype)
        {
            if (ftype != null && _SerialisationList.ContainsKey(ftype))
                return _SerialisationList[ftype];
            return null;
        }
        
        public void Serialisation(IFranpetteObject fobject, String path)
        {
            if (fobject == null)
                return;
            String ftype = fobject.GetFType();
        
            if (_SerialisationList.ContainsKey(ftype))
                _SerialisationList[ftype].Serialise(fobject, path);
        }
        public void ForceSerialisation(IFranpetteObject fobject, String path, String ftype)
        {
            if (fobject != null && ftype != null && _SerialisationList.ContainsKey(ftype))
                _SerialisationList[ftype].Serialise(fobject, path);
        }
        public IFranpetteObject Deserialisation(String ftype, String path)
        {
            if (ftype != null && _SerialisationList.ContainsKey(ftype))
                return _SerialisationList[ftype].Deserialise(path);
            return null;
        }
        public IFranpetteObject Deserialisation(IFranpetteObject fobject, String path)
        {
            if (fobject == null)
                return null;
            String ftype = fobject.GetFType();

            if (_SerialisationList.ContainsKey(ftype))
                return _SerialisationList[ftype].Deserialise(path);
            return null;
        }
    }
}
