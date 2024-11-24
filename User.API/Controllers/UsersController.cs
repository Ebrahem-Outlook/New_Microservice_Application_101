using Contracts;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using User.API.Database;
using User.API.UseCases.CreateUser;
using User.API.UseCases.GetAllUsers;

namespace User.API.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class UsersController(ISender sender, ApplicationDbContext dbContext) : ControllerBase
{
    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateUserCommand request) => Ok(await sender.Send(request));

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll() => Ok(await sender.Send(new GetAllUsersCommand()));

    [HttpGet("GetAllProductsEvents")]
    public async Task<IActionResult> GetAllProductsEvents() => Ok(await dbContext.Set<ProductCreatedEvent>().ToListAsync());

    [HttpGet("GetAllOrdersEvents")]
    public async Task<IActionResult> GetAllOrdersEvents() => Ok(await dbContext.Set<OrderCreatedEvent>().ToListAsync());
}
