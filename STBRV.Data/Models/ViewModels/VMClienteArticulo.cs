using STBRV.Entities;

namespace STBRV.Data.Models.ViewModels
{
    public class VMClienteArticulo
    {
        public int Id { get; set; }
        public int? IdCliente { get; set; }
        public int? IdArticulo { get; set; }
        public Articulo? IdArticuloNavigation { get; set; }
        public Cliente? IdClienteNavigation { get; set; }
    }
}
