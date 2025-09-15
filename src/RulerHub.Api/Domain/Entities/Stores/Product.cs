using RulerHub.Api.Core.Entities.Abstracts;

namespace RulerHub.Api.Core.Entities.Stores;

public class Product : IEntity<Guid>
{
    public Guid Id { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; } = default!;
    public string Name { get; set; } = string.Empty!;
    public string Description { get; set; } = string.Empty!;
    public decimal Price { get; set; }
}