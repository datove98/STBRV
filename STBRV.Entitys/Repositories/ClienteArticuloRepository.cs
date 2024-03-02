using Microsoft.EntityFrameworkCore;
using STBRV.Entities;
using STBRV.Entities.DataContext;

namespace STBRV.Entities.Repositories
{
    public class ClienteArticuloRepository : IGenericRepository<ClienteArticulo>
    {

        private readonly StbrvContext _stbrvContext;

        public ClienteArticuloRepository(StbrvContext stbrvContext)
        {
            _stbrvContext = stbrvContext;
        }

        public async Task<bool> Actualizar(ClienteArticulo modelo)
        {
            _stbrvContext.ClienteArticulos.Update(modelo);
            int modified = await _stbrvContext.SaveChangesAsync();
            return modified > 0;
        }

        public async Task<bool> Eliminar(int id)
        {
            ClienteArticulo clienteArticulo = await _stbrvContext.ClienteArticulos.FirstAsync(a => a.Id == id);
            _stbrvContext.ClienteArticulos.Remove(clienteArticulo);
            int modified = await _stbrvContext.SaveChangesAsync();
            return modified > 0;
        }

        public async Task<bool> Insertar(ClienteArticulo modelo)
        {
            _stbrvContext.ClienteArticulos.Add(modelo);
            int modified = await _stbrvContext.SaveChangesAsync();
            return modified > 0;
        }

        public async Task<IQueryable<ClienteArticulo>> Obtener()
        {
            IQueryable<ClienteArticulo> queryClienteArticuloSQL = _stbrvContext.ClienteArticulos;
            return queryClienteArticuloSQL;
        }

        public async Task<ClienteArticulo> ObtenerPorId(int id)
        {
            return await _stbrvContext.ClienteArticulos.FindAsync(id);
        }
    }
}
