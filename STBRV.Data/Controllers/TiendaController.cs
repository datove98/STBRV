using Microsoft.AspNetCore.Mvc;
using STBRV.Bussiness.Service;
using STBRV.Data.Models.ViewModels;
using STBRV.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace STBRV.Data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiendaController : ControllerBase
    {

        private readonly ITiendaService _tiendaService;

        public TiendaController(ITiendaService tiendaService)
        {
            _tiendaService = tiendaService;
        }

        // GET: api/<TiendaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IQueryable<Tiendum> queryTiendasSQL = await _tiendaService.Obtener();

            List<VMTienda> clientes = queryTiendasSQL.Select(a => new VMTienda()
            {
                Id = a.Id,
                Direccion = a.Direccion,
                Sucursal = a.Sucursal
            }).ToList();
            return StatusCode(StatusCodes.Status200OK, clientes);
        }

        // GET api/<TiendaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TiendaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VMTienda modelo)
        {            
            Tiendum nuevaTienda = new Tiendum()
            {
                Direccion = modelo.Direccion,
                Sucursal= modelo.Sucursal
            };

            bool respuesta = await _tiendaService.Insertar(nuevaTienda);
            return StatusCode(StatusCodes.Status200OK, modelo);
        }

        // PUT api/<TiendaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] VMTienda modelo)
        {
            Tiendum nuevoArticulo = new Tiendum()
            {
                Id = modelo.Id,
                Sucursal = modelo.Sucursal,
                 Direccion= modelo.Direccion
            };

            bool respuesta = await _tiendaService.Insertar(nuevoArticulo);
            return StatusCode(StatusCodes.Status200OK, respuesta);
        }

        // DELETE api/<TiendaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool respuesta = await _tiendaService.Eliminar(id);
            return StatusCode(StatusCodes.Status200OK, respuesta);
        }
    }
}
