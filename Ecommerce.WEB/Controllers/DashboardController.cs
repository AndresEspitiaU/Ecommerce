using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WEB.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
