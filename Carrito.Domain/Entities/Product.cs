
namespace Carrito.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public List<CartProduct?> CartProducts { get; set; } = new List<CartProduct?>();
    }
}
