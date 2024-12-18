namespace Carrito.Domain.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreationDate { get; set; }
        public string Type { get; set; }
        public decimal Total { get; set; }
        public User? Users { get; set; }
        public List<CartProduct> CartProducts { get; set; } = new List<CartProduct>();

        #region LogicDiscount
        public decimal CalculateTotal()
        {
            return CartProducts.Sum(cp => cp.Amount * cp.UnitPrice);
        }

        public decimal CalculateDiscount()
        {
            int productCount = CartProducts.Count;
            decimal discount = 0m;

            if (productCount == 5)
            {
                discount = Total * 0.20m;
            }
            else if (productCount > 10)
            {
                if (Type == "Comun")
                {
                    discount = 200m;
                }
                else if (Type == "PromocionablePorFecha")
                {
                    discount = 500m;
                }
                else if (Type == "Vip")
                {
                    var cheapestProduct = CartProducts.OrderBy(cp => cp.Product.Price).FirstOrDefault();
                    decimal cheapestProductBonus = cheapestProduct?.Product.Price ?? 0m;
                    discount = 700m + cheapestProductBonus;

                    discount += 700m;
                }
            }
            else if (Type == "PromocionablePorFecha")
            {
                discount = 500m;
            }
            else if (Type == "Vip")
            {
                var cheapestProduct = CartProducts.OrderBy(cp => cp.Product.Price).FirstOrDefault();
                decimal cheapestProductBonus = cheapestProduct?.Product.Price ?? 0m;
                discount = 700m + cheapestProductBonus;
            }

            return discount;
        }
        #endregion

    }
}