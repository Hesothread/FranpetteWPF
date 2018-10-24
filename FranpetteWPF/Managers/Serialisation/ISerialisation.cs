using System;
using System.Collections.Generic;

namespace FranpetteWPF.Managers.Serialisation
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

    interface ISerialisation
    {
        Boolean Serialise();
        Boolean Deserialise(String fineName);

        Dictionary<EInfo, String> getInfoValue();
        void setInfoValue(Dictionary<EInfo, String> val);
        String getFileName();
    }
}
