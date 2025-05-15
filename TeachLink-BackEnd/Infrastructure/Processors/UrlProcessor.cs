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

        public string GetImagesUrl(string avatarId)
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext == null)
                throw new InvalidOperationException("No HttpContext available.");

            return _linkGenerator.GetUriByAction(
                    httpContext,
                    action: "GetAvatar",
                    controller: "Images",
                    values: new { avatar_id = avatarId }
                ) ?? throw new Exception("Could not generate media URL.");
        }
    }
}
