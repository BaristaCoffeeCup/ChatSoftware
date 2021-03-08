using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Collections;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Server is running!");
     

            while (true)
            {
                RemoteClient remoteClient = new RemoteClient();
            }
        }

    }

    class GlobalParams
    {
        public static Database db = new Database();
    }
}
