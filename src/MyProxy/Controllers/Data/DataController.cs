using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyProject.Controllers.Data;

[Route("api/data")]
[ApiController]
public class DataController : ControllerBase
{
    [HttpGet("admin-data")]
    [Authorize(Roles = "Admin")]
    public string AdminData()
    {
        return "Admin data";
    }

    [HttpGet("user-data")]
    [Authorize(Roles = "User")]
    public string UserData()
    {
        return "User data";
    }
}
