using MediatR;
using Microsoft.AspNetCore.Mvc;
using User.API.UseCases.CreateUser;
using User.API.UseCases.GetAllUsers;

namespace User.API.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class UsersController(ISender sender) : ControllerBase
{
    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateUserCommand request) => Ok(await sender.Send(request));

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll() => Ok(await sender.Send(new GetAllUsersCommand()));
}
