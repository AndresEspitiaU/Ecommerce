using Ecommerce.BD.Models;
using Ecommerce.PRC.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Ecommerce.WEB.Controllers
{
    public class GeneroController : Controller
    {
        private readonly GeneroServicio _generoServicio;

        public GeneroController(GeneroServicio generoServicio)
        {
            _generoServicio = generoServicio;
        }

        // GET: Genero/Index
        public async Task<IActionResult> Index()
        {
            List<Genero> generos = await _generoServicio.ObtenerTodosLosGenerosAsync();
            return View(generos);
        }

        // GET: Genero/Detalles/5
        public async Task<IActionResult> Detalles(int id)
        {
            var genero = await _generoServicio.ObtenerGeneroPorIdAsync(id);
            if (genero == null)
            {
                return NotFound();
            }
            return View(genero);
        }

        // GET: Genero/Crear
        public IActionResult Crear()
        {
            return View();
        }

        // POST: Genero/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Genero genero)
        {
            if (ModelState.IsValid)
            {
                await _generoServicio.InsertarGeneroAsync(genero);
                return Json(new { success = true, message = "Género creado con éxito" });
            }
            return Json(new { success = false, message = "Error al crear el género" });
        }

        // GET: Genero/Editar/5
        public async Task<IActionResult> Editar(int id)
        {
            var genero = await _generoServicio.ObtenerGeneroPorIdAsync(id);
            if (genero == null)
            {
                return NotFound();
            }
            return View(genero);
        }

        // POST: Genero/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Genero genero)
        {
            if (id != genero.GeneroId)
            {
                return Json(new { success = false, message = "El ID del género no coincide" });
            }

            if (ModelState.IsValid)
            {
                await _generoServicio.ActualizarGeneroAsync(genero);
                return Json(new { success = true, message = "Género actualizado con éxito" });
            }
            return Json(new { success = false, message = "Error al actualizar el género" });
        }

        // GET: Genero/Eliminar/5
        public async Task<IActionResult> Eliminar(int id)
        {
            var genero = await _generoServicio.ObtenerGeneroPorIdAsync(id);
            if (genero == null)
            {
                return NotFound();
            }
            return View(genero); // Devuelve la vista para confirmar eliminación
        }

        // POST: Genero/Eliminar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarEliminacion(int id)
        {
            var resultado = await _generoServicio.EliminarGeneroAsync(id);
            if (resultado > 0)
            {
                return Json(new { success = true, message = "Género eliminado con éxito" });
            }
            return Json(new { success = false, message = "Error al eliminar el género" });
        }



    }
}
