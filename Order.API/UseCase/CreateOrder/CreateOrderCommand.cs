using Contracts;
using MassTransit;
using MediatR;
using Order.API.Database;
using Order.API.Models;

namespace Order.API.UseCase.CreateOrder;

public sealed record CreateOrderCommand(List<Guid> ProductIds) : IRequest<Orders>;

internal sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Orders>
{
    private readonly IPublishEndpoint publishEndpoint;
    private readonly ApplicationDbContext dbContext;

    public CreateOrderCommandHandler(IPublishEndpoint publishEndpoint, ApplicationDbContext dbContext)
    {
        this.publishEndpoint = publishEndpoint;
        this.dbContext = dbContext;
    }

    public async Task<Orders> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = Orders.Create(request.ProductIds);

        await dbContext.AddAsync(order);

        await dbContext.SaveChangesAsync(cancellationToken);

        await publishEndpoint.Publish(new OrderCreatedEvent
        {
            EventId = Guid.NewGuid(),
            OrderId = order.Id,
            CreatedOnUtc = DateTime.UtcNow,
        }, cancellationToken);

        return order;
    }
}
