using Microsoft.AspNetCore.Builder;

namespace server.Services.StaticFileOptionsProvider
{
    internal interface IStaticFileOptionsProvider
    {
        StaticFileOptions GetStaticFileOptions();
    }
}
