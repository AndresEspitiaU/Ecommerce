using Ecommerce.BD.Models;
using Ecommerce.PRC.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Ecommerce.WEB.Controllers
{
    public class ColeccionesController : Controller
    {
        private readonly ColeccionServicio _coleccionServicio;

        public ColeccionesController(ColeccionServicio coleccionServicio)
        {
            _coleccionServicio = coleccionServicio;
        }

        // GET: Colecciones
        public async Task<IActionResult> Index()
        {
            List<Coleccione> colecciones = await _coleccionServicio.ObtenerTodasLasColeccionesAsync();
            return View(colecciones);
        }

        // GET: Colecciones/Detalles/5
        public async Task<IActionResult> Detalles(int id)
        {
            var coleccion = await _coleccionServicio.ObtenerColeccionPorIdAsync(id);
            if (coleccion == null)
            {
                return NotFound();
            }
            return View(coleccion);
        }

        // GET: Colecciones/Crear
        public IActionResult Crear()
        {
            return View();
        }

        // POST: Colecciones/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Coleccione coleccion)
        {
            if (ModelState.IsValid)
            {
                await _coleccionServicio.CrearColeccionAsync(coleccion);
                return RedirectToAction(nameof(Index));
            }
            return View(coleccion);
        }

        // GET: Colecciones/Editar/5
        public async Task<IActionResult> Editar(int id)
        {
            var coleccion = await _coleccionServicio.ObtenerColeccionPorIdAsync(id);
            if (coleccion == null)
            {
                return NotFound();
            }
            return View(coleccion);
        }

        // POST: Colecciones/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Coleccione coleccion)
        {
            if (id != coleccion.ColeccionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _coleccionServicio.ActualizarColeccionAsync(coleccion);
                return RedirectToAction(nameof(Index));
            }
            return View(coleccion);
        }

        // GET: Colecciones/Eliminar/5
        public async Task<IActionResult> Eliminar(int id)
        {
            var coleccion = await _coleccionServicio.ObtenerColeccionPorIdAsync(id);
            if (coleccion == null)
            {
                return NotFound();
            }
            return View(coleccion);  // Puedes omitir esta vista si no la usas
        }

        // POST: Colecciones/EliminarConfirmado
        [HttpPost]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            await _coleccionServicio.EliminarColeccionAsync(id);
            return Json(new { success = true });  // Devolver JSON que indica éxito
        }



    }
}
