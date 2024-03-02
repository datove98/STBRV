using STBRV.Entities;
using STBRV.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBRV.Bussiness.Service
{
    public class ClienteArticuloService : IClienteArticuloService
    {

        private readonly IGenericRepository<ClienteArticulo> _clienteArticuloContext;

        public ClienteArticuloService(IGenericRepository<ClienteArticulo> clienteArticuloContext)
        {
            _clienteArticuloContext = clienteArticuloContext;
        }

        public Task<bool> Actualizar(ClienteArticulo modelo)
        {
            return _clienteArticuloContext.Actualizar(modelo);
        }

        public Task<bool> Eliminar(int id)
        {
            return _clienteArticuloContext.Eliminar(id);
        }

        public Task<bool> Insertar(ClienteArticulo modelo)
        {
            return _clienteArticuloContext.Insertar(modelo);
        }

        public Task<IQueryable<ClienteArticulo>> Obtener()
        {
            return _clienteArticuloContext.Obtener();
        }

        public Task<ClienteArticulo> ObtenerPorId(int id)
        {
            return _clienteArticuloContext.ObtenerPorId(id);
        }
    }
}
