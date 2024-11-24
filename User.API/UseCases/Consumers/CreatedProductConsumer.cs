using Contracts;
using MassTransit;
using User.API.Database;

namespace User.API.UseCases.Consumers;

public class CreatedProductConsumer : IConsumer<ProductCreatedEvent>
{
    private readonly ApplicationDbContext dbContext;

    public CreatedProductConsumer(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task Consume(ConsumeContext<ProductCreatedEvent> context)
    {
        var orderEvent = new OrderCreatedEvent
        {
            EventId = context.Message.EventId,
            OrderId = context.Message.ProductId,
            CreatedOnUtc = context.Message.CreatedOnUtc,
        };

        await dbContext.AddAsync(orderEvent);

        await dbContext.SaveChangesAsync();
    }
}
