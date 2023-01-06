using Domain.Entities.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.OwnsOne(x => x.ShipToAddress, a =>
        {
            a.WithOwner();
        });
        builder.HasMany(x => x.OrderItems).WithOne().OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.DeliveryMethod).WithMany();
        builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.CreatedBy);
        builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.LastModifiedBy);
    }
}