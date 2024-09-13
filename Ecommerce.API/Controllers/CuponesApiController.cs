using Ecommerce.BD.Models;
using Ecommerce.PRC.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuponesApiController : ControllerBase
    {
        private readonly CuponServicio _cuponServicio;

        public CuponesApiController(CuponServicio cuponServicio)
        {
            _cuponServicio = cuponServicio;
        }

        // GET: api/CuponesApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cupone>>> GetCupones()
        {
            var cupones = await _cuponServicio.ObtenerTodosLosCuponesAsync();
            return Ok(cupones);
        }

        // GET: api/CuponesApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cupone>> GetCupon(int id)
        {
            var cupon = await _cuponServicio.ObtenerCuponPorIdAsync(id);

            if (cupon == null)
            {
                return NotFound();
            }

            return Ok(cupon);
        }

        // POST: api/CuponesApi
        [HttpPost]
        public async Task<ActionResult> PostCupon([FromBody] Cupone cupon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _cuponServicio.CrearCuponAsync(cupon);
            return CreatedAtAction(nameof(GetCupon), new { id = cupon.CuponId }, cupon);
        }

        // PUT: api/CuponesApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCupon(int id, [FromBody] Cupone cupon)
        {
            if (id != cupon.CuponId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _cuponServicio.ActualizarCuponAsync(cupon);
            return NoContent();
        }

        // DELETE: api/CuponesApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCupon(int id)
        {
            var cupon = await _cuponServicio.ObtenerCuponPorIdAsync(id);
            if (cupon == null)
            {
                return NotFound();
            }

            await _cuponServicio.EliminarCuponAsync(id);
            return NoContent();
        }
    }
}
