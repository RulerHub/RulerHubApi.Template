using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using RulerHub.Api.Domain.Entities.Stores;

namespace RulerHub.Api.Infrastructure.Configuration.Stores;

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

        builder.Property<DateTime>("CreatedAt");
        builder.Property<DateTime>("UpdatedAt");
    }
}
