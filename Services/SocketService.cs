using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using SocketServer.TCP;

namespace SocketServer.Services
{
    public class SocketService : IHostedService
    {
        private readonly IConfiguration configuration;
        public SocketService(IConfiguration config)
        {
            this.configuration = config;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var serverIPAddress = configuration.GetSection("TCPServer:IPAddress").Value;
            var serverPort = configuration.GetSection("TCPServer:Port").Value;

            if(!int.TryParse(serverPort, out int parsedPort))
            {
                Console.WriteLine("Bad port format, cannot start server.\nShutting down.");
                return Task.CompletedTask;
            }

            Thread t = new Thread(delegate ()
            {
                // replace the IP with your system IP Address...
                //Server myserver = new Server("192.168.***.***", 8081);
                Server myserver = new Server(serverIPAddress, parsedPort);
            });
            t.Start();

            Console.WriteLine("Server Started...!");

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}