using Carrito.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carrito.Infrastructure.Configuration
{
    public class CartProductConfiguration
    {
        public CartProductConfiguration(EntityTypeBuilder<CartProduct> entityBuilder)
        {

            entityBuilder.HasKey(c => new
            {
                c.CartId,
                c.ProductId
            });

            entityBuilder.Property(c => c.Amount)
                .IsRequired();

            entityBuilder.Property(c => c.UnitPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            entityBuilder.HasOne(c => c.Cart)
                .WithMany(c => c.CartProducts)
                .HasForeignKey(c => c.CartId)
                .OnDelete(DeleteBehavior.Cascade);

            entityBuilder.HasOne(cp => cp.Product)
                .WithMany(p => p.CartProducts)
                .HasForeignKey(cp => cp.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
