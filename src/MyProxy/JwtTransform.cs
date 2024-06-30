namespace MyProxy;

using System.Security.Claims;
using Yarp.ReverseProxy.Transforms;

internal class JwtTransform() : RequestTransform
{
    public override ValueTask ApplyAsync(RequestTransformContext context)
    {
        var headers = context.ProxyRequest.Headers;
        var bearerToken = context.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

        if (!String.IsNullOrEmpty(bearerToken))
        {
            var jwtHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var jwtToken = jwtHandler.ReadJwtToken(bearerToken);

            var claims = jwtToken.Claims;
            var userId = claims.FirstOrDefault(c => c.Type == "sub")?.Value;
            var userName = claims.FirstOrDefault(c => c.Type == "name")?.Value;
            var roles = claims.Where(c => c.Type == ClaimTypes.Role);
            var ticket = claims.FirstOrDefault(c => c.Type == "x-user-ticket")?.Value;

            if (!string.IsNullOrEmpty(userId))
            {
                context.ProxyRequest.Headers.Add("X-User-Id", userId);
            }

            if (!string.IsNullOrEmpty(userName))
            {
                context.ProxyRequest.Headers.Add("X-User-Name", userName);
            }

            if (!string.IsNullOrEmpty(ticket))
            {
                context.ProxyRequest.Headers.Add("X-User-Ticket", ticket);
            }

            foreach (var role in roles)
            {
                context.ProxyRequest.Headers.Add("X-User-Role", role.Value);
            }
        }

        return new ValueTask();
    }
}
