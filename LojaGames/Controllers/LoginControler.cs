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
        

        public IActionResult Cadastro()
        {
            return View(LoginGlobal.usuario);
        }

        public IActionResult Login()
        {
            if (LoginGlobal.usuario.Usuario_cli != "Minha Conta")
            {
                return RedirectToAction("Conta", "Conta");
            }
            else
            {
                return View(LoginGlobal.usuario);
            }
        }



        [HttpPost]
        public IActionResult Cadastro(string nome, string cpf, string usuario, string senha, string email)
        {
            Tb_usuario tb_Usuario = new Tb_usuario();
            tb_Usuario.Cpf_cli = cpf;
            tb_Usuario.Usuario_cli = usuario;
            tb_Usuario.Senha_cli = senha;
            Tb_cliente tb_Cliente = new Tb_cliente();
            tb_Cliente.Cpf_cli = cpf;
            tb_Cliente.Nome_cli = nome;
            Tb_email tb_Email = new Tb_email();
            tb_Email.Cpf_cli = cpf;
            tb_Email.Email = email;

            if (_usuarioRepositorio.ValidarExistenciaUsuario(tb_Usuario) == false)
            {
                _usuarioRepositorio.AdicionarUsuario(tb_Usuario, tb_Cliente, tb_Email);
                return RedirectToAction("Login", "LoginControler");
            }
            else
            {
                ModelState.AddModelError("", "Esse CPF e esse Usuario ja estao cadastrados");
                return View();
            }




       
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
                LoginGlobal.usuario = usuario;
                LoginGlobal.usuario.alterarEmail(_usuarioRepositorio.ObterEmail(usuario));
                LoginGlobal.usuario.alterarNome(_usuarioRepositorio.ObterNome(usuario));
                return RedirectToAction("Conta", "Conta"); /* Destino Após o login */
            }

            ModelState.AddModelError("", "Os dados de Login são invalidos.");
            return View();
        }
    }
}
