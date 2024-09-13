using Ecommerce.BD.Models;
using Ecommerce.PRC.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Ecommerce.WEB.Controllers
{
    public class CuponesController : Controller
    {
        private readonly CuponServicio _cuponServicio;

        public CuponesController(CuponServicio cuponServicio)
        {
            _cuponServicio = cuponServicio;
        }

        // GET: Cupones
        public async Task<IActionResult> Index()
        {
            List<Cupone> cupones = await _cuponServicio.ObtenerTodosLosCuponesAsync();
            return View(cupones);
        }

        // GET: Cupones/Detalles/5
        public async Task<IActionResult> Detalles(int id)
        {
            var cupon = await _cuponServicio.ObtenerCuponPorIdAsync(id);
            if (cupon == null)
            {
                return NotFound();
            }
            return View(cupon);
        }

        // GET: Cupones/Crear
        public IActionResult Crear()
        {
            return View();
        }

        // POST: Cupones/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Cupone cupon)
        {
            if (ModelState.IsValid)
            {
                await _cuponServicio.CrearCuponAsync(cupon);
                return RedirectToAction(nameof(Index));
            }
            return View(cupon);
        }

        // GET: Cupones/Editar/5
        public async Task<IActionResult> Editar(int id)
        {
            var cupon = await _cuponServicio.ObtenerCuponPorIdAsync(id);
            if (cupon == null)
            {
                return NotFound();
            }
            return View(cupon);
        }

        // POST: Cupones/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Cupone cupon)
        {
            if (id != cupon.CuponId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _cuponServicio.ActualizarCuponAsync(cupon);
                return RedirectToAction(nameof(Index));
            }
            return View(cupon);
        }

        // GET: Cupones/Eliminar/5
        public async Task<IActionResult> Eliminar(int id)
        {
            var cupon = await _cuponServicio.ObtenerCuponPorIdAsync(id);
            if (cupon == null)
            {
                return NotFound();
            }

            await _cuponServicio.EliminarCuponAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: Cupones/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarEliminacion(int id)
        {
            await _cuponServicio.EliminarCuponAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
