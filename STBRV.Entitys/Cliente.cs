using System;
using System.Collections.Generic;

namespace STBRV.Entities 
{ 
    public partial class Cliente
    {
        public Cliente()
        {
            ClienteArticulos = new HashSet<ClienteArticulo>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public string? Direccion { get; set; }

        public virtual ICollection<ClienteArticulo> ClienteArticulos { get; set; }
    }
}
