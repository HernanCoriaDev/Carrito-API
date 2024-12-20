﻿namespace Carrito.Domain.Entities
{
    public class CartProduct
    {
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
        public decimal UnitPrice { get; set; } 
    }
}
