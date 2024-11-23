using MediatR;
using Product.API.Database;
using Product.API.Models;

namespace Product.API.UseCases.CreateProduct;

public sealed record CreateProductCommand(string name, decimal price, int stock) : IRequest<Products>;

internal sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Products>
{
    private readonly ApplicationDbContext dbContext;

    public CreateProductCommandHandler(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Products> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = Products.Create(request.name, request.price, request.stock);

        await dbContext.AddAsync(product, cancellationToken);

        await dbContext.SaveChangesAsync(cancellationToken); 

        return product;
    }
}
