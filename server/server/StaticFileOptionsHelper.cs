using Microsoft.AspNetCore.Builder;
using Microsoft.Net.Http.Headers;

namespace server
{
    public static class StaticFileOptionsHelper
    {
        public static StaticFileOptions GetOptionsWithCache()
        {
            return new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    const int durationInSeconds = 60 * 60 * 24;
                    ctx.Context.Response.Headers[HeaderNames.CacheControl] =
                        "public,max-age=" + durationInSeconds;
                }
            };
        }
    }
}
