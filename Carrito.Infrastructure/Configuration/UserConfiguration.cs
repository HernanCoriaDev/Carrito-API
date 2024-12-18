using Carrito.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carrito.Infrastructure.Configuration
{
    public class UserConfiguration
    {
        public UserConfiguration(EntityTypeBuilder<User> entityBuilder)
        {

            entityBuilder.HasKey(e => e.Id);

            entityBuilder.Property(p => p.Dni)
                .IsRequired()
                .HasMaxLength(50);

            entityBuilder.Property(p => p.VIP)
                .IsRequired();

            entityBuilder.HasMany(u => u.Carts)
                .WithOne(c => c.Users)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
