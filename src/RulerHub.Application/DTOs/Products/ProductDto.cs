namespace RulerHub.Application.DTOs.Products;

public class ProductDto(Guid id, string name, decimal price, DateTime createdAt, DateTime? updatedAt)
{
    public Guid Id { get; set; } = id;
    public string Name { get; set; } = name;
    public decimal Price { get; set; } = price;
    public DateTime CreatedAt { get; set; } = createdAt;
    public DateTime? UpdatedAt { get; set; } = updatedAt;
}
