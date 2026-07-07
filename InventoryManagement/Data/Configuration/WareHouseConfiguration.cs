using InventoryManagement.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.Data.Configuration;

public class WareHouseConfiguration : IEntityTypeConfiguration<WareHouse>
{
    void IEntityTypeConfiguration<WareHouse>.Configure(EntityTypeBuilder<WareHouse> builder)
    {
        builder.ToTable("WareHouse");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.WareHouseName).IsRequired().HasMaxLength(150);
        builder.Property(x => x.WareHouseLocation).IsRequired().HasMaxLength(200);
    }
}
