using Ecommerce.BD.Models;
using Ecommerce.PRC.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DescuentosApiController : ControllerBase
    {
        private readonly DescuentoServicio _descuentoServicio;

        public DescuentosApiController(DescuentoServicio descuentoServicio)
        {
            _descuentoServicio = descuentoServicio;
        }

        // GET: api/DescuentosApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Descuento>>> GetDescuentos()
        {
            var descuentos = await _descuentoServicio.ObtenerTodosLosDescuentosAsync();
            return Ok(descuentos);
        }

        // GET: api/DescuentosApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Descuento>> GetDescuento(int id)
        {
            var descuento = await _descuentoServicio.ObtenerDescuentoPorIdAsync(id);

            if (descuento == null)
            {
                return NotFound();
            }

            return Ok(descuento);
        }

        // POST: api/DescuentosApi
        [HttpPost]
        public async Task<ActionResult> PostDescuento([FromBody] Descuento descuento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _descuentoServicio.CrearDescuentoAsync(descuento);
            return CreatedAtAction(nameof(GetDescuento), new { id = descuento.DescuentoId }, descuento);
        }

        // PUT: api/DescuentosApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDescuento(int id, [FromBody] Descuento descuento)
        {
            if (id != descuento.DescuentoId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _descuentoServicio.ActualizarDescuentoAsync(descuento);
            return NoContent();
        }

        // DELETE: api/DescuentosApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDescuento(int id)
        {
            var descuento = await _descuentoServicio.ObtenerDescuentoPorIdAsync(id);
            if (descuento == null)
            {
                return NotFound();
            }

            await _descuentoServicio.EliminarDescuentoAsync(id);
            return NoContent();
        }
    }
}
