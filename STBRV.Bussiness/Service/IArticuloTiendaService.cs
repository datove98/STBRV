using STBRV.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBRV.Bussiness.Service
{
    public interface IArticuloTiendaService
    {
        Task<bool> Insertar(ArticuloTiendum modelo);

        Task<bool> Actualizar(ArticuloTiendum modelo);

        Task<bool> Eliminar(int id);

        Task<IQueryable<ArticuloTiendum>> Obtener();

        Task<ArticuloTiendum> ObtenerPorId(int id);
    }
}
