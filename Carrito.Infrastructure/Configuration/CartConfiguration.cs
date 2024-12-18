using Carrito.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carrito.Infrastructure.Configuration
{
    public class CartConfiguration
    {
        public CartConfiguration(EntityTypeBuilder<Cart> entityBuilder)
        {
            entityBuilder.HasKey(c => c.Id);

            entityBuilder.Property(c => c.CreationDate)
                .IsRequired();
                

            entityBuilder.Property(c => c.Type)
                .IsRequired()
                .HasMaxLength(50);

            entityBuilder.Property(c => c.Total)
                .HasColumnType("decimal(18,2)");
        }
    }
}
