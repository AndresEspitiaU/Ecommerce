using Ecommerce.BD.Models;
using Ecommerce.PRC.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ecommerce.WEB.Controllers
{
    public class SubcategoriaController : Controller
    {
        private readonly SubcategoriaServicio _subcategoriaServicio;
        private readonly CategoriaServicio _categoriaServicio;

        public SubcategoriaController(SubcategoriaServicio subcategoriaServicio, CategoriaServicio categoriaServicio)
        {
            _subcategoriaServicio = subcategoriaServicio;
            _categoriaServicio = categoriaServicio;
        }

        public async Task<IActionResult> Index()
        {
            var subcategorias = await _subcategoriaServicio.ObtenerTodasLasSubcategoriasAsync();
            return View(subcategorias);
        }

        // GET: Subcategoria/Crear
        public async Task<IActionResult> Crear()
        {
            // Obtener todas las categorías disponibles
            var categorias = await _categoriaServicio.ObtenerTodasLasCategoriasAsync();
            ViewBag.Categorias = categorias; // Pasar categorías a la vista

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Subcategoria subcategoria)
        {
            if (ModelState.IsValid)
            {
                await _subcategoriaServicio.CrearSubcategoriaAsync(subcategoria);
                return Json(new { success = true, message = "Subcategoría creada con éxito" });
            }
            return Json(new { success = false, message = "Error al crear la subcategoría" });
        }

        public async Task<IActionResult> Editar(int id)
        {
            var subcategoria = await _subcategoriaServicio.ObtenerSubcategoriaPorIdAsync(id);
            if (subcategoria == null)
            {
                return NotFound();
            }
            return View(subcategoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Subcategoria subcategoria)
        {
            if (id != subcategoria.SubcategoriaId)
            {
                return Json(new { success = false, message = "El ID de la subcategoría no coincide" });
            }

            if (ModelState.IsValid)
            {
                await _subcategoriaServicio.ActualizarSubcategoriaAsync(subcategoria);
                return Json(new { success = true, message = "Subcategoría actualizada con éxito" });
            }
            return Json(new { success = false, message = "Error al actualizar la subcategoría" });
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            var subcategoria = await _subcategoriaServicio.ObtenerSubcategoriaPorIdAsync(id);
            if (subcategoria == null)
            {
                return NotFound();
            }

            // Llamar al servicio para eliminar la subcategoría
            await _subcategoriaServicio.EliminarSubcategoriaAsync(id);

            // Redirigir nuevamente a la lista de subcategorías después de la eliminación
            return RedirectToAction(nameof(Index));
        }

        // Confirmar eliminación (POST)
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarEliminar(int id)
        {
            await _subcategoriaServicio.EliminarSubcategoriaAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
