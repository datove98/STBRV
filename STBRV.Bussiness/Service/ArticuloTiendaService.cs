using STBRV.Entities;
using STBRV.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBRV.Bussiness.Service
{
    public class ArticuloTiendaService:IArticuloTiendaService
    {

        private readonly IGenericRepository<ArticuloTiendum> _articuloTiendaContext;

        public ArticuloTiendaService(IGenericRepository<ArticuloTiendum> articuloTiendaRepository)
        {
            _articuloTiendaContext = articuloTiendaRepository;
        }

        public Task<bool> Actualizar(ArticuloTiendum modelo)
        {
            return _articuloTiendaContext.Actualizar(modelo);
        }

        public Task<bool> Eliminar(int id)
        {
            return _articuloTiendaContext.Eliminar(id);
        }

        public Task<bool> Insertar(ArticuloTiendum modelo)
        {
            return _articuloTiendaContext.Insertar(modelo);
        }

        public Task<IQueryable<ArticuloTiendum>> Obtener()
        {
            return _articuloTiendaContext.Obtener();
        }

        public Task<ArticuloTiendum> ObtenerPorId(int id)
        {
            return _articuloTiendaContext.ObtenerPorId(id);
        }
    }
}
