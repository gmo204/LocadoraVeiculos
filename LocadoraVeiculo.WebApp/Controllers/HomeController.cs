using Microsoft.AspNetCore.Mvc;

namespace LocadoraVeiculo.WebApp.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
