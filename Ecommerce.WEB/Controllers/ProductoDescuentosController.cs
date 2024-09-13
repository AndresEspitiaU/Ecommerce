using Ecommerce.BD.Models;
using Ecommerce.PRC.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.WEB.Controllers
{
    public class ProductoDescuentosController : Controller
    {
        private readonly ProductoDescuentoServicio _productoDescuentoServicio;
        private readonly ProductoServicio _productoServicio;
        private readonly DescuentoServicio _descuentoServicio;

        public ProductoDescuentosController(
            ProductoDescuentoServicio productoDescuentoServicio,
            ProductoServicio productoServicio,
            DescuentoServicio descuentoServicio)
        {
            _productoDescuentoServicio = productoDescuentoServicio;
            _productoServicio = productoServicio;
            _descuentoServicio = descuentoServicio;
        }

        // GET: ProductoDescuentos
        public async Task<IActionResult> Index()
        {
            var productoDescuentos = await _productoDescuentoServicio
                                        .ObtenerTodosLosProductoDescuentosAsync();

            return View(productoDescuentos);
        }

        // GET: ProductoDescuentos/Detalles/5
        public async Task<IActionResult> Detalles(int id)
        {
            var productoDescuento = await _productoDescuentoServicio
                                        .ObtenerProductoDescuentoPorIdAsync(id);

            if (productoDescuento == null)
            {
                return NotFound();
            }

            return View(productoDescuento);
        }

        // GET: ProductoDescuentos/Crear
        public async Task<IActionResult> Crear()
        {
            ViewBag.Productos = await _productoServicio.ObtenerTodosLosProductosAsync();
            ViewBag.Descuentos = await _descuentoServicio.ObtenerTodosLosDescuentosAsync();
            return View();
        }

        // POST: ProductoDescuentos/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(ProductoDescuento productoDescuento)
        {
            if (ModelState.IsValid)
            {
                await _productoDescuentoServicio.InsertarProductoDescuentoAsync(productoDescuento);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Productos = await _productoServicio.ObtenerTodosLosProductosAsync();
            ViewBag.Descuentos = await _descuentoServicio.ObtenerTodosLosDescuentosAsync();
            return View(productoDescuento);
        }

        // GET: ProductoDescuentos/Editar/5
        public async Task<IActionResult> Editar(int id)
        {
            var productoDescuento = await _productoDescuentoServicio.ObtenerProductoDescuentoPorIdAsync(id);
            if (productoDescuento == null)
            {
                return NotFound();
            }

            ViewBag.Productos = await _productoServicio.ObtenerTodosLosProductosAsync();
            ViewBag.Descuentos = await _descuentoServicio.ObtenerTodosLosDescuentosAsync();
            return View(productoDescuento);
        }

        // POST: ProductoDescuentos/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, ProductoDescuento productoDescuento)
        {
            if (id != productoDescuento.ProductoDescuentoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _productoDescuentoServicio.ActualizarProductoDescuentoAsync(productoDescuento);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Productos = await _productoServicio.ObtenerTodosLosProductosAsync();
            ViewBag.Descuentos = await _descuentoServicio.ObtenerTodosLosDescuentosAsync();
            return View(productoDescuento);
        }

        // POST: ProductoDescuentos/Eliminar/5
        [HttpPost]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            var resultado = await _productoDescuentoServicio.EliminarProductoDescuentoAsync(id);
            if (resultado > 0)
            {
                return Json(new { success = true, message = "Descuento eliminado con éxito" });
            }

            return Json(new { success = false, message = "Error al eliminar el descuento" });
        }
    }
}
