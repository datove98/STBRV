using STBRV.Entities;
using STBRV.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBRV.Bussiness.Service
{
    public class ArticuloService : IArticuloService
    {
        private readonly IGenericRepository<Articulo> _articuloRepository;

        public ArticuloService(IGenericRepository<Articulo> articuloRepository)
        {
            _articuloRepository = articuloRepository;
        }

        public async Task<bool> Actualizar(Articulo modelo)
        {
            return await _articuloRepository.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _articuloRepository.Eliminar(id);
        }

        public async Task<bool> Insertar(Articulo modelo)
        {
            
            return await _articuloRepository.Insertar(modelo);
        }

        public async Task<IQueryable<Articulo>> Obtener()
        {
            return await _articuloRepository.Obtener();
        }

        public async Task<Articulo> ObtenerPorId(int id)
        {
            return await _articuloRepository.ObtenerPorId(id);
        }

        //public async Task<Articulo> ObtenerPorNombre(string nombre)
        //{
        //    IQueryable<Articulo> queryArticuloSQL = await _articuloRepository.Obtener();
        //    Articulo articulo = queryArticuloSQL.Where(c => c.)
        //}
    }
}
