using Microsoft.AspNetCore.Mvc;

namespace LojaGames.Controllers
{
    public class ContaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Conta()
        {
            return View();
        }
    }
}
