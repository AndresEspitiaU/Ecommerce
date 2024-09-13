using Ecommerce.BD.Models;
using Ecommerce.PRC.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.WEB.Controllers
{
    public class TallaController : Controller
    {
        private readonly TallaServicio _tallaService;

        public TallaController(TallaServicio tallaService)
        {
            _tallaService = tallaService;
        }

        // GET: Talla
        public async Task<IActionResult> Index()
        {
            List<Talla> tallas = await _tallaService.ObtenerTodasLasTallasAsync();
            return View(tallas);
        }

        // GET: Talla/Crear
        public IActionResult Crear()
        {
            return View();
        }

        // POST: Talla/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Talla talla)
        {
            if (ModelState.IsValid)
            {
                await _tallaService.InsertarTallaAsync(talla);
                // Aquí redirigimos a la acción "Index"
                return Json(new { success = true });
            }
            return Json(new { success = false, message = "Error al crear la talla" });
        }


        // GET: Talla/Editar/5
        public async Task<IActionResult> Editar(int id)
        {
            var talla = await _tallaService.ObtenerTallaPorIdAsync(id);
            if (talla == null)
            {
                return NotFound();
            }
            return View(talla);
        }

        // POST: Talla/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Talla talla)
        {
            if (id != talla.TallaId)
            {
                return Json(new { success = false, message = "El ID de la talla no coincide" });
            }

            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "El formulario contiene errores de validación" });
            }

            try
            {
                await _tallaService.ActualizarTallaAsync(talla);
                return Json(new { success = true, message = "Talla actualizada con éxito" });
            }
            catch (Exception ex)
            {
                // Captura cualquier excepción inesperada
                return Json(new { success = false, message = $"Ocurrió un error al actualizar la talla: {ex.Message}" });
            }
        }


        // POST: Talla/Eliminar/5
        [HttpPost]
        public async Task<IActionResult> Eliminar(int id)
        {
            var talla = await _tallaService.ObtenerTallaPorIdAsync(id);
            if (talla == null)
            {
                return Json(new { success = false, message = "Talla no encontrada" });
            }

            await _tallaService.EliminarTallaAsync(id);
            return Json(new { success = true, message = "Talla eliminada con éxito" });
        }
    }
}
