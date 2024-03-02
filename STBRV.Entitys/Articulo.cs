using System;
using System.Collections.Generic;

namespace STBRV.Entities
{
    public partial class Articulo
    {
        public Articulo()
        {
            ArticuloTienda = new HashSet<ArticuloTiendum>();
            ClienteArticulos = new HashSet<ClienteArticulo>();
        }

        public int Id { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public decimal? Precio { get; set; }
        public string? Imagen { get; set; }
        public int? Stock { get; set; }

        public virtual ICollection<ArticuloTiendum> ArticuloTienda { get; set; }
        public virtual ICollection<ClienteArticulo> ClienteArticulos { get; set; }
    }
}
