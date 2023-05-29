using SistemasWeb01.ViewModels;

namespace SistemasWeb01.Models
{
    public interface IProductoRepositorio
    {
        IEnumerable<producto> AllProductos { get; } // por el momento esto si
        IEnumerable<producto> productosList { get; }
        producto? GetProductosById(int idProducto);//si

        void CreateProducto (producto producto);
        void agregarProducto(ViewModel model);
        IEnumerable<producto> filtroDelete { get; }
        public producto GetById(int id);
        void deleteUpdate (producto producto);
    }
}
