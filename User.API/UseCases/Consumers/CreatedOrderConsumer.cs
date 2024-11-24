using Contracts;
using MassTransit;
using User.API.Database;

namespace User.API.UseCases.Consumers;

public sealed class CreatedOrderConsumer : IConsumer<OrderCreatedEvent>
{
    private readonly ApplicationDbContext dbContext;

    public CreatedOrderConsumer(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
    {

        var orderEvent = new OrderCreatedEvent
        {
            EventId = context.Message.EventId,
            OrderId = context.Message.OrderId,
            CreatedOnUtc = context.Message.CreatedOnUtc,
        };

        await dbContext.AddAsync(orderEvent);

        await dbContext.SaveChangesAsync();
    }
}
