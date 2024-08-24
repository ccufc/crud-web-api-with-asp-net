using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers;

[Route("user")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpGet]
    public ActionResult Hello()
    {
        return Ok("Hello /user!");
    }
}
