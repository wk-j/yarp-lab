using Microsoft.AspNetCore.Mvc;

namespace MyApp1.Controller;

[Route("api/app1")]
[ApiController]
public class App1Controller : ControllerBase
{
    [HttpGet("hello")]
    public string Hello()
    {
        return "Hello from App1!";
    }
}
