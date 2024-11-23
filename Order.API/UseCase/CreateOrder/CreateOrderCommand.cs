using MediatR;
using Order.API.Database;
using Order.API.Models;

namespace Order.API.UseCase.CreateOrder;

public sealed record CreateOrderCommand(List<Guid> ProductIds) : IRequest<Orders>;

internal sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Orders>
{
    private readonly ApplicationDbContext dbContext;

    public CreateOrderCommandHandler(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Orders> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = Orders.Create(request.ProductIds);

        await dbContext.AddAsync(order);

        await dbContext.SaveChangesAsync(cancellationToken);

        return order;
    }
}
