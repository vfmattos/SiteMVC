using Microsoft.AspNetCore.Mvc;
using SiteMVC.Filters;

namespace SiteMVC.Controllers
{
    [LogadoFilter]
    public class Restrito : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
