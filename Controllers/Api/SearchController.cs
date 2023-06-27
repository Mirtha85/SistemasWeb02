using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemasWeb01.Models;

namespace SistemasWeb01.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IProductoRepositorio _productoRepositorio;

        public SearchController(IProductoRepositorio pieRepository)
        {
            _productoRepositorio = pieRepository;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var allPies = _productoRepositorio.AllProductos;
            return Ok(allPies);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (!_productoRepositorio.AllProductos.Any(p => p.productoId == id))
                return NotFound();
            //return new JsonResult(_pieRepository.AllPies.Where(p =>p.PieId == id);
            return Ok(_productoRepositorio.AllProductos.Where(p => p.productoId == id));
        }

        [HttpPost]
        public IActionResult SearchPies([FromBody] string searchQuery)
        {
            IEnumerable<producto> pies = new List<producto>();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                pies = _productoRepositorio.SearchProducto(searchQuery);
            }
            return new JsonResult(pies);
        }
    }
}
