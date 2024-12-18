using Carrito.Domain.Entities;

namespace Carrito.Application.DTOs
{
    public class UserCartDto
    {
        public int Id { get; set; }
        public string Dni { get; set; }
        public bool VIP { get; set; }
        public List<CartDto> Carts { get; set; } = new List<CartDto>();
    }
}
