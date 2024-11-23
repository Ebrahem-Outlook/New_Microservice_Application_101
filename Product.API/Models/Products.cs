namespace Product.API.Models;

public sealed class Products
{
    private Products(string name, decimal price, int stock)
    {
        Id = Guid.NewGuid();
        Name = name;
        Price = price;
        CreatedOn = DateTime.UtcNow;
        Stock = stock;
    }

    private Products() { }

    public Guid Id { get; }
    public string Name { get; private set; } = default!;
    public decimal Price{ get; private set; }
    public DateTime CreatedOn { get; private set; }
    public int Stock { get; private set; }

    public static Products Create(string name, decimal price, int stock)
    {
        var product = new Products(name, price, stock);

        return product;
    }
}
