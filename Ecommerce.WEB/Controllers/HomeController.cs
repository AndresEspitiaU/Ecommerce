using Ecommerce.PRC.Servicios;
using Ecommerce.BD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ecommerce.WEB.Models;
using System.Diagnostics;
using Ecommerce.BD.Repositorios;

namespace Ecommerce.WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BannerServicio _bannerServicio;
        private readonly ColeccionServicio _coleccionServicio;
        private readonly CategoriaServicio _categoriaServicio;
        private readonly ProductoServicio _productoServicio;
        private readonly MarcaServicio _marcaServicio;


        public HomeController(ILogger<HomeController> logger, BannerServicio bannerServicio, ColeccionServicio coleccionServicio, CategoriaServicio categoriaServicio, ProductoServicio productoServicio, MarcaServicio marcaServicio)
        {
            _logger = logger;
            _bannerServicio = bannerServicio;
            _coleccionServicio = coleccionServicio;
            _categoriaServicio = categoriaServicio;
            _productoServicio = productoServicio;
            _marcaServicio = marcaServicio;
        }

        public async Task<IActionResult> Index()
        {
            List<Banner> bannersActivos = await _bannerServicio.ObtenerBannersActivosAsync();
            List<Coleccione> coleccionesActivas = await _coleccionServicio.ObtenerColeccionesActivasAsync();
            List<Categoria> categorias = await _categoriaServicio.ObtenerTodasLasCategoriasAsync();

            // Obtener solo productos activos
            var productosActivos = await _productoServicio.ObtenerProductosActivosAsync(null);
            var numeroDeProductosPorCategoria = new Dictionary<int, int>();

            foreach (var categoria in categorias)
            {
                int numeroDeProductos = await _productoServicio.ContarProductosPorCategoriaAsync(categoria.CategoriaId);
                numeroDeProductosPorCategoria[categoria.CategoriaId] = numeroDeProductos;
            }

            ViewData["Categorias"] = categorias;
            ViewData["BannersActivos"] = bannersActivos;
            ViewData["ColeccionesActivas"] = coleccionesActivas;
            ViewData["NumeroDeProductosPorCategoria"] = numeroDeProductosPorCategoria;
            ViewData["Productos"] = productosActivos;

            Console.WriteLine($"Se encontraron {coleccionesActivas.Count} colecciones activas");
            return View();
        }

        public async Task<IActionResult> DetalleProducto(int id)
        {
            var producto = await _productoServicio.ObtenerProductoPorIdAsync(id);
            if (producto == null)
            {
                return NotFound(); 
            }

            return View(producto);
        }

        public async Task<IActionResult> CargarProductosPorCategoria(int categoriaId)
        {
            var productos = await _productoServicio.ObtenerTodosLosProductosAsync(categoriaId);
            if (productos == null || !productos.Any())
            {
                return PartialView("_Productos", Enumerable.Empty<Producto>());
            }

            return PartialView("_Productos", productos);
        }


        public async Task<IActionResult> Shop(string categoriaIds, string marcaIds, decimal? precioMin = null, decimal? precioMax = null)
        {
            // Convertir los IDs de categorías y marcas a listas de enteros
            var categorias = !string.IsNullOrEmpty(categoriaIds)
                ? categoriaIds.Split(',').Select(int.Parse).ToList()
                : new List<int>();

            var marcas = !string.IsNullOrEmpty(marcaIds)
                ? marcaIds.Split(',').Select(int.Parse).ToList()
                : new List<int>();

            // Obtener los productos filtrados
            var productosFiltrados = await _productoServicio.ObtenerProductosFiltradosAsync(categorias, marcas, precioMin, precioMax);

            // Obtener todas las categorías y marcas para mostrar los filtros
            var todasLasCategorias = await _categoriaServicio.ObtenerTodasLasCategoriasAsync();
            var todasLasMarcas = await _marcaServicio.ObtenerTodasLasMarcasAsync();

            ViewData["Categorias"] = todasLasCategorias;
            ViewData["Marcas"] = todasLasMarcas;

            return View(productosFiltrados);
        }




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
