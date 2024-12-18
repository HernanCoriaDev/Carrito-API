using Carrito.Application.DTOs;
using Carrito.Domain.Entities;
using Carrito.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Carrito.Infrastructure.DataBase
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            EntityConfiguration(modelBuilder);
            Seed(modelBuilder);
        }
         
        private void EntityConfiguration(ModelBuilder modelBuilder)
        {
            new UserConfiguration(modelBuilder.Entity<User>());
            new CartConfiguration(modelBuilder.Entity<Cart>());
            new CartProductConfiguration(modelBuilder.Entity<CartProduct>());
            new ProductConfiguration(modelBuilder.Entity<Product>());

        }
        private void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Smartphone", Price = 799, Description = "Smartphone con pantalla de 6.5' y cámara de 48MP" },
                new Product { Id = 2, Name = "Laptop", Price = 1200, Description = "Laptop con procesador i7, 16GB de RAM y 512GB SSD" },
                new Product { Id = 3, Name = "Auriculares Bluetooth", Price = 150, Description = "Auriculares inalámbricos con cancelación de ruido" },
                new Product { Id = 4, Name = "Televisor 4K", Price = 800, Description = "Televisor de 55' con resolución 4K y Smart TV" },
                new Product { Id = 5, Name = "Cargador Inalámbrico", Price = 50, Description = "Cargador inalámbrico rápido para dispositivos compatibles" },
                new Product { Id = 6, Name = "Tablet", Price = 350, Description = "Tablet de 10' con 64GB de almacenamiento y 4GB de RAM" },
                new Product { Id = 7, Name = "Smartwatch", Price = 220, Description = "Reloj inteligente con monitor de frecuencia cardíaca y GPS" },
                new Product { Id = 8, Name = "Cámara Digital", Price = 450, Description = "Cámara digital de 20MP con pantalla táctil y Wi-Fi integrado" },
                new Product { Id = 9, Name = "Parlantes Bluetooth", Price = 120, Description = "Parlantes inalámbricos con sonido estéreo y batería de larga duración" },
                new Product { Id = 10, Name = "Auriculares Gaming", Price = 90, Description = "Auriculares con micrófono y sonido envolvente para juegos" },
                new Product { Id = 11, Name = "Drone", Price = 350, Description = "Drone con cámara 4K y control remoto de 100m" },
                new Product { Id = 12, Name = "Reproductor de Blu-ray", Price = 120, Description = "Reproductor de Blu-ray con acceso a streaming y 4K" },
                new Product { Id = 13, Name = "Disco Duro Externo", Price = 80, Description = "Disco duro externo de 1TB con USB 3.0 para transferencias rápidas" },
                new Product { Id = 14, Name = "Monitor 4K", Price = 350, Description = "Monitor 27' 4K con resolución Ultra HD y tecnología IPS" },
                new Product { Id = 15, Name = "Teclado Mecánico", Price = 110, Description = "Teclado mecánico con retroiluminación RGB y teclas programables" }
            );
        }
    }
}
