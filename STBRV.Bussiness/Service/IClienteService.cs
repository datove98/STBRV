using STBRV.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBRV.Bussiness.Service
{
    public interface IClienteService
    {
        Task<bool> Insertar(Cliente modelo);

        Task<bool> Actualizar(Cliente modelo);

        Task<bool> Eliminar(int id);

        Task<IQueryable<Cliente>> Obtener();

        Task<Cliente> ObtenerPorId(int id);

        Task<bool> IniciarSesion(Cliente modelo);
    }
}
