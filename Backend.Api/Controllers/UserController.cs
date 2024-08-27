using Backend.Api.Dto;
using Backend.Service.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers;

[Route("user")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> Create([FromServices] ICreateUserService service, [FromBody] ICreateUserDto request)
    {
        try
        {
            await service.Execute(request.Name, request.Email, request.Password);
            return Ok(new { message = "User created successfully" });
        }
        catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
        {
            return BadRequest(new { message = ex.Message });
        }
        catch (Exception)
        {
            return BadRequest(new { message = "User creation failed" });
        }
    }
}
