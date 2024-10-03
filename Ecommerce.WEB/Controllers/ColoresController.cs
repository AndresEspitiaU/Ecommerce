using Microsoft.AspNetCore.Mvc;
using Ecommerce.PRC.Servicios;
using Ecommerce.BD.Models;
using Microsoft.AspNetCore.Authorization;

namespace Ecommerce.WEB.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class ColoresController : Controller
    {
        private readonly ColoreServicio _coloreServicio;

        public ColoresController(ColoreServicio coloreServicio)
        {
            _coloreServicio = coloreServicio;
        }

        public async Task<IActionResult> Index()
        {
            var colores = await _coloreServicio.ObtenerTodosLosColoresAsync();
            return View(colores);
        }

        public IActionResult Crear()
        {
            // Asegúrate de que estás pasando un modelo inicializado a la vista
            var nuevoColor = new Color();
            return View(nuevoColor);  // Inicializa el modelo
        }



        [HttpPost]
        public async Task<IActionResult> Crear(Color colore)
        {
            if (ModelState.IsValid)
            {
                await _coloreServicio.CrearColorAsync(colore.Col_Nombre, colore.Col_Hexadecimal);
                return RedirectToAction(nameof(Index));
            }
            return View(colore);
        }

        public async Task<IActionResult> Editar(int id)
        {
            var colore = await _coloreServicio.ObtenerColorPorIdAsync(id);
            if (colore == null)
            {
                return NotFound();
            }
            return View(colore);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(int id, Color colore)
        {
            if (id != colore.ColorId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _coloreServicio.ActualizarColorAsync(id, colore.Col_Nombre, colore.Col_Hexadecimal);
                return RedirectToAction(nameof(Index));
            }
            return View(colore);
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            var colore = await _coloreServicio.ObtenerColorPorIdAsync(id);
            if (colore == null)
            {
                return NotFound();
            }
            return View(colore);
        }

        [HttpPost]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            await _coloreServicio.EliminarColorAsync(id);
            return Json(new { success = true });
        }

    }
}
