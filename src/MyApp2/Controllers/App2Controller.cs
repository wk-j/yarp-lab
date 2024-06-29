using Microsoft.AspNetCore.Mvc;

namespace MyApp2.Controller;

[Route("/api/app2")]
[ApiController]
public class App2Controller : ControllerBase
{

    [HttpGet("hello")]
    public string Hello()
    {
        return "Hello from App2!";
    }
}
