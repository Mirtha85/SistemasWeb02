using Microsoft.AspNetCore.Mvc;
using SistemasWeb01.Models;
using SistemasWeb01.ViewModels;

namespace SistemasWeb01.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ICategoriaRepositorio _categoryRepository;
        private readonly IProductoRepositorio _productoRepository;
        public ProductoController(ICategoriaRepositorio categoryRepository, IProductoRepositorio productoRepository)
        {
            _categoryRepository = categoryRepository;
            _productoRepository = productoRepository;
        }
        public IActionResult Index()
        {
            //return View(_productoRepository.AllProductos);
            return View(_productoRepository.filtroDelete);
        }
        public IActionResult Crear()
        {

            return View(_categoryRepository.Categorias);
        }
        public IActionResult Agregar()
        {
            producto varProducto = new producto();
            ViewModel models = new ViewModel(_categoryRepository.Categorias, _productoRepository.productosList,varProducto);
            return View(models);
        }
        [HttpPost]
        public async Task <IActionResult> Agregar(ViewModel model, IFormFile imagen)
        {
            if (imagen != null && imagen.Length > 0)
            {
                var fileName = Path.GetFileName(imagen.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagenes", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await imagen.CopyToAsync(stream);
                }


                model.productoClass.imagen = fileName; // Guardamos el nombre de la imagen en el atributo imagen del modelo Producto
            }
            _productoRepository.CreateProducto(model.productoClass);
            return RedirectToAction("Index", "producto");
            
        }
        public IActionResult delete(int id)
        {
            producto prod = _productoRepository.GetById(id);
            if (prod != null)
            {
                return View(prod);
            }

            return NotFound();
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult delete(producto _producto)
        {
            producto prod = _productoRepository.GetById(_producto.productoId);
            prod.deleted = _producto.deleted;
            _productoRepository.deleteUpdate(prod);
            return RedirectToAction("Index", "producto");


        }



    }
}
