namespace Contracts;

public sealed record UserCreatedEvent
{
    public Guid EventId { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedOnUtc { get; set; }
}
