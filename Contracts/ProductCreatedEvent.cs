namespace Contracts;

public record ProductCreatedEvent
{
    public Guid EventId { get; set; }
    public Guid ProductId { get; set; }
    public DateTime CreatedOnUtc{ get; set; }
}
