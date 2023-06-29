namespace SistemasWeb01.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public producto Producto { get; set; } = default!;
        //public Pie Pie { get; set; } = default!;
        public int Amount { get; set; }
        public string? ShoppingCartId { get; set; } 
    }
}
