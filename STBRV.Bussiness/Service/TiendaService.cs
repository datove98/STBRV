using STBRV.Entities;
using STBRV.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBRV.Bussiness.Service
{
    public class TiendaService: ITiendaService
    {
        private readonly IGenericRepository<Tiendum> _tiendaRepository;

        public TiendaService(IGenericRepository<Tiendum> tiendaRepository)
        {
            _tiendaRepository = tiendaRepository;
        }

        public async Task<bool> Actualizar(Tiendum modelo)
        {
            return await _tiendaRepository.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _tiendaRepository.Eliminar(id);
        }

        public async Task<bool> Insertar(Tiendum modelo)
        {
            return await _tiendaRepository.Insertar(modelo);
        }

        public async Task<IQueryable<Tiendum>> Obtener()
        {
            return await _tiendaRepository.Obtener();
        }

        public async Task<Tiendum> ObtenerPorId(int id)
        {
            return await _tiendaRepository.ObtenerPorId((int)id);
        }
    }
}
