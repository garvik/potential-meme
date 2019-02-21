using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;

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
                    storeName: StoreName.My,
                    subject: _configuration["CERT_SUBJECT_NAME"],
                    allowInvalid: true);
            };

        public int GetPort() => 8080;
    }
}
