using MediatR;
using Microsoft.AspNetCore.Mvc;
using Product.API.UseCases.CreateProduct;
using Product.API.UseCases.GetAllProducts;

namespace Product.API.Controllers;

[Route("api/[Controller]")]
[ApiController]
public sealed class ProductsController(ISender sender) : ControllerBase
{
    [HttpPost("Create")]
    public async Task<IActionResult> Create(CreateProductCommand request) => Ok(await sender.Send(request));

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll() => Ok(await sender.Send(new GetAllProductsQuery()));
}
