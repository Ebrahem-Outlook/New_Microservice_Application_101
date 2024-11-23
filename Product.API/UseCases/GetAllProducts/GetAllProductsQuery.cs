using MediatR;
using Microsoft.EntityFrameworkCore;
using Product.API.Database;
using Product.API.Models;

namespace Product.API.UseCases.GetAllProducts;

public sealed record GetAllProductsQuery() : IRequest<List<Products>>;

internal sealed class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<Products>>
{
    private readonly ApplicationDbContext dbContext;

    public GetAllProductsQueryHandler(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<List<Products>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        return await dbContext.Products.ToListAsync(cancellationToken);
    }
}
