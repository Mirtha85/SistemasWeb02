namespace SistemasWeb01.Models
{
    public interface ICategoriaRepositorio
    {
        IEnumerable<categoria> AllCategorias { get;}
        IEnumerable<categoria> Categorias { get;}
        categoria GetById(int id);
        void CreateCategory(categoria category);
        void UpdateCategory(categoria category);
        void DeleteCategory(categoria category);
        
    }
}
