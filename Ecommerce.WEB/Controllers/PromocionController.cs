using Ecommerce.BD.Models;
using Ecommerce.PRC.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Ecommerce.WEB.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class PromocionController : Controller
    {
        private readonly PromocionServicio _promocionService;

        public PromocionController(PromocionServicio promocionService)
        {
            _promocionService = promocionService;
        }

        // GET: Promocion
        public async Task<IActionResult> Index()
        {
            List<Promocione> promociones = await _promocionService.ObtenerTodasLasPromocionesAsync();
            return View(promociones);
        }

        // GET: Promocion/Detalles/5
        public async Task<IActionResult> Detalles(int id)
        {
            var promocion = await _promocionService.ObtenerPromocionPorIdAsync(id);
            if (promocion == null)
            {
                return NotFound();
            }
            return View(promocion);
        }

        // GET: Promocion/Crear
        public IActionResult Crear()
        {
            return View();
        }

        // POST: Promocion/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Promocione promocion)
        {
            if (ModelState.IsValid)
            {
                await _promocionService.InsertarPromocionAsync(promocion);
                return RedirectToAction(nameof(Index));
            }
            return View(promocion);
        }

        // GET: Promocion/Editar/5
        public async Task<IActionResult> Editar(int id)
        {
            var promocion = await _promocionService.ObtenerPromocionPorIdAsync(id);
            if (promocion == null)
            {
                return NotFound();
            }
            return View(promocion);
        }

        // POST: Promocion/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Promocione promocion)
        {
            if (id != promocion.PromocionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _promocionService.ActualizarPromocionAsync(promocion);
                return RedirectToAction(nameof(Index));
            }
            return View(promocion);
        }

        // GET: Promocion/Eliminar/5
        public async Task<IActionResult> Eliminar(int id)
        {
            var promocion = await _promocionService.ObtenerPromocionPorIdAsync(id);
            if (promocion == null)
            {
                return NotFound();
            }
            return View(promocion);
        }

        // POST: Promocion/EliminarConfirmado/5
        [HttpPost]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            await _promocionService.EliminarPromocionAsync(id);
            return Json(new { success = true });
        }
    }
}
