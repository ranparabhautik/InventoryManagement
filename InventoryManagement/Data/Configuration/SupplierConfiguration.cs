using InventoryManagement.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.Data.Configuration;

public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.ToTable("Supplier");
        builder.HasKey(x=> x.Id);
        builder.Property(x => x.SupplierAddress).IsRequired().HasMaxLength(200);
        builder.Property(x => x.SupplierPhoneNo).HasMaxLength(10);
    }
}
