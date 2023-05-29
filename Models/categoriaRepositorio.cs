using System.IO.Pipelines;
using Microsoft.EntityFrameworkCore;

namespace SistemasWeb01.Models
{
    public class categoriaRepositorio:ICategoriaRepositorio
    {

        private readonly BethesdaPieShopDbContext _bethesdaPieShopDbContext;

        public categoriaRepositorio(BethesdaPieShopDbContext bethesdaPieShopDbContext)
        {
            _bethesdaPieShopDbContext = bethesdaPieShopDbContext;
        }

        public IEnumerable<categoria> AllCategorias => _bethesdaPieShopDbContext.CategoriasDbSet.OrderBy(p => p.categoriaNombre);

        public void CreateCategory(categoria category)
        {
            category.productos = new List<producto>();
            _bethesdaPieShopDbContext.CategoriasDbSet.Add(category);
            _bethesdaPieShopDbContext.SaveChanges();

        }
        public void UpdateCategory(categoria category)
        {
            _bethesdaPieShopDbContext.CategoriasDbSet.Update(category);
            _bethesdaPieShopDbContext.SaveChanges();

        }
        /* Mostrar categorias*/
        public IEnumerable<categoria> Categorias => _bethesdaPieShopDbContext.CategoriasDbSet.ToList();

        /* Buscar por ID*/
        public categoria GetById(int id)
        {
            return _bethesdaPieShopDbContext.CategoriasDbSet.FirstOrDefault(p => p.categoriaId == id);
        }
        /* borrar*/
        public void  DeleteCategory(categoria category)
        {
            _bethesdaPieShopDbContext.CategoriasDbSet.Remove(category);
            _bethesdaPieShopDbContext.SaveChanges();
        }


    }
}
