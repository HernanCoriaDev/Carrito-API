namespace Carrito.Application.DTOs
{
    public class GetCartDto
    {
        public int Id { get; set; }
        public decimal TotalOriginal { get; set; }
        public decimal Descuento { get; set; }
        public decimal TotalConDescuento { get; set; }
        public List<CartProductDto> Items { get; set; } = new List<CartProductDto>();
    }

}
