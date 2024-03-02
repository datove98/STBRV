using System;
using System.Collections.Generic;

namespace STBRV.Entities 
{ 
    public partial class ClienteArticulo
    {
        public int Id { get; set; }
        public int? IdCliente { get; set; }
        public int? IdArticulo { get; set; }

        public virtual Articulo? IdArticuloNavigation { get; set; }
        public virtual Cliente? IdClienteNavigation { get; set; }
    }
}
