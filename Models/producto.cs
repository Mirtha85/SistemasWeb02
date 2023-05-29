namespace SistemasWeb01.Models
{
    public class producto
    {
        public int productoId { get; set; }

        public string productoNombre { get; set;}
        public int precio { get; set; }
        public int CategoriaId { get; set; }
        public string imagen { get; set; }
        public string detalle { get; set; }
        public bool deleted { get; set; }
        public categoria Categoria { get; set; } = default!;
    }

}
