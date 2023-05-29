using System.ComponentModel.DataAnnotations;
namespace SistemasWeb01.Models
{
    public class categoria
    {
        
        public int categoriaId { get; set; }
        
        public string categoriaNombre { get; set; }
        
        public string? descripcion { get; set; }
        
        public List<producto>? productos { get; set; }
    }
}
