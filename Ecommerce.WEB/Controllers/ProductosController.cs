using Ecommerce.BD.Models;
using Ecommerce.PRC.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce.WEB.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ProductoServicio _productoServicio;
        private readonly CategoriaServicio _categoriaServicio;  
        private readonly SubcategoriaServicio _subcategoriaServicio;  
        private readonly MarcaServicio _marcaServicio; 
        private readonly ColeccionServicio _coleccionServicio;  
        private readonly GeneroServicio _generoServicio;  

        public ProductosController(
            ProductoServicio productoServicio,
            CategoriaServicio categoriaServicio,
            SubcategoriaServicio subcategoriaServicio,
            MarcaServicio marcaServicio,
            ColeccionServicio coleccionServicio,
            GeneroServicio generoServicio)
        {
            _productoServicio = productoServicio;
            _categoriaServicio = categoriaServicio;
            _subcategoriaServicio = subcategoriaServicio;
            _marcaServicio = marcaServicio;
            _coleccionServicio = coleccionServicio;
            _generoServicio = generoServicio;
        }

        /// <summary>
        /// Devuelve una lista de todos los productos
        /// Metodo GET para la vista Index
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            List<Producto> TodosLosProductos = await _productoServicio.ObtenerTodosLosProductosAsync(null);
            return View(TodosLosProductos);
        }

        /// <summary>
        /// Devuelve un producto por ID
        /// Metodo GET para la vista Detalles
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Detalles(int id)
        {
            var producto = await _productoServicio.ObtenerProductoPorIdAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // GET: Productos/Crear
        public async Task<IActionResult> Crear()
        {
            await CargarDatosFormulario(); // Método para cargar los datos de las listas desplegables
            return View();
        }

        // POST: Productos/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Producto producto)
        {
            if (ModelState.IsValid)
            {
                await _productoServicio.CrearProductoAsync(producto);
                return Json(new { success = true, message = "Producto creado con éxito" });
            }

            return Json(new { success = false, message = "Error al crear el producto" });
        }

        // GET: Productos/Editar/5
        public async Task<IActionResult> Editar(int id)
        {
            var producto = await _productoServicio.ObtenerProductoPorIdAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            await CargarDatosFormulario(producto); // Método para cargar los datos y pasar el producto seleccionado
            return View(producto);
        }

        // POST: Productos/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Producto producto)
        {
            if (id != producto.ProductoId)
            {
                return Json(new { success = false, message = "El ID del producto no coincide." });
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _productoServicio.ActualizarProductoAsync(producto);
                    return Json(new { success = true, message = "Producto actualizado con éxito." });
                }
                catch (Exception ex)
                {
                    // Manejar cualquier excepción durante la actualización
                    return Json(new { success = false, message = "Error al actualizar el producto: " + ex.Message });
                }
            }
            else
            {
                // Si la validación falla, enviar un mensaje de error
                return Json(new { success = false, message = "Hay errores en el formulario. Por favor, revísalo." });
            }
        }


        // GET: Productos/Eliminar/5
        public async Task<IActionResult> Eliminar(int id)
        {
            var producto = await _productoServicio.ObtenerProductoPorIdAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);  // Puedes omitir esta vista si no la necesitas
        }

        // POST: Productos/EliminarConfirmado
        [HttpPost]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            await _productoServicio.EliminarProductoAsync(id);  // Llamar al servicio para eliminar el producto
            return Json(new { success = true });  // Devolver un JSON indicando éxito
        }


        // Método para cargar las listas de categorías, subcategorías, marcas, colecciones y géneros
        private async Task CargarDatosFormulario(Producto producto = null)
        {
            ViewBag.Categorias = new SelectList(await _categoriaServicio.ObtenerTodasLasCategoriasAsync(), "CategoriaId", "CatNombre", producto?.ProCategoriaId);
            ViewBag.Subcategorias = new SelectList(await _subcategoriaServicio.ObtenerTodasLasSubcategoriasAsync(), "SubcategoriaId", "SubNombre", producto?.SubcategoriaId);
            ViewBag.Marcas = new SelectList(await _marcaServicio.ObtenerTodasLasMarcasAsync(), "MarcaId", "MarNombre", producto?.ProMarcaId);
            ViewBag.Colecciones = new SelectList(await _coleccionServicio.ObtenerTodasLasColeccionesAsync(), "ColeccionId", "ColNombre", producto?.ProColeccionId);
            ViewBag.Generos = new SelectList(await _generoServicio.ObtenerTodosLosGenerosAsync(), "GeneroId", "GenNombre", producto?.ProGeneroId);
        }

        // Acción para obtener productos por categoría
        public async Task<IActionResult> ProductosPorCategoria(int categoriaId, string searchTerm = "", decimal? minPrice = null, decimal? maxPrice = null)
        {
            List<Producto> productos = await _productoServicio.ObtenerTodosLosProductosAsync(categoriaId);
            if (!string.IsNullOrEmpty(searchTerm))
            {
                productos = productos.Where(p => p.ProNombre.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (minPrice.HasValue)
            {
                productos = productos.Where(p => p.ProPrecio >= minPrice.Value).ToList();
            }
            if (maxPrice.HasValue)
            {
                productos = productos.Where(p => p.ProPrecio <= maxPrice.Value).ToList();
            }
            ViewData["CategoriaId"] = categoriaId;
            ViewData["SearchTerm"] = searchTerm;
            ViewData["MinPrice"] = minPrice;
            ViewData["MaxPrice"] = maxPrice;
            return View(productos);
        }


    }
}
