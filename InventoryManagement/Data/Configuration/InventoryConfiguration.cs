using InventoryManagement.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.Data.Configuration;

public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> builder)
    {
        builder.ToTable("Inventory");
        builder.HasKey(x=> x.Id);
        builder.Property(x=> x.Quantity).IsRequired();
        builder.HasOne(x=> x.Product).WithMany(x=> x.Inventories).HasForeignKey(x=> x.ProductId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.WareHouse).WithMany(x => x.Inventories).HasForeignKey(x => x.WareHouseId);
    }
}
