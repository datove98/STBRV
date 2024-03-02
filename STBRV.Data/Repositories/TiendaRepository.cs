using Microsoft.EntityFrameworkCore;
using STBRV.Data.DataContext;
using STBRV.Entities;

namespace STBRV.Data.Repositories
{
    public class TiendaRepository : IGenericRepository<Tiendum>
    {

        private readonly StbrvContext _stbrvContext;

        public TiendaRepository(StbrvContext stbrvContext)
        {
            _stbrvContext = stbrvContext;
        }

        public async Task<bool> Actualizar(Tiendum modelo)
        {
            _stbrvContext.Tienda.Update(modelo);
            int modified = await _stbrvContext.SaveChangesAsync();
            return modified > 0;
        }

        public async Task<bool> Eliminar(int id)
        {
            Tiendum tienda = await _stbrvContext.Tienda.FirstAsync(a => a.Id == id);
            _stbrvContext.Tienda.Remove(tienda);
            int modified = await _stbrvContext.SaveChangesAsync();
            return modified > 0;
        }

        public async Task<bool> Insertar(Tiendum modelo)
        {
            _stbrvContext.Tienda.Add(modelo);
            int modified = await _stbrvContext.SaveChangesAsync();
            return modified > 0;
        }

        public async Task<IQueryable<Tiendum>> Obtener()
        {
            IQueryable<Tiendum> queryTiendaSQL = _stbrvContext.Tienda;
            return queryTiendaSQL;
        }

        public async Task<Tiendum> ObtenerPorId(int id)
        {
            return await _stbrvContext.Tienda.FindAsync(id);
        }
    }
}
