namespace JwtExamples.Domain;

public class Product
{
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public Product(Guid id, DateTime createdAt, string name, string description, decimal price)
    {
        Id = id;
        CreatedAt = createdAt;
        Name = name;
        Description = description;
        Price = price;
        ModifiedAt = null;
    }

    public void Update(string name, string description, decimal price)
    {
        Name = name;
        Description = description;
        Price = price;
    }
}