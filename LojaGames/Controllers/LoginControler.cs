using LojaGames.Models;
using LojaGames.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace LojaGames.Controllers
{
    public class LoginControler : Controller
    {
        private readonly UsuarioRepositorio _usuarioRepositorio;

        public LoginControler(UsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            // retorna a página Login
            return View();
        }

        [HttpPost]
        public IActionResult Login(string cpf, string senha)
        {

            Tb_usuario tb_Usuario = new Tb_usuario();
            tb_Usuario.Cpf_cli = cpf;
            tb_Usuario.Senha_cli = senha;

            var usuario = _usuarioRepositorio.ObterUsuarioCpf(tb_Usuario);

            if (usuario != null && tb_Usuario.Senha_cli == usuario.Senha_cli && tb_Usuario.Cpf_cli == usuario.Cpf_cli)
            {
                return RedirectToAction("Conta", "Conta"); /* Destino Após o login */
            }

            ModelState.AddModelError("", "Os dados de Login são invalidos.");
            return View();
        }
    }
}
