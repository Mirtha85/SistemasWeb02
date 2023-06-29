using Microsoft.AspNetCore.Mvc;
using SistemasWeb01.Models;
using SistemasWeb01.ViewModels;

namespace SistemasWeb01.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly IProductoRepositorio _productoRepository;
        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartController(IPieRepository pieRepository, IShoppingCart shoppingCart, IProductoRepositorio productoRepositorio)
        {
            _pieRepository = pieRepository;
            _shoppingCart = shoppingCart;
            _productoRepository = productoRepositorio;

        }
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            ViewBag.Items = _shoppingCart.cantidadCarrito(items);
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart, _shoppingCart.GetShoppingCartTotal());

            return View(shoppingCartViewModel);
        }
        
        
        public RedirectToActionResult AddToShoppingCart(int productoId)
        {
            var selectedProducto = _productoRepository.AllProductos.FirstOrDefault(p => p.productoId == productoId);
            var selectedPie = _pieRepository.AllPies.FirstOrDefault(p => p.PieId == productoId);

            if (selectedProducto != null)
            {
                _shoppingCart.AddToCart(selectedProducto);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int pieId)
        {
            var selectedPie = _pieRepository.AllPies.FirstOrDefault(p => p.PieId == pieId);

            if (selectedPie != null)
            {
                _shoppingCart.RemoveFromCart(selectedPie);
            }
            return RedirectToAction("Index");
        }
    }
}
