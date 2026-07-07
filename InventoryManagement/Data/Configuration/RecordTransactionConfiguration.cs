using InventoryManagement.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.Data.Configuration;

public class RecordTransactionConfiguration : IEntityTypeConfiguration<RecordTransaction>
{
    public void Configure(EntityTypeBuilder<RecordTransaction> builder)
    {
        builder.ToTable("Record_Transaction");
        builder.HasKey(x=> x.Id);
        builder.Property(x => x.Type).HasConversion<int>().IsRequired();
        builder.Property(x => x.Quantity).IsRequired();
        builder.Property(x => x.Description).HasMaxLength(100).IsRequired();
        builder.HasOne(x => x.Product).WithMany(x => x.RecordTransactions).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x=> x.WareHouse).WithMany(x=> x.RecordTransactions).HasForeignKey(x=>x.WareHouseId).OnDelete(DeleteBehavior.Restrict);   
            
    }
}
