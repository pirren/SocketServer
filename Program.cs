using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SocketServer.DataAccess;
using SocketServer.Services;

namespace SocketServer
{
    class Program
    {
        static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args) 
            => Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostCtx, configApp) => 
            {
                configApp.SetBasePath(Directory.GetCurrentDirectory());
                configApp.AddJsonFile("appsettings.Development.json");
            })
            .ConfigureServices((hostCtx, services) => 
            {
                services.AddSingleton(_ => hostCtx.Configuration);
                services.AddDbContext<OrderContext>(options => 
                    options.UseSqlServer(hostCtx.Configuration.GetConnectionString("DefaultConnection")));
                services.AddHostedService<SocketService>();
            });
    }
}
