using Ecommerce.BD.Models;
using Ecommerce.PRC.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ecommerce.WEB.Controllers
{
    public class MarcasController : Controller
    {
        private readonly MarcaServicio _marcaServicio;

        public MarcasController(MarcaServicio marcaServicio)
        {
            _marcaServicio = marcaServicio;
        }

        // Listar todas las marcas
        public async Task<IActionResult> Index()
        {
            var marcas = await _marcaServicio.ObtenerTodasLasMarcasAsync();
            return View(marcas);
        }

        // Crear una nueva marca (GET)
        public IActionResult Crear()
        {
            return View();
        }

        // Crear una nueva marca (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Marca marca)
        {
            if (ModelState.IsValid)
            {
                await _marcaServicio.CrearMarcaAsync(marca);
                return RedirectToAction(nameof(Index));
            }
            return View(marca);
        }

        // Editar marca (GET)
        public async Task<IActionResult> Editar(int id)
        {
            var marca = await _marcaServicio.ObtenerMarcaPorIdAsync(id);
            if (marca == null)
            {
                return NotFound();
            }
            return View(marca);
        }

        // Editar marca (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Marca marca)
        {
            if (ModelState.IsValid)
            {
                await _marcaServicio.ActualizarMarcaAsync(marca);
                return RedirectToAction(nameof(Index));
            }
            return View(marca);
        }

        // Eliminar marca (GET)
        public async Task<IActionResult> Eliminar(int id)
        {
            var marca = await _marcaServicio.ObtenerMarcaPorIdAsync(id);
            if (marca == null)
            {
                return NotFound();
            }

            // Llamar al servicio para eliminar la marca
            await _marcaServicio.EliminarMarcaAsync(id);

            // Redirigir nuevamente a la lista de marcas después de la eliminación
            return RedirectToAction(nameof(Index));
        }




        // Eliminar marca (POST)
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarEliminar(int id)
        {
            await _marcaServicio.EliminarMarcaAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
