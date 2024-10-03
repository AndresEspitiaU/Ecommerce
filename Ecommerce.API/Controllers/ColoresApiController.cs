using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ecommerce.PRC.Servicios;
using Ecommerce.BD.Models;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColoresApiController : ControllerBase
    {
        private readonly ColoreServicio _coloreServicio;

        public ColoresApiController(ColoreServicio coloreServicio)
        {
            _coloreServicio = coloreServicio;
        }

        // GET: api/ColoresApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Color>>> GetColores()
        {
            var colores = await _coloreServicio.ObtenerTodosLosColoresAsync();
            return Ok(colores);
        }

        // GET: api/ColoresApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Color>> GetColore(int id)
        {
            var colore = await _coloreServicio.ObtenerColorPorIdAsync(id);

            if (colore == null)
            {
                return NotFound();
            }

            return Ok(colore);
        }


        // POST: api/ColoresApi
        [HttpPost]
        public async Task<ActionResult> PostColore([FromBody] Color colore)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var colorId = await _coloreServicio.CrearColorAsync(colore.Col_Nombre, colore.Col_Hexadecimal);
            return CreatedAtAction(nameof(GetColore), new { id = colorId }, colore);
        }

        // PUT: api/ColoresApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColore(int id, [FromBody] Color colore)
        {
            if (id != colore.ColorId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _coloreServicio.ActualizarColorAsync(id, colore.Col_Nombre, colore.Col_Hexadecimal);
            return NoContent();
        }

        // DELETE: api/ColoresApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColore(int id)
        {
            var colore = await _coloreServicio.ObtenerColorPorIdAsync(id);
            if (colore == null)
            {
                return NotFound();
            }

            await _coloreServicio.EliminarColorAsync(id);
            return NoContent();
        }
    }
}
