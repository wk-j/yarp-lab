using Microsoft.AspNetCore.Mvc;
using MyProxy.Service.Jwt;

namespace MyProxy.Controllers.App;


public record UserInfo(
    string UserId,
    string[] Roles
);

[Route("api/app")]
[ApiController]
public class AppController : ControllerBase
{
    [HttpGet("generate-key")]
    public string GenerateKey([FromServices] JwtService jwt)
    {
        return jwt.GenerateJwtKey();
    }

    [HttpPost("generate-jwt-token")]
    public string GenerateJwtToken([FromServices] JwtService jwt, [FromBody] UserInfo info)
    {
        return jwt.GenerateJwtToken(info.UserId, info.Roles);
    }
}
