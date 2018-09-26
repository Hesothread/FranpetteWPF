using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Franpette.Sources.Franpette;

namespace Franpette.Sources.Serialisation
{
    class XMLInfoSerialisation : ISerialisation
    {
        private XmlDocument _xmlInfo = new XmlDocument();
        private Dictionary<EInfo, String> _fileValue;
        private String      _fileName;

        public Boolean Serialise()
        {
            Utils.debug("[XMLInfoSerialisation] Serialise : " + _fileName);
            _xmlInfo.Load(_fileName);

            _xmlInfo.DocumentElement.SelectSingleNode("/root/franpette/version").InnerText = _fileValue[EInfo.FRANPETTEVERSION];
            _xmlInfo.DocumentElement.SelectSingleNode("/root/franpette/messageoftheday").InnerText = _fileValue[EInfo.FRANPETTEMESSAGEOFTHEDAY];

            _xmlInfo.DocumentElement.SelectSingleNode("/root/minecraft/version").InnerText = _fileValue[EInfo.MINECRAFTVERSION];
            _xmlInfo.DocumentElement.SelectSingleNode("/root/minecraft/state").InnerText = _fileValue[EInfo.MINECRAFTSTATE];
            _xmlInfo.DocumentElement.SelectSingleNode("/root/minecraft/date").InnerText = _fileValue[EInfo.MINECRAFTDATE];
            _xmlInfo.DocumentElement.SelectSingleNode("/root/minecraft/user").InnerText = _fileValue[EInfo.MINECRAFTUSER];
            _xmlInfo.DocumentElement.SelectSingleNode("/root/minecraft/ip").InnerText = _fileValue[EInfo.MINECRAFTIP];
            _xmlInfo.Save(_fileName);
            return true;
        }

        public Boolean Deserialise(String fineName)
        {
            _fileValue = new Dictionary<EInfo, string>();
            _fileName = fineName;

            if (!File.Exists(_fileName))
            {
                Utils.debug("[XMLInfoSerialisation] Deserialise : " + _fileName + " was not found");
                return false;
            }
            _xmlInfo.Load(_fileName);
            
            _fileValue.Add(EInfo.FRANPETTEVERSION,          _xmlInfo.DocumentElement.SelectSingleNode("/root/franpette/version").InnerText);
            _fileValue.Add(EInfo.FRANPETTEMESSAGEOFTHEDAY,  _xmlInfo.DocumentElement.SelectSingleNode("/root/franpette/messageoftheday").InnerText);

            _fileValue.Add(EInfo.MINECRAFTVERSION,          _xmlInfo.DocumentElement.SelectSingleNode("/root/minecraft/version").InnerText);
            _fileValue.Add(EInfo.MINECRAFTSTATE,            _xmlInfo.DocumentElement.SelectSingleNode("/root/minecraft/state").InnerText);
            _fileValue.Add(EInfo.MINECRAFTDATE,             _xmlInfo.DocumentElement.SelectSingleNode("/root/minecraft/date").InnerText);
            _fileValue.Add(EInfo.MINECRAFTUSER,             _xmlInfo.DocumentElement.SelectSingleNode("/root/minecraft/user").InnerText);
            _fileValue.Add(EInfo.MINECRAFTIP,               _xmlInfo.DocumentElement.SelectSingleNode("/root/minecraft/ip").InnerText);

            Utils.debug("[XMLInfoSerialisation] Deserialise : " + _fileName + " ...Done");
            return true;
        }

        public Dictionary<EInfo, String> getInfoValue()
        {
            return _fileValue;
        }

        public void setInfoValue(Dictionary<EInfo, String> val)
        {
            _fileValue = val;
        }

        public String getFileName()
        {
            return _fileName;
        }
    }
}
