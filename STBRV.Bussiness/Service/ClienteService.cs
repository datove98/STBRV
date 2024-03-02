using STBRV.Entities;
using STBRV.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBRV.Bussiness.Service
{
    public class ClienteService : IClienteService
    {

        private readonly IGenericRepository<Cliente> _clienteRepository;

        public ClienteService(IGenericRepository<Cliente> genericRepository)
        {
            _clienteRepository = genericRepository;
        }

        public Task<bool> Actualizar(Cliente modelo)
        {
            return _clienteRepository.Actualizar(modelo);
        }

        public Task<bool> Eliminar(int id)
        {
            return _clienteRepository.Eliminar(id);
        }

        public async Task<bool> IniciarSesion(Cliente modelo)
        {
            return true;
        }

        public Task<bool> Insertar(Cliente modelo)
        {
            return _clienteRepository.Insertar(modelo);
        }

        public Task<IQueryable<Cliente>> Obtener()
        {
            return _clienteRepository.Obtener();
        }

        public Task<Cliente> ObtenerPorId(int id)
        {
            return _clienteRepository.ObtenerPorId(id);
        }
    }
}
