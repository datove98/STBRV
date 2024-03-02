using Microsoft.AspNetCore.Mvc;
using STBRV.Bussiness.Service;
using STBRV.Data.Models.ViewModels;
using STBRV.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace STBRV.Data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteArticuloController : ControllerBase
    {
        private readonly IClienteArticuloService _clienteArticuloService;

        public ClienteArticuloController(IClienteArticuloService clienteArticuloService)
        {
            _clienteArticuloService = _clienteArticuloService;
        }

        // GET: api/<ArticuloTiendaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IQueryable<ClienteArticulo> queryClienteTiendasSQL = await _clienteArticuloService.Obtener();

            List<VMClienteArticulo> clientes = queryClienteTiendasSQL.Select(a => new VMClienteArticulo()
            {
                Id = a.Id,
                IdArticulo = a.IdArticulo,
                IdCliente = a.IdCliente,
                IdArticuloNavigation = a.IdArticuloNavigation,
                IdClienteNavigation = a.IdClienteNavigation
            }).ToList();
            return StatusCode(StatusCodes.Status200OK, new { valor = clientes });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VMClienteArticulo modelo)
        {
            ClienteArticulo clienteArticulo = new ClienteArticulo()
            {
                IdArticulo = modelo.IdArticulo,
                IdCliente = modelo.IdCliente
            };

            bool respuesta = await _clienteArticuloService.Insertar(clienteArticulo);
            return StatusCode(StatusCodes.Status200OK, new { valor = modelo });
        }

        // PUT api/<ArticuloTiendaController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] VMClienteArticulo modelo)
        {
            ClienteArticulo clienteArticulo = new ClienteArticulo()
            {
                Id = modelo.Id,
                IdArticulo = modelo.IdArticulo,
                IdCliente = modelo.IdCliente
            };

            bool respuesta = await _clienteArticuloService.Insertar(clienteArticulo);
            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        // DELETE api/<ArticuloTiendaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool respuesta = await _clienteArticuloService.Eliminar(id);
            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }
    }
}
