using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using server.Services;
using System.Linq;

namespace server
{
    public class Program
    {
        public static void Main(string[] args)
            => CreateWebHostBuilder(args)
                .Build()
                .Run();

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
            => WebHost.CreateDefaultBuilder(args)
                .UseApplicationInsights()
                .UseKestrel()
                .UseStartup<Startup>()
                .ConfigureKestrel((webHost, options) =>
                 {
                     var listenOptionsProviders = options
                        .ApplicationServices
                        .GetServices<IListenOptionsProvider>();

                     var listenOptionsProvider = listenOptionsProviders
                        .SingleOrDefault(provider =>
                            provider.GetEnvironmentName() == webHost.HostingEnvironment.EnvironmentName);

                     if (listenOptionsProvider != null)
                     {
                         options.Listen(
                            listenOptionsProvider.GetIPAddress(),
                            listenOptionsProvider.GetPort(),
                            listenOptionsProvider.GetListenOptions());
                     }
                 });
    }
}
