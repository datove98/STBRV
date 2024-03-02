using STBRV.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBRV.Bussiness.Service
{
    public interface ITiendaService
    {
        Task<bool> Insertar(Tiendum modelo);

        Task<bool> Actualizar(Tiendum modelo);

        Task<bool> Eliminar(int id);

        Task<IQueryable<Tiendum>> Obtener();

        Task<Tiendum> ObtenerPorId(int id);
    }
}
