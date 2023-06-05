using SistemasWeb01.Models;

namespace SistemasWeb01.ViewModels
{
    public class ProductoListViewModel
    {
        public IEnumerable<producto> productos { get; }
        public IEnumerable<categoria> categorias { get; }
        public ProductoListViewModel(IEnumerable<categoria> categorias,IEnumerable<producto> productos)
        {
            this.productos = productos;
            this.categorias = categorias;

        }
    }
}
