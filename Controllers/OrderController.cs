using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemasWeb01.Models;

namespace SistemasWeb01.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IShoppingCart _shoppingCart;

        public OrderController(IOrderRepository orderRepository, IShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Checkout()//GET, default.
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty, add some Products first");
            }

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                string texto = _orderRepository.detalleOrden(order);
                string number = order.PhoneNumber;
                _orderRepository.correoSend(texto, order.Email);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete",new { texto = texto, number = number });
            }
            return View(order);
        }

        public IActionResult CheckoutComplete(string texto, string number)
        {
            ViewBag.CheckoutCompleteMessage = texto;
            ViewBag.numero = number;
            return View();
        }
    }
}
