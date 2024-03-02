using STBRV.Entities;

namespace STBRV.Data.Models.ViewModels
{
    public class VMArticulo
    {

        public int Id { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public string? Imagen { get; set; }
        public int? Stock { get; set; }
    }
}
