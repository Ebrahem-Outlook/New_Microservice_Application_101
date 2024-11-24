namespace Contracts;

public sealed record OrderCreatedEvent
{
    public Guid EventId { get; set; }
    public Guid OrderId { get; set; }
    public DateTime CreatedOnUtc { get; set; }   
}
