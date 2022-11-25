using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasKey(x => new { x.UserId, x.RoleId });
        builder.HasOne(x => x.User).WithMany(x => x.UserRole).HasForeignKey(x => x.UserId);
        builder.HasOne(x => x.Role).WithMany(x => x.UserRole).HasForeignKey(x => x.RoleId);
        builder.ToTable("UserRoles");
    }
}