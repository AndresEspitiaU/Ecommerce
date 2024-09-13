using Ecommerce.BD.Models;
using Ecommerce.PRC.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Ecommerce.WEB.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class ProductoImagenesController : Controller
    {
        private readonly ProductoImagenServicio _productoImagenServicio;
        private readonly ProductoServicio _productoServicio;

        public ProductoImagenesController(ProductoImagenServicio productoImagenServicio, ProductoServicio productoServicio)
        {
            _productoImagenServicio = productoImagenServicio;
            _productoServicio = productoServicio;
        }

        // GET: ProductoImagenes/Index/5 (para ver las imágenes de un producto específico)
        public async Task<IActionResult> Index(int? productoId)
        {
            if (productoId == null)
            {
                var productos = await _productoServicio.ObtenerTodosLosProductosAsync();
                ViewBag.Productos = productos; // Asegúrate de pasar la lista de productos al ViewBag
                return View("SeleccionarProducto"); // Asegúrate de que la vista correcta esté siendo llamada
            }

            // Si hay productoId, carga las imágenes correspondientes
            var imagenes = await _productoImagenServicio.ObtenerImagenesPorProductoIdAsync((int)productoId);
            var producto = await _productoServicio.ObtenerProductoPorIdAsync((int)productoId);

            if (producto == null)
            {
                return NotFound();
            }

            ViewBag.Producto = producto;
            return View(imagenes);
        }




        // GET: ProductoImagenes/Crear
        public async Task<IActionResult> Crear(int productoId)
        {
            var producto = await _productoServicio.ObtenerProductoPorIdAsync(productoId);
            if (producto == null)
            {
                return NotFound();
            }

            ViewBag.Producto = producto;  // Información del producto
            return View(new ProductoImagene { ProductoId = productoId });
        }

        // POST: ProductoImagenes/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(ProductoImagene productoImagene)
        {
            if (ModelState.IsValid)
            {
                await _productoImagenServicio.InsertarImagenAsync(productoImagene);
                return Json(new { success = true, message = "Imagen creada con éxito", productoId = productoImagene.ProductoId });
            }

            var producto = await _productoServicio.ObtenerProductoPorIdAsync(productoImagene.ProductoId);
            if (producto == null)
            {
                return NotFound();
            }

            ViewBag.Producto = producto;
            return Json(new { success = false, message = "Error al crear la imagen" });
        }

        // GET: ProductoImagenes/Editar/5
        public async Task<IActionResult> Editar(int id)
        {
            var imagen = await _productoImagenServicio.ObtenerImagenPorIdAsync(id); // Obtener la imagen
            if (imagen == null)
            {
                return NotFound();
            }

            var producto = await _productoServicio.ObtenerProductoPorIdAsync(imagen.ProductoId);
            if (producto == null)
            {
                return NotFound();
            }

            ViewBag.Producto = producto;
            return View(imagen);
        }

        // POST: ProductoImagenes/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, ProductoImagene imagen)
        {
            if (id != imagen.ImagenId)
            {
                return Json(new { success = false, message = "El ID de la imagen no coincide" });
            }

            if (ModelState.IsValid)
            {
                await _productoImagenServicio.ActualizarImagenAsync(imagen);
                return Json(new { success = true, message = "Imagen actualizada con éxito", productoId = imagen.ProductoId });
            }

            var producto = await _productoServicio.ObtenerProductoPorIdAsync(imagen.ProductoId);
            if (producto == null)
            {
                return NotFound();
            }

            ViewBag.Producto = producto;
            return Json(new { success = false, message = "Error al actualizar la imagen" });
        }



        // POST: ProductoImagenes/Eliminar/5
        public async Task<IActionResult> Eliminar(int id)
        {
            var imagen = await _productoImagenServicio.ObtenerImagenPorIdAsync(id);
            if (imagen == null)
            {
                return NotFound();
            }
            return View(imagen);
        }

        [HttpPost]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            try
            {
                // Obtener la imagen por ID
                var imagen = await _productoImagenServicio.ObtenerImagenPorIdAsync(id);
                if (imagen == null)
                {
                    return Json(new { success = false, message = "Imagen no encontrada" });
                }

                // Eliminar la imagen
                var resultado = await _productoImagenServicio.EliminarImagenAsync(id);
                if (resultado > 0)
                {
                    return Json(new { success = true, message = "Imagen eliminada con éxito" });
                }

                return Json(new { success = false, message = "Error al eliminar la imagen" });
            }
            catch (Exception ex)
            {
                // Loguear el error y devolver mensaje
                // Aquí puedes loguear el error a tu sistema de logs
                return Json(new { success = false, message = "Ocurrió un error al intentar eliminar la imagen. Error: " + ex.Message });
            }
        }



    }
}
