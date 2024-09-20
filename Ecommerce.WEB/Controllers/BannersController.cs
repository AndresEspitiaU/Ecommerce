using Ecommerce.BD.Models;
using Ecommerce.PRC.Servicios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ecommerce.WEB.Controllers
{
    [Authorize(Roles = "Administrador")] 
    public class BannersController : Controller
    {
        private readonly BannerServicio _bannerServicio;

        public BannersController(BannerServicio bannerServicio)
        {
            _bannerServicio = bannerServicio;
        }

        // GET: Banners/Index
        public async Task<IActionResult> Index()
        {
            var banners = await _bannerServicio.ObtenerTodosLosBannersAsync();
            return View(banners);
        }

        // GET: Banners/Crear
        public IActionResult Crear()
        {
            return View();
        }

        // POST: Banners/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Banner banner)
        {
            if (ModelState.IsValid)
            {
                banner.FechaCreacion = DateTime.Now;
                banner.FechaActualizacion = DateTime.Now;

                await _bannerServicio.InsertarBannerAsync(banner); 
                return RedirectToAction(nameof(Index));
            }

            return View(banner);
        }


        // GET: Banners/Editar/5
        public async Task<IActionResult> Editar(int id)
        {
            var banner = await _bannerServicio.ObtenerBannerPorIdAsync(id);
            if (banner == null)
            {
                return NotFound();
            }

            return View(banner);
        }

        // POST: Banners/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Banner banner)
        {
            if (id != banner.BannerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _bannerServicio.ActualizarBannerAsync(banner);
                return RedirectToAction(nameof(Index));
            }

            return View(banner);
        }

        // POST: Banners/Eliminar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Eliminar(int id)
        {
            var banner = await _bannerServicio.ObtenerBannerPorIdAsync(id);
            if (banner == null)
            {
                return Json(new { success = false, message = "Banner no encontrado." });
            }

            await _bannerServicio.EliminarBannerAsync(id);
            return Json(new { success = true, message = "Banner eliminado con éxito." });
        }
    }
}
