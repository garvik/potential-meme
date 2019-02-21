using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System;
using System.Net;

namespace server.Services
{
    public class LocalhostListenOptionsProvider : IListenOptionsProvider
    {
        public string GetEnvironmentName() => EnvironmentNames.Development;

        public IPAddress GetIPAddress() => IPAddress.Parse("127.0.0.1");

        public Action<ListenOptions> GetListenOptions()
            => listenOptions =>
            {
                listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
                listenOptions.UseHttps();
            };

        public int GetPort() => 5001;
    }
}
