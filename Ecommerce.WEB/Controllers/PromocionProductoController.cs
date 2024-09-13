using Ecommerce.BD.Models;
using Ecommerce.PRC.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ecommerce.WEB.Controllers
{
    public class PromocionProductoController : Controller
    {
        private readonly PromocionProductoServicio _promocionProductoServicio;
        private readonly ProductoServicio _productoServicio;
        private readonly PromocionServicio _promocionServicio;

        public PromocionProductoController(
            PromocionProductoServicio promocionProductoServicio,
            ProductoServicio productoServicio,
            PromocionServicio promocionServicio)
        {
            _promocionProductoServicio = promocionProductoServicio;
            _productoServicio = productoServicio;
            _promocionServicio = promocionServicio;
        }

        // GET: PromocionProducto/SeleccionarPromocion
        public async Task<IActionResult> SeleccionarPromocion()
        {
            var promociones = await _promocionServicio.ObtenerTodasLasPromocionesAsync();
            return View(promociones);
        }

        // GET: PromocionProducto/Index
        public async Task<IActionResult> Index(int promocionId)
        {
            var productosPromocion = await _promocionProductoServicio.ObtenerProductosPorPromocionIdAsync(promocionId);
            var promocion = await _promocionServicio.ObtenerPromocionPorIdAsync(promocionId);

            if (promocion == null)
            {
                return NotFound();
            }

            ViewBag.Promocion = promocion;
            return View(productosPromocion);
        }




        // GET: PromocionProducto/Crear
        public async Task<IActionResult> Crear(int promocionId)
        {
            ViewBag.Productos = await _productoServicio.ObtenerTodosLosProductosAsync();
            ViewBag.Promocion = await _promocionServicio.ObtenerPromocionPorIdAsync(promocionId);
            return View(new PromocionProducto { PromocionId = promocionId });
        }

        // POST: PromocionProducto/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(PromocionProducto promocionProducto)
        {
            if (ModelState.IsValid)
            {
                await _promocionProductoServicio.InsertarPromocionProductoAsync(promocionProducto);
                return Json(new { success = true, message = "Producto agregado a la promoción con éxito" });
            }

            ViewBag.Productos = await _productoServicio.ObtenerTodosLosProductosAsync();
            ViewBag.Promocion = await _promocionServicio.ObtenerPromocionPorIdAsync(promocionProducto.PromocionId);
            return Json(new { success = false, message = "Error al agregar el producto a la promoción" });
        }

        // GET: PromocionProducto/Editar/5
        public async Task<IActionResult> Editar(int id)
        {
            var promocionProducto = await _promocionProductoServicio.ObtenerPromocionProductoPorIdAsync(id);
            if (promocionProducto == null)
            {
                return NotFound();
            }

            ViewBag.Productos = await _productoServicio.ObtenerTodosLosProductosAsync();
            ViewBag.Promocion = await _promocionServicio.ObtenerPromocionPorIdAsync(promocionProducto.PromocionId);

            return View(promocionProducto);
        }

        // POST: PromocionProducto/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, PromocionProducto promocionProducto)
        {
            if (id != promocionProducto.PromocionProductoId)
            {
                return Json(new { success = false, message = "El ID de la promoción-producto no coincide" });
            }

            if (ModelState.IsValid)
            {
                await _promocionProductoServicio.ActualizarPromocionProductoAsync(promocionProducto);
                return Json(new { success = true, message = "Producto de la promoción actualizado con éxito" });
            }

            ViewBag.Productos = await _productoServicio.ObtenerTodosLosProductosAsync();
            ViewBag.Promocion = await _promocionServicio.ObtenerPromocionPorIdAsync(promocionProducto.PromocionId);

            return Json(new { success = false, message = "Error al actualizar el producto en la promoción" });
        }

        // POST: PromocionProducto/Eliminar/5
        [HttpPost]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            var promocionProducto = await _promocionProductoServicio.ObtenerPromocionProductoPorIdAsync(id);
            if (promocionProducto == null)
            {
                return Json(new { success = false, message = "Relación promoción-producto no encontrada" });
            }

            var resultado = await _promocionProductoServicio.EliminarPromocionProductoAsync(id);
            if (resultado > 0)
            {
                return Json(new { success = true, message = "Producto eliminado de la promoción con éxito" });
            }

            return Json(new { success = false, message = "Error al eliminar el producto de la promoción" });
        }
    }
}
