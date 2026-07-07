using InventoryManagement.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.Data.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.Property(x => x.ProductName).IsRequired().HasMaxLength(50);
        builder.HasKey(x=> x.Id);
        builder.Property(x => x.MinAlert).HasDefaultValue(10);

        builder.HasOne(x => x.ProductCategories).WithMany(x => x.Products).HasForeignKey(x=> x.CategoryId);

        builder.HasOne(x => x.Supplier).WithMany(x => x.Products).HasForeignKey(x => x.SupplierId);


    }
}
