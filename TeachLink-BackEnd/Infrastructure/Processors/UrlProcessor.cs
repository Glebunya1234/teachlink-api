using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using TeachLink_BackEnd.Core.Processors;

namespace TeachLink_BackEnd.Infrastructure.Processors
{
    public class UrlProcessor(IHttpContextAccessor httpContextAccessor, LinkGenerator linkGenerator)
        : IUrlProcessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        private readonly LinkGenerator _linkGenerator = linkGenerator;

        public string GetMediaUrl(string blobName)
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext == null)
                throw new InvalidOperationException("No HttpContext available.");

            return _linkGenerator.GetUriByAction(
                    httpContext,
                    action: "GetMedia",
                    controller: "Media",
                    values: new { fileName = blobName }
                ) ?? throw new Exception("Could not generate media URL.");
        }
    }
}
