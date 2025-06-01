using LojaGames.Models;
using LojaGames.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace LojaGames.Controllers
{
    public class ContaController : Controller
    {
        private readonly UsuarioRepositorio _usuarioRepositorio;
        private readonly ProdutoRepositorio _produtoRepositorio;

        public ContaController(UsuarioRepositorio usuarioRepositorio, ProdutoRepositorio produtoRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _produtoRepositorio = produtoRepositorio;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Conta()
        {
            _produtoRepositorio.listadeprodutoserdados.listadeprodutos = _produtoRepositorio.ListaProdutos("Xbox");
            _produtoRepositorio.listadeprodutoserdados.listacarrinho = _produtoRepositorio.listaCarrinho(HttpContext.Session.GetString("Pedido"));
            return View(_produtoRepositorio.listadeprodutoserdados);
        }



    }
}
