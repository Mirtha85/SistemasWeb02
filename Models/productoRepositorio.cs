using System.IO.Pipelines;
using Microsoft.EntityFrameworkCore;
using SistemasWeb01.Models;
using SistemasWeb01.ViewModels;

namespace SistemasWeb01.Models
{
    public class productoRepositorio:IProductoRepositorio
    {
        private readonly BethesdaPieShopDbContext _tiendaOnlineDbContext;

        public productoRepositorio(BethesdaPieShopDbContext bethesdaPieShopDbContext)
        {
            _tiendaOnlineDbContext = bethesdaPieShopDbContext;
        }

        public IEnumerable<producto> AllProductos
        {
            get
            {
                return _tiendaOnlineDbContext.ProductosDbSet.Include(c => c.Categoria);
            }
        }

        //public IEnumerable<producto> PiesOfTheWeek
        //{
        //    get
        //    {
        //        return _tiendaOnlineDbContext.ProductosDbSet.Include(c => c.Categoria).Where(p => p.IsPieOfTheWeek);
        //    }
        //}

        public producto? GetProductosById(int idProducto)
        {
            return _tiendaOnlineDbContext.ProductosDbSet.FirstOrDefault(p => p.productoId == idProducto);
        }

        public IEnumerable<producto> SearchProductos(string searchQuery)
        {
            throw new NotImplementedException();
        }
        /* crea un nuevo producto*/
        public void CreateProducto(producto _producto)
        {
            _tiendaOnlineDbContext.ProductosDbSet.Add(_producto);
            _tiendaOnlineDbContext.SaveChanges();

        }
        /* LLama a todos los productos */
        public IEnumerable<producto> productosList => _tiendaOnlineDbContext.ProductosDbSet.ToList();
        public IEnumerable<producto> filtroDelete => _tiendaOnlineDbContext.ProductosDbSet.Where(p => p.deleted == true).ToList();
          


        public void agregarProducto(ViewModel model) 
        {
            
        }
        public producto GetById(int id)
        {
            return _tiendaOnlineDbContext.ProductosDbSet.FirstOrDefault(p => p.productoId == id);
        }
        public void deleteUpdate(producto _producto)
        {
            _tiendaOnlineDbContext.ProductosDbSet.Update(_producto);
            _tiendaOnlineDbContext.SaveChanges();
        }
        /* Serach */
        public IEnumerable<producto> SearchProducto(string searchQuery)
        {
            return _tiendaOnlineDbContext.ProductosDbSet.Where(p => p.productoNombre.Contains(searchQuery));
        }
        
    }
}
