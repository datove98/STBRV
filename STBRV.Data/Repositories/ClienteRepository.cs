using Microsoft.EntityFrameworkCore;
using STBRV.Data.DataContext;
using STBRV.Entities;

namespace STBRV.Data.Repositories
{
    public class ClienteRepository : IGenericRepository<Cliente>
    {

        private readonly StbrvContext _stbrvContext;

        public ClienteRepository(StbrvContext stbrvContext)
        {
            _stbrvContext = stbrvContext;
        }

        public async Task<bool> Actualizar(Cliente modelo)
        {
            _stbrvContext.Clientes.Update(modelo);
            int modified = await _stbrvContext.SaveChangesAsync();
            return modified > 0;
        }

        public async Task<bool> Eliminar(int id)
        {
            Cliente cliente = await _stbrvContext.Clientes.FirstAsync(c => c.Id == id);
            _stbrvContext.Clientes.Remove(cliente);
            int modified = await _stbrvContext.SaveChangesAsync();
            return modified > 0;
        }

        public async Task<bool> Insertar(Cliente modelo)
        {
            _stbrvContext.Clientes.Add(modelo);
            int modified = await _stbrvContext.SaveChangesAsync();
            return modified > 0;
        }

        public async Task<IQueryable<Cliente>> Obtener()
        {
            IQueryable<Cliente> queryClienteSQL = _stbrvContext.Clientes;
            return queryClienteSQL;
        }

        public Task<Cliente> ObtenerPorId(int id)
        {
            return _stbrvContext.Clientes.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
