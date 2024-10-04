using Ecommerce.PRC.Servicios;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ecommerce.WEB.Controllers
{
    public class LogController : Controller
    {
        private readonly LogServicio _logServicio;
        private const int PageSize = 10; // Número de logs por página

        public LogController(LogServicio logServicio)
        {
            _logServicio = logServicio;
        }

        /// GET: Log
        public async Task<IActionResult> Index()
        {
            var logs = await _logServicio.ObtenerTodosLosLogsAsync();
            return View(logs); // Retorna la vista con la lista de logs
        }
    }
}
