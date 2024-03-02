using STBRV.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBRV.Bussiness.Service
{
    public interface IClienteArticuloService
    {
        Task<bool> Insertar(ClienteArticulo modelo);

        Task<bool> Actualizar(ClienteArticulo modelo);

        Task<bool> Eliminar(int id);

        Task<IQueryable<ClienteArticulo>> Obtener();

        Task<ClienteArticulo> ObtenerPorId(int id);
    }
}
