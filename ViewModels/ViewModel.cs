using SistemasWeb01.Models;

namespace SistemasWeb01.ViewModels
{
    public class ViewModel
    {
        public IEnumerable<categoria> categorias { get; } 
        public IEnumerable<producto> productos { get; }
        public producto productoClass { get; set; }
        public ViewModel(IEnumerable <categoria> _categoria, IEnumerable<producto> _producto, producto _productoClass) 
        {
            categorias = _categoria;
            productos = _producto;
            productoClass = _productoClass;
        }
        public ViewModel()
        {
            
        }
    }
}
