using Microsoft.AspNetCore.Mvc;

namespace LojaGames.Controllers
{
    public class ProcuraControler : Controller
    {
        public IActionResult Procura()
        {
            return View();
        }
    }
}
