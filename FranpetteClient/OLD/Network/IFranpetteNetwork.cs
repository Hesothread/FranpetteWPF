﻿using System;
using System.ComponentModel;

namespace FranpetteWPF.Managers.Network
{
    interface IFranpetteNetwork
    {
        Boolean connect(String address);
        Boolean login(String login, String password);

        Boolean downloadFile(ETarget target, BackgroundWorker worker);
        Boolean uploadFile(ETarget target, BackgroundWorker worker);
    }
}