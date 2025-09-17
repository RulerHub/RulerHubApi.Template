namespace RulerHub.Api.Domain.Entities.Stores;

public class Product : IEntity<Guid>
{
    public Guid Id { get; set; }
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
    public string Name { get; set; } = string.Empty!;
    public string Description { get; set; } = string.Empty!;
    public decimal Price { get; set; }
}