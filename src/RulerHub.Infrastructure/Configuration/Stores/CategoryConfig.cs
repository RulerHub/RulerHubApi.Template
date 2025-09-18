using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using RulerHub.Domain.Entities.Stores;

namespace RulerHub.Infrastructure.Configuration.Stores;

public class CategoryConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);

        builder.HasIndex(x => x.Name);

        builder.HasMany(p => p.Products)
            .WithOne(c => c.Category)
            .HasForeignKey(c => c.CategoryId);

        builder.Property<DateTime>("CreatedAt").IsRequired(true);
        builder.Property<DateTime?>("UpdatedAt").IsRequired(false);
    }
}
