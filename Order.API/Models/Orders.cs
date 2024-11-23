namespace Order.API.Models;

public sealed class Orders
{
    public Orders(List<Guid> productIds)
    {
        Id = Guid.NewGuid();
        TotalPrice = 0;
        ProductIds = productIds;
        CreatedOn = DateTime.UtcNow;
    }

    private Orders() { }

    public Guid Id { get; }
    public decimal TotalPrice { get; private set; }
    public List<Guid> ProductIds { get; private set; } = [];
    public DateTime CreatedOn { get; }

    public static Orders Create(List<Guid> productIds)
    {
        var order = new Orders(productIds);

        return order;
    }
}
