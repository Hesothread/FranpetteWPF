using FranpetteLib.Model;
using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;

namespace FranpetteLib.Serialisation
{
    public class LangManager
    {
        ResourceManager _resourceManager = new ResourceManager("FranpetteLib.LangManager", typeof().Assembly);
        Dictionary<String, ISerialisation> _SerialisationList = new Dictionary<string, ISerialisation>();

        public void AddSerialisation(ISerialisation serialisation)
        {
            if (serialisation == null)
                return;
            String ftype = serialisation.GetFObjectType();

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
        
        public void Serialisation(IFranpetteObject fobject)
        {
            if (fobject == null)
                return;
            String ftype = fobject.GetFType();

            if (_SerialisationList.ContainsKey(ftype))
                _SerialisationList[ftype].Serialise(fobject);
        }
        public void ForceSerialisation(IFranpetteObject fobject, String ftype)
        {
            if (fobject != null && ftype != null && _SerialisationList.ContainsKey(ftype))
                _SerialisationList[ftype].Serialise(fobject);
        }
        public IFranpetteObject Deserialisation(String ftype)
        {
            if (ftype != null && _SerialisationList.ContainsKey(ftype))
                return _SerialisationList[ftype].Deserialise();
            return null;
        }
        public IFranpetteObject Deserialisation(IFranpetteObject fobject)
        {
            if (fobject == null)
                return null;
            String ftype = fobject.GetFType();

            if (_SerialisationList.ContainsKey(ftype))
                return _SerialisationList[ftype].Deserialise();
            return null;
        }
    }
}
