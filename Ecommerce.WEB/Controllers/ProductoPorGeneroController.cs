using Ecommerce.PRC.Servicios;
using Ecommerce.BD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ecommerce.WEB.Controllers
{
    public class ProductoPorGeneroController : Controller
    {
        private readonly ProductoPorGeneroServicio _productoPorGeneroServicio;

        public ProductoPorGeneroController(ProductoPorGeneroServicio productoPorGeneroServicio)
        {
            _productoPorGeneroServicio = productoPorGeneroServicio;
        }



        /// <summary>
        /// Muestra los productos de un género específico
        /// </summary>
        /// <param name="nombreGenero"></param>
        /// <returns></returns>
        public async Task<IActionResult> Genero(string nombreGenero)
        {
            // Asegúrate de que el nombre de género sea "Hombre" o "Mujer", no en plural
            var productos = await _productoPorGeneroServicio.ObtenerProductosPorGeneroAsync(nombreGenero);

            if (productos == null || !productos.Any())
            {
                ViewBag.Mensaje = $"No se encontraron productos para el género {nombreGenero}";
                return View(productos);  // Asegúrate de que la vista maneja productos vacíos correctamente
            }

            ViewData["Genero"] = nombreGenero;
            return View(productos);
        }



    }
}
