using Carrito.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carrito.Infrastructure.Configuration
{
    public class ProductConfiguration
    {
        public ProductConfiguration(EntityTypeBuilder<Product> entityBuilder)
        {

            entityBuilder.HasKey(p => p.Id);

            entityBuilder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            entityBuilder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            entityBuilder.Property(p => p.Description)
                .HasMaxLength(500);

        }
    }
}
