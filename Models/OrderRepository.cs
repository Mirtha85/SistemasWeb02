namespace SistemasWeb01.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BethesdaPieShopDbContext _bethesdaPieShopDbContext;

        private readonly IShoppingCart _shoppingCart;

        public OrderRepository(BethesdaPieShopDbContext bethesdaPieShopDbContext, IShoppingCart shoppingCart)
        {
            _bethesdaPieShopDbContext = bethesdaPieShopDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();

            foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    PieId = shoppingCartItem.Pie.PieId,
                    Price = shoppingCartItem.Pie.Price
                };

                order.OrderDetails.Add(orderDetail);
            }

            _bethesdaPieShopDbContext.Orders.Add(order);

            _bethesdaPieShopDbContext.SaveChanges();
        }
    }
}
