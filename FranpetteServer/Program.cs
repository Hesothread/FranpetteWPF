using System;

namespace FranpetteServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            FranpetteDaemon daemon = new FranpetteDaemon();
            daemon.StartDaemon();
            Console.WriteLine("Good bye World!");
        }
    }
}
