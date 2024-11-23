namespace Contracts;

public sealed record ProductCreatedEvent
{
    public Guid Id { get; set; }
    public DateTime CreatedOnUtc{ get; set; }
}