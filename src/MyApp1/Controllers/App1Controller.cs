using Microsoft.AspNetCore.Mvc;

namespace MyApp1.Controller;

[Route("api/app1")]
[ApiController]
public class App1Controller(ILogger<App1Controller> logger) : ControllerBase
{
    [HttpGet("hello")]
    public string Hello(
        [FromHeader(Name = "X-User-Role")] string[] roles,
        [FromHeader(Name = "X-User-Id")] string userId,
        [FromHeader(Name = "X-User-Ticket")] string ticket)
    {
        logger.LogInformation("User ID: {userId}", userId);
        logger.LogInformation("User Ticket: {ticket}", ticket);

        foreach (var role in roles)
        {
            logger.LogInformation("Role: {role}", role);
        }

        return "Hello from App1!";
    }
}
