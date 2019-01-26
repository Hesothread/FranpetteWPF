using FranpetteLib.Model;
using FranpetteLib.Serialisation.XMLSerialisation;
using FranpetteWPFClient.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTests
{
    class Program
    {
        static void Main(string[] args)
        {
            //FClient client = XMLSerialisation.Serialise("franpette.xml");

            NetworkClient nclient = new NetworkClient();
            FClient client = nclient.Connect("82.243.249.234", 4242);
            nclient.Login("plop", "totito");
            nclient.GetApplicationsList();
            Console.WriteLine(client.Name);

            Console.ReadLine();
            Thread.Sleep(20000);
        }
    }
}
