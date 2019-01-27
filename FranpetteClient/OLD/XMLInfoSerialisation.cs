using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using FranpetteLib.Model;

namespace FranpetteLib.Serialisation.XMLSerialisation
{
    enum EInfo
    {
        FRANPETTEVERSION,
        FRANPETTEMESSAGEOFTHEDAY,
        MINECRAFTVERSION,
        MINECRAFTUSER,
        MINECRAFTIP,
        MINECRAFTDATE,
        MINECRAFTSTATE
    }

    class XMLInfoSerialisation : ISerialisation
    {
        private XmlDocument                 _xmlInfo = new XmlDocument();
        private Dictionary<EInfo, String>   _fileValue;
        private String                      _path;

        public XMLInfoSerialisation(String path)
        {
            _path = path;
        }

        public String GetFObjectType()
        {
            return ("FServerInfo");
        }

        public void Serialise(IFranpetteObject fobject)
        {
            Utils.debug("[XMLInfoSerialisation] Serialise : " + _path);
            _xmlInfo.Load(_path);

            _xmlInfo.DocumentElement.SelectSingleNode("/root/franpette/version").InnerText = _fileValue[EInfo.FRANPETTEVERSION];
            _xmlInfo.DocumentElement.SelectSingleNode("/root/franpette/messageoftheday").InnerText = _fileValue[EInfo.FRANPETTEMESSAGEOFTHEDAY];

            _xmlInfo.DocumentElement.SelectSingleNode("/root/minecraft/version").InnerText = _fileValue[EInfo.MINECRAFTVERSION];
            _xmlInfo.DocumentElement.SelectSingleNode("/root/minecraft/state").InnerText = _fileValue[EInfo.MINECRAFTSTATE];
            _xmlInfo.DocumentElement.SelectSingleNode("/root/minecraft/date").InnerText = _fileValue[EInfo.MINECRAFTDATE];
            _xmlInfo.DocumentElement.SelectSingleNode("/root/minecraft/user").InnerText = _fileValue[EInfo.MINECRAFTUSER];
            _xmlInfo.DocumentElement.SelectSingleNode("/root/minecraft/ip").InnerText = _fileValue[EInfo.MINECRAFTIP];
            _xmlInfo.Save(_path);
        }

        public IFranpetteObject Deserialise()
        {
            _fileValue = new Dictionary<EInfo, string>();

            if (!File.Exists(_path))
            {
                Utils.debug("[XMLInfoSerialisation] Deserialise : " + _path + " was not found");
                return null;
            }
            _xmlInfo.Load(_path);
            
            _fileValue.Add(EInfo.FRANPETTEVERSION,          _xmlInfo.DocumentElement.SelectSingleNode("/root/franpette/version").InnerText);
            _fileValue.Add(EInfo.FRANPETTEMESSAGEOFTHEDAY,  _xmlInfo.DocumentElement.SelectSingleNode("/root/franpette/messageoftheday").InnerText);

            _fileValue.Add(EInfo.MINECRAFTVERSION,          _xmlInfo.DocumentElement.SelectSingleNode("/root/minecraft/version").InnerText);
            _fileValue.Add(EInfo.MINECRAFTSTATE,            _xmlInfo.DocumentElement.SelectSingleNode("/root/minecraft/state").InnerText);
            _fileValue.Add(EInfo.MINECRAFTDATE,             _xmlInfo.DocumentElement.SelectSingleNode("/root/minecraft/date").InnerText);
            _fileValue.Add(EInfo.MINECRAFTUSER,             _xmlInfo.DocumentElement.SelectSingleNode("/root/minecraft/user").InnerText);
            _fileValue.Add(EInfo.MINECRAFTIP,               _xmlInfo.DocumentElement.SelectSingleNode("/root/minecraft/ip").InnerText);

            Utils.debug("[XMLInfoSerialisation] Deserialise : " + _path + " ...Done");
            return new FServerInfo();
        }
    }
}
