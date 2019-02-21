using Microsoft.AspNetCore.Server.Kestrel.Core;
using System;
using System.Net;

namespace server.Services.ListenOptionsProvider
{
    internal interface IListenOptionsProvider
    {
        Action<ListenOptions> GetListenOptions();
        int GetPort();
        IPAddress GetIPAddress();
        string GetEnvironmentName();
    }
}
