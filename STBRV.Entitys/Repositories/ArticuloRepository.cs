using Microsoft.EntityFrameworkCore;

using STBRV.Entities;
using STBRV.Entities.DataContext;

namespace STBRV.Entities.Repositories
{
    public class ArticuloRepository : IGenericRepository<Articulo>
    {
        private readonly StbrvContext _stbrvContext;
        public ArticuloRepository(StbrvContext stbrvContext)
        {
            _stbrvContext = stbrvContext;
        }

        public async Task<bool> Actualizar(Articulo modelo)
        {
            _stbrvContext.Articulos.Update(modelo);
            int modified = await _stbrvContext.SaveChangesAsync();
            return modified > 0;
        }

        public async Task<bool> Eliminar(int id)
        {
            Articulo articulo = await _stbrvContext.Articulos.FirstAsync( a => a.Id == id);
            _stbrvContext.Articulos.Remove(articulo);
            int modified = await _stbrvContext.SaveChangesAsync();
            return modified > 0;
        }

        public async Task<IQueryable<Articulo>> Obtener()
        {
            IQueryable<Articulo> queryArtiucloSQL = _stbrvContext.Articulos;
            return queryArtiucloSQL;
        }

        public async Task<Articulo> ObtenerPorId(int id)
        {
            return await _stbrvContext.Articulos.FindAsync(id);
        }

        public async Task<bool> Insertar(Articulo modelo)
        {
            _stbrvContext.Articulos.Add(modelo);
            int modified = await _stbrvContext.SaveChangesAsync();
            return modified > 0;
        }
    }
}
