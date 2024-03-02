using Microsoft.AspNetCore.Mvc;
using STBRV.Bussiness.Service;
using STBRV.Data.Models.ViewModels;
using STBRV.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace STBRV.Data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloTiendaController : ControllerBase
    {

        private readonly IArticuloTiendaService _articuloTiendaService;

        public ArticuloTiendaController(IArticuloTiendaService articuloTiendaService)
        {
            _articuloTiendaService = articuloTiendaService;
        }

        // GET: api/<ArticuloTiendaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IQueryable<ArticuloTiendum> queryTiendasSQL = await _articuloTiendaService.Obtener();

            List<VMArticuloTienda> clientes = queryTiendasSQL.Select(a => new VMArticuloTienda()
            {
                Id = a.Id,
                IdTienda = a.IdTienda,
                IdArticulo = a.IdArticulo,
                Fecha = a.Fecha.ToString(),
                IdTiendaNavigation = new VMTienda() { 
                    Id = a.IdTiendaNavigation.Id, 
                    Direccion = a.IdTiendaNavigation.Direccion,
                    Sucursal = a.IdTiendaNavigation.Sucursal
                },
                IdArticuloNavigation = new VMArticulo() { 
                    Id = a.IdArticuloNavigation.Id, 
                    Codigo = a.IdArticuloNavigation.Codigo, 
                    Descripcion = a.IdArticuloNavigation.Descripcion, 
                    Stock = a.IdArticuloNavigation.Stock
                }
            }).ToList();
            return StatusCode(StatusCodes.Status200OK, clientes);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VMArticuloTienda modelo)
        {
            ArticuloTiendum nuevaTienda = new ArticuloTiendum()
            {
                IdArticulo = modelo.IdArticulo,
                IdTienda = modelo.IdTienda,
                Fecha = DateTime.Parse(modelo.Fecha)
            };

            bool respuesta = await _articuloTiendaService.Insertar(nuevaTienda);
            return StatusCode(StatusCodes.Status200OK, modelo);
        }

        // PUT api/<ArticuloTiendaController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] VMArticuloTienda modelo)
        {
            ArticuloTiendum ArticuloTienda = new ArticuloTiendum()
            {
                Id = modelo.Id,
                IdArticulo = modelo.IdArticulo,
                IdTienda = modelo.IdTienda,
                Fecha = DateTime.Parse(modelo.Fecha)
            };

            bool respuesta = await _articuloTiendaService.Insertar(ArticuloTienda);
            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }

        // DELETE api/<ArticuloTiendaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool respuesta = await _articuloTiendaService.Eliminar(id);
            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });
        }
    }
}
