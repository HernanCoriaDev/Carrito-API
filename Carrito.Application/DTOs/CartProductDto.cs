namespace Carrito.Application.DTOs
{
    public class CartProductDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Amount { get; set; }
        public decimal UnitPrice { get; set; }
    }

}
