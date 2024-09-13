using Ecommerce.BD.Models;
using Ecommerce.PRC.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ecommerce.WEB.Controllers
{
    public class DescuentosController : Controller
    {
        private readonly DescuentoServicio _descuentoServicio;

        public DescuentosController(DescuentoServicio descuentoServicio)
        {
            _descuentoServicio = descuentoServicio;
        }

        // Mostrar lista de descuentos
        public async Task<IActionResult> Index()
        {
            var descuentos = await _descuentoServicio.ObtenerTodosLosDescuentosAsync();
            return View(descuentos);
        }

        // Detalles de un descuento
        public async Task<IActionResult> Detalles(int id)
        {
            var descuento = await _descuentoServicio.ObtenerDescuentoPorIdAsync(id);
            if (descuento == null)
            {
                return NotFound();
            }
            return View(descuento);
        }

        // Crear nuevo descuento (GET)
        public IActionResult Crear()
        {
            return View();
        }

        // Crear nuevo descuento (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Descuento descuento)
        {
            if (ModelState.IsValid)
            {
                await _descuentoServicio.CrearDescuentoAsync(descuento);
                return RedirectToAction(nameof(Index));
            }
            return View(descuento);
        }

        // Editar descuento (GET)
        public async Task<IActionResult> Editar(int id)
        {
            var descuento = await _descuentoServicio.ObtenerDescuentoPorIdAsync(id);
            if (descuento == null)
            {
                return NotFound();
            }
            return View(descuento);
        }

        // Editar descuento (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Descuento descuento)
        {
            if (ModelState.IsValid)
            {
                await _descuentoServicio.ActualizarDescuentoAsync(descuento);
                return RedirectToAction(nameof(Index));
            }
            return View(descuento);
        }

        // Eliminar descuento (GET)
        public async Task<IActionResult> Eliminar(int id)
        {
            var descuento = await _descuentoServicio.ObtenerDescuentoPorIdAsync(id);
            if (descuento == null)
            {
                return NotFound();
            }

            // Llamar al servicio para eliminar el descuento
            await _descuentoServicio.EliminarDescuentoAsync(id);

            // Redirigir nuevamente a la lista de descuentos después de la eliminación
            return RedirectToAction(nameof(Index));
        }

        // Confirmar eliminación (POST)
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarEliminar(int id)
        {
            await _descuentoServicio.EliminarDescuentoAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
