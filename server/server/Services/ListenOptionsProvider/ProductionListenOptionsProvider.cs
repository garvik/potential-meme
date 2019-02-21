using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;

namespace server.Services.ListenOptionsProvider
{
    public class ProductionListenOptionsProvider : IListenOptionsProvider
    {
        private readonly IConfiguration _configuration;

        public ProductionListenOptionsProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetEnvironmentName() => EnvironmentNames.Production;

        public IPAddress GetIPAddress() => IPAddress.Any;

        public Action<ListenOptions> GetListenOptions()
            => listenOptions =>
            {
                listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
                listenOptions.UseHttps(
                    "production_cert.pfx",
                    _configuration["KESTREL_HTTPS_CERT_PASSWORD"]);
            };

        public int GetPort() => 8080;
    }
}
