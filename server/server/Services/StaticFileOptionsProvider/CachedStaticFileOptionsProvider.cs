using Microsoft.AspNetCore.Builder;
using Microsoft.Net.Http.Headers;
using server.Services.StaticFileOptionsProvider;

namespace server
{
    public class CachedStaticFileOptionsProvider : IStaticFileOptionsProvider
    {
        private const int _cacheLifetimeInSeconds = 60 * 60 * 24 * 30; // 30 days

        public StaticFileOptions GetStaticFileOptions()
            => new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers[HeaderNames.CacheControl] =
                        "public, max-age=" + _cacheLifetimeInSeconds;
                }
            };
    }
}
