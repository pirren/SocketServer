using System;
using System.Threading;

namespace SocketServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(delegate ()
            {
                // replace the IP with your system IP Address...
                //Server myserver = new Server("192.168.***.***", 8081);
                Server myserver = new Server("192.168.56.1", 15000);
            });
            t.Start();

            Console.WriteLine("Server Started...!");
        }
    }
}
