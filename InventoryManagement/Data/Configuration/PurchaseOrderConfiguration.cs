using InventoryManagement.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.Data.Configuration;

public class PurchaseOrderConfiguration : IEntityTypeConfiguration<PurchaseOrder>
{
    public void Configure(EntityTypeBuilder<PurchaseOrder> builder)
    {
        builder.ToTable("Purchase_Order");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Status).HasConversion<int>();

        builder.HasOne(x => x.Supplier).WithMany(x => x.PurchaseOrder).HasForeignKey(x => x.SupplierId).OnDelete(DeleteBehavior.Restrict);
    }
}
