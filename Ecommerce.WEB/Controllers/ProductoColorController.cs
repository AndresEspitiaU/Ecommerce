using Ecommerce.BD.Models;
using Ecommerce.PRC.Servicios;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Ecommerce.WEB.Controllers
{
    public class ProductoColorController : Controller
    {
        private readonly ProductoColorServicio _productoColorServicio;
        private readonly ProductoServicio _productoServicio;
        private readonly ColoreServicio _coloreServicio;
        private readonly LogServicio _logServicio;
        private readonly UsuarioServicio _usuarioServicio;

        public ProductoColorController(ProductoColorServicio productoColorServicio, ProductoServicio productoServicio, ColoreServicio coloreServicio, LogServicio logServicio, UsuarioServicio usuarioServicio)
        {
            _productoColorServicio = productoColorServicio;
            _productoServicio = productoServicio;
            _coloreServicio = coloreServicio;
            _logServicio = logServicio;
            _usuarioServicio = usuarioServicio;
        }

        // Método Index: Lista todos los productos con sus colores asociados
        public async Task<IActionResult> Index()
    {
        var productos = await _productoColorServicio.ObtenerTodosLosProductosConColoresAsync();
        return View(productos);
    }


        // Crear una nueva relación Producto-Color (GET)
        public async Task<IActionResult> Crear()
        {
            var productos = await _productoServicio.ObtenerTodosLosProductosAsync();
            var colores = await _coloreServicio.ObtenerTodosLosColoresAsync();

            ViewData["Productos"] = new SelectList(productos, "ProductoId", "ProNombre");
            ViewData["Colores"] = new SelectList(colores, "ColorId", "Col_Nombre");

            return View();
        }

        // Crear una nueva relación Producto-Color (POST)
        [HttpPost]
        public async Task<IActionResult> Crear(int productoId, int colorId)
        {
            if (productoId <= 0 || colorId <= 0)
            {
                ModelState.AddModelError(string.Empty, "El producto y el color son obligatorios.");
                return View();
            }

            try
            {
                // Obtener el IdentityUserId del usuario autenticado
                var identityUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                // Obtener el UsuarioId
                var usuarioId = await _usuarioServicio.ObtenerUsuarioIdPorIdentityIdAsync(identityUserId);

                // Crear la relación Producto-Color
                await _productoColorServicio.InsertarProductoColorAsync(productoId, colorId);

                // Registrar log de creación
                await _logServicio.RegistrarLogAsync(usuarioId, $"Color {colorId} asociado al producto {productoId}", "INFO");

                TempData["SuccessMessage"] = "Color asociado al producto con éxito";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Registrar log de error
                var identityUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var usuarioId = await _usuarioServicio.ObtenerUsuarioIdPorIdentityIdAsync(identityUserId);

                await _logServicio.RegistrarLogAsync(usuarioId, $"Error al asociar color {colorId} al producto {productoId}: {ex.Message}", "ERROR");

                ModelState.AddModelError(string.Empty, "Ocurrió un error al asociar el color al producto.");
                return View();
            }
        }




        // Editar los colores de un producto (GET)
        public async Task<IActionResult> Editar(int productoId)
        {
            var producto = await _productoServicio.ObtenerProductoPorIdAsync(productoId);
            if (producto == null)
            {
                return NotFound();
            }

            var coloresDisponibles = await _coloreServicio.ObtenerTodosLosColoresAsync();
            var coloresSeleccionados = await _productoColorServicio.ObtenerColoresPorProductoAsync(productoId);
            var colorIdsSeleccionados = coloresSeleccionados.Select(c => c.ColorId).ToList();

            ViewData["Colores"] = new MultiSelectList(coloresDisponibles, "ColorId", "Col_Nombre", colorIdsSeleccionados);
            ViewData["ProductoId"] = productoId;

            return View(producto);
        }

        // Editar los colores de un producto (POST)
        [HttpPost]
        public async Task<IActionResult> Editar(int productoId, List<int> colorIds)
        {
            if (ModelState.IsValid)
            {
                await _productoColorServicio.ActualizarProductoColoresAsync(productoId, colorIds);
                TempData["SuccessMessage"] = "Colores actualizados con éxito";
                return RedirectToAction("Index");
            }

            var coloresDisponibles = await _coloreServicio.ObtenerTodosLosColoresAsync();
            ViewData["Colores"] = new MultiSelectList(coloresDisponibles, "ColorId", "Col_Nombre", colorIds);
            ViewData["ProductoId"] = productoId;

            return View();
        }

        // Eliminar un color asociado a un producto (POST)
        [HttpPost]
        public async Task<IActionResult> Eliminar(int productoId, int colorId)
        {
            try
            {
                Console.WriteLine($"ProductoId: {productoId}, ColorId: {colorId}"); 
                await _productoColorServicio.EliminarProductoColorAsync(productoId, colorId);
                return Json(new { success = true, message = "Color eliminado con éxito" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al eliminar el color: " + ex.Message });
            }
        }



    }
}
