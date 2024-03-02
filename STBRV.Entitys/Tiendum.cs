using System;
using System.Collections.Generic;

namespace STBRV.Entities
{
    public partial class Tiendum
    {
        public Tiendum()
        {
            ArticuloTienda = new HashSet<ArticuloTiendum>();
        }

        public int Id { get; set; }
        public string? Sucursal { get; set; }
        public string? Direccion { get; set; }

        public virtual ICollection<ArticuloTiendum> ArticuloTienda { get; set; }
    }
}
