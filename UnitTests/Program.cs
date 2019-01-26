using FranpetteLib.Model;
using FranpetteLib.Serialisation.XMLSerialisation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    class Program
    {
        static void Main(string[] args)
        {
            FClient client = XMLSerialisation.Serialise("franpette.xml");

            Console.WriteLine(client.Name);

            Console.ReadLine();
        }
    }
}
