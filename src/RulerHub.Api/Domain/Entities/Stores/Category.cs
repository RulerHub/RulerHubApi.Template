namespace RulerHub.Api.Domain.Entities.Stores;

public class Category : IEntity<int>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty!;
    public string Description { get; set; } = string.Empty!;
    public IEnumerable<Product>? Products { get; set; } = [];
}
