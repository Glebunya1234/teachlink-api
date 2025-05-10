using TeachLink_BackEnd.Infrastructure.GlobalHendelrs;

namespace TeachLink_BackEnd.Core.Helpers
{
    public class CheckAuthHelper
    {
        public static string GetTokenFromHeader(HttpRequest request)
        {
            var token = request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if (string.IsNullOrEmpty(token))
            {
                throw new UnauthorizedException("Authorization token is missing.");
            }
            return token;
        }
    }
}
