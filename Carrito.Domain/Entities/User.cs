namespace Carrito.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Dni { get; set; }
        public bool VIP { get; set; }
        public List<Cart?> Carts { get; set; } = new List<Cart?>();
    }
}
