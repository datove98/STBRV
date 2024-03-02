using Microsoft.AspNetCore.Mvc;
using STBRV.Bussiness.Service;
using STBRV.Data.Models.ViewModels;
using STBRV.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace STBRV.Data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {

        private readonly IArticuloService _articuloService;

        public ArticulosController(IArticuloService articuloService)
        {
            _articuloService = articuloService;
        }

        // GET: api/<ArticulosController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IQueryable<Articulo> queryArticulosSQL = await _articuloService.Obtener();

            List<VMArticulo> articulos = queryArticulosSQL.Select(a => new VMArticulo()
            {
                Id = a.Id,
                Codigo = a.Codigo,
                Descripcion = a.Descripcion,
                Precio = a.Precio,
                Imagen = a.Imagen,
                Stock = a.Stock
            }).ToList();
            return StatusCode(StatusCodes.Status200OK,articulos);
        }

        // GET api/<ArticulosController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Articulo articuloResponse = await _articuloService.ObtenerPorId(id);
            return StatusCode(StatusCodes.Status200OK, articuloResponse);
        }

        // POST api/<ArticulosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] VMArticulo modelo)
        {
            Articulo nuevoArticulo = new Articulo()
            {
                Codigo=modelo.Codigo,
                Descripcion=modelo.Descripcion,
                Precio = modelo.Precio,
                Imagen = modelo.Imagen,
                Stock = modelo.Stock
            };

            bool respuesta = await _articuloService.Insertar(nuevoArticulo);
            return StatusCode(StatusCodes.Status200OK, respuesta);
        }

        // PUT api/<ArticulosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] VMArticulo modelo)
        {
            Articulo nuevoArticulo = new Articulo()
            {
                Id = modelo.Id,
                Codigo = modelo.Codigo,
                Descripcion = modelo.Descripcion,
                Precio = modelo.Precio,
                Imagen = modelo.Imagen,
                Stock = modelo.Stock
            };

            bool respuesta = await _articuloService.Insertar(nuevoArticulo);
            return StatusCode(StatusCodes.Status200OK, respuesta);
        }

        // DELETE api/<ArticulosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool respuesta = await _articuloService.Eliminar(id);
            return StatusCode(StatusCodes.Status200OK, respuesta);
        }
    }
}
