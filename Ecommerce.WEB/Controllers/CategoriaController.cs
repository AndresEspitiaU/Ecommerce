using Ecommerce.BD.Models;
using Ecommerce.PRC.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ecommerce.WEB.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly CategoriaServicio _categoriaServicio;

        public CategoriaController(CategoriaServicio categoriaServicio)
        {
            _categoriaServicio = categoriaServicio;
        }

        public async Task<IActionResult> Index()
        {
            var categorias = await _categoriaServicio.ObtenerTodasLasCategoriasAsync();
            return View(categorias);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                await _categoriaServicio.CrearCategoriaAsync(categoria);
                return Json(new { success = true, message = "Categoría creada con éxito" });
            }
            return Json(new { success = false, message = "Error al crear la categoría" });
        }

        public async Task<IActionResult> Editar(int id)
        {
            var categoria = await _categoriaServicio.ObtenerCategoriaPorIdAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Categoria categoria)
        {
            if (id != categoria.CategoriaId)
            {
                return Json(new { success = false, message = "El ID de la categoría no coincide" });
            }

            if (ModelState.IsValid)
            {
                await _categoriaServicio.ActualizarCategoriaAsync(categoria);
                return Json(new { success = true, message = "Categoría actualizada con éxito" });
            }
            return Json(new { success = false, message = "Error al actualizar la categoría" });
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            var categoria = await _categoriaServicio.ObtenerCategoriaPorIdAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            // Llamar al servicio para eliminar la categoría
            await _categoriaServicio.EliminarCategoriaAsync(id);

            // Redirigir nuevamente a la lista de categorías después de la eliminación
            return RedirectToAction(nameof(Index));
        }

        // Confirmar eliminación (POST)
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarEliminar(int id)
        {
            await _categoriaServicio.EliminarCategoriaAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
