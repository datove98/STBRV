using Microsoft.EntityFrameworkCore;
using STBRV.Data.DataContext;
using STBRV.Entities;

namespace STBRV.Data.Repositories
{
    public class ArticuloTiendaRepository : IGenericRepository<ArticuloTiendum>
    {

        private readonly StbrvContext _stbrvContext;

        public ArticuloTiendaRepository(StbrvContext stbrvContext)
        {
            _stbrvContext = stbrvContext;
        }

        public async Task<bool> Actualizar(ArticuloTiendum modelo)
        {
            _stbrvContext.ArticuloTienda.Update(modelo);
            int modified = await _stbrvContext.SaveChangesAsync();
            return modified > 0;
        }

        public async Task<bool> Eliminar(int id)
        {
            ArticuloTiendum articuloTienda = await _stbrvContext.ArticuloTienda.FirstAsync(a => a.Id == id);
            _stbrvContext.ArticuloTienda.Remove(articuloTienda);
            int modified = await _stbrvContext.SaveChangesAsync();
            return modified > 0;
        }

        public async Task<bool> Insertar(ArticuloTiendum modelo)
        {
            _stbrvContext.ArticuloTienda.Add(modelo);
            int modified = await _stbrvContext.SaveChangesAsync();
            return modified > 0;
        }

        public async Task<IQueryable<ArticuloTiendum>> Obtener()
        {
            IQueryable<ArticuloTiendum> queryArticuloTiendaSQL = _stbrvContext.ArticuloTienda;
            return queryArticuloTiendaSQL;
        }

        public async Task<ArticuloTiendum> ObtenerPorId(int id)
        {
            return await _stbrvContext.ArticuloTienda.FindAsync(id);

        }
    }
}
