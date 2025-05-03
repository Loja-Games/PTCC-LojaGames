using LojaGames.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace LojaGames.Controllers
{
    public class LoginControler : Controller
    {/*
        private readonly UsuarioRepositorio _usuarioRepositorio;

        public LoginControler(UsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        */

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login() 
        {
            return View();
        }
    }
}
