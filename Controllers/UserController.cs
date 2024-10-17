using Api.Models;
using Api.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> Create([FromServices] CreateUserService service, [FromBody] CreateUserRequest data)
    {
        try
        {
            await service.Execute(data.Name, data.Email, data.Password);
            return Ok("User created successfully");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult> All([FromServices] GetUsersService service)
    {
        try
        {
            var users = await service.Execute();
            return Ok(users);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> Get([FromServices] GetUserService service, int id)
    {
        try
        {
            var user = await service.Execute(id);
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Update([FromServices] UpdateUserService service, [FromBody] UpdateUserRequest data, int id)
    {
        try
        {
            await service.Execute(id, data.Name, data.Email, data.Password);
            return Ok("Updated successfully");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Remove([FromServices] RemoveUserService service, int id)
    {
        try
        {
            await service.Execute(id);
            return Ok("Removed successfully");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
