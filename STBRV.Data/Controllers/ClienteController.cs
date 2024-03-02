using Microsoft.AspNetCore.Mvc;
using STBRV.Bussiness.Service;
using STBRV.Data.Models.ViewModels;
using STBRV.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace STBRV.Data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IQueryable<Cliente> queryclientesSQL = await _clienteService.Obtener();

            List<VMCliente> clientes = queryclientesSQL.Select(a => new VMCliente()
            {
                Id = a.Id,
                Nombre = a.Nombre,
                Apellidos = a.Apellidos,
                Direccion = a.Direccion
            }).ToList();
            return StatusCode(StatusCodes.Status200OK, new { valor = clientes });
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VMCliente modelo)
        {
            Cliente nuevoCliente = new Cliente()
            {
                Nombre = modelo.Nombre,
                Apellidos = modelo.Apellidos,
                Direccion=modelo.Direccion
            };

            bool respuesta = await _clienteService.Insertar(nuevoCliente);
            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] VMCliente modelo)
        {
            Cliente nuevoArticulo = new Cliente()
            {
                Id = modelo.Id,
                Nombre = modelo.Nombre,                
                Apellidos= modelo.Apellidos,
                Direccion = modelo.Direccion,
            };

            bool respuesta = await _clienteService.Insertar(nuevoArticulo);
            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool respuesta = await _clienteService.Eliminar(id);
            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }
    }
}
