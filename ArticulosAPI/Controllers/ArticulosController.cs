using ArticulosAPI.Dto;
using ArticulosAPI.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArticulosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        private readonly IRepositorio _repositorio;

        public ArticulosController(IRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        // GET: api/Articulos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArticuloDto>>> GetArticulos()
        {
            return Ok(await _repositorio.GetArticulo());
        }

        // GET: api/Articulos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArticuloDto>> GetArticulo(int id)
        {
            var articulo = await _repositorio.GetArticulo(id);

            if (articulo == null)
            {
                return NotFound();
            }

            return Ok(articulo);
        }

        // PUT: api/Articulos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArticulo(int id, ArticuloDto articulo)
        {
            if (id != articulo.Id)
            {
                return BadRequest();
            }

            try
            {
                await _repositorio.CrearOActualizar(articulo, id);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ArticuloExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Articulos
        [HttpPost]
        public async Task<ActionResult<ArticuloDto>> PostArticulo(ArticuloDto articulo)
        {
            var creado = await _repositorio.CrearOActualizar(articulo);
            return CreatedAtAction("GetArticulo", new { id = creado.Id }, creado);
        }

        // DELETE: api/Articulos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticulo(int id)
        {
            var eliminado = await _repositorio.EliminarArticulo(id);
            if (!eliminado)
            {
                return NotFound();
            }

            return NoContent();
        }

        private async Task<bool> ArticuloExists(int id)
        {
            var articulo = await _repositorio.GetArticulo(id);
            return articulo != null;
        }
    }
}
