using Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Order.API.Database;
using Order.API.UseCase.CreateOrder;
using Order.API.UseCase.GetAllOrders;

namespace Order.API.Controllers;

[Route("api/[Controller]")]
[ApiController]
public sealed class OrdersController(ISender sender, ApplicationDbContext dbContext) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderCommand request) => Ok(await sender.Send(request));

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await sender.Send(new GetAllOrderQuery()));




}
