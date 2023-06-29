namespace SistemasWeb01.Models
{
    public interface IShoppingCart
    {
        //void AddToCart(Pie pie);
        void AddToCart(producto pie);
        int RemoveFromCart(Pie pie);
        List<ShoppingCartItem> GetShoppingCartItems();
        void ClearCart();
        decimal GetShoppingCartTotal();
        List<ShoppingCartItem> ShoppingCartItems { get; set; }
        string cantidadCarrito(List<ShoppingCartItem> listItems);


    }
}
