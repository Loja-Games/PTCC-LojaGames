using LojaGames.Models;
using LojaGames.Repositorios;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LojaGames.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProdutoRepositorio _produtoRepositorio;

        public HomeController(ILogger<HomeController> logger, ProdutoRepositorio produtoRepositorio)
        {
            _logger = logger;
            _produtoRepositorio = produtoRepositorio;
        }

        public IActionResult Index()
        {


            if (HttpContext.Session.GetString("perfil") != "Entrar na Conta" && string.IsNullOrEmpty(HttpContext.Session.GetString("perfil")) == false)
            {
                _produtoRepositorio.listadeprodutoserdados.listadeprodutos = _produtoRepositorio.ListaProdutos("Xbox");
                _produtoRepositorio.listadeprodutoserdados.listacarrinho = _produtoRepositorio.listaCarrinho(HttpContext.Session.GetString("Pedido"));
                return View(_produtoRepositorio.listadeprodutoserdados);
            }
            else
            {
                _produtoRepositorio.listadeprodutoserdados.listadeprodutos = _produtoRepositorio.ListaProdutos("Xbox");
                return View(_produtoRepositorio.listadeprodutoserdados);
            }
            
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
