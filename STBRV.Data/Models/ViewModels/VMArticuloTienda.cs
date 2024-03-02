using STBRV.Entities;

namespace STBRV.Data.Models.ViewModels
{
    public class VMArticuloTienda
    {
        public int Id { get; set; }
        public int? IdArticulo { get; set; }
        public int? IdTienda { get; set; }
        public string? Fecha { get; set; }

        public VMArticulo? IdArticuloNavigation { get; set; }
        public VMTienda? IdTiendaNavigation { get; set; }

    }
}
