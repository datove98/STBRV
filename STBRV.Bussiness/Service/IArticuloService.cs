using STBRV.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBRV.Bussiness.Service
{
    public interface IArticuloService
    {
        Task<bool> Insertar(Articulo modelo);

        Task<bool> Actualizar(Articulo modelo);

        Task<bool> Eliminar(int id);

        Task<IQueryable<Articulo>> Obtener();

        Task<Articulo> ObtenerPorId(int id);

        //Task<Articulo> ObtenerPorNombre(string nombre);

    }
}
