using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RulerHub.Api.Infrastructure.Configuration.Stores;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Price).HasColumnType("decimal(18,2)");

        builder.HasIndex(x => x.Name);
        builder.HasIndex(x => x.Price);

        builder.HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(c => c.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property<DateTime>("CreatedAt");
        builder.Property<DateTime>("UpdatedAt");
    }
}
