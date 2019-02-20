using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

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
                .UseStartup<Startup>();
            //.ConfigureKestrel(options =>
            // {
            //     options.Listen(IPAddress.Any, 8080, listenOptions =>
            //     {
            //         listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
            //         listenOptions.UseHttps();
            //     });
            // });
        }
    }
}
