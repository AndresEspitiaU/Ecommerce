using Ecommerce.BD.Models;
using Ecommerce.PRC.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ecommerce.WEB.Controllers
{
    public class LogController : Controller
    {
        private readonly LogServicio _logServicio;

        public LogController(LogServicio logServicio)
        {
            _logServicio = logServicio;
        }

        // Listar todos los logs
        public async Task<IActionResult> Index()
        {
            var logs = await _logServicio.ObtenerTodosLosLogsAsync();
            return View(logs);
        }
    }
}
