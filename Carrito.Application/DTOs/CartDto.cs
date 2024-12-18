using Carrito.Domain.Entities;

namespace Carrito.Application.DTOs
{
    public class CartDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Type { get; set; }
        public decimal Total { get; set; }
        public List<CartProductDto> CartProducts { get; set; } = new List<CartProductDto>();
    }
}
