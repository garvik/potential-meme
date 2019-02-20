using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseStartup<Startup>()
                .ConfigureKestrel(options =>
                 {
                     options.ListenLocalhost(5001, listenOptions =>
                     {
                         listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
                         listenOptions.UseHttps();
                     });
                     //options.Listen(IPAddress.Any, 8080, listenOptions =>
                     //{
                     //    listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
                     //    listenOptions.UseHttps();
                     //});
                 });
        }
    }
}
