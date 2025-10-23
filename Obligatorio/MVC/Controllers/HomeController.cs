using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Diagnostics;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            int? lid = HttpContext.Session.GetInt32("LogueadoId");
            if (lid != null)
            {
                string LogueadoNombre = HttpContext.Session.GetString("LogueadoNombre");
                string LogueadoApellido = HttpContext.Session.GetString("LogueadoApellido");
                ViewBag.msgBienvenida = $"Hola {LogueadoNombre + " " + LogueadoApellido}";
            }
            else
            {
                ViewBag.msgBienvenida = $"Hola, inicie sesión porfavor";
            }
            return View();
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
