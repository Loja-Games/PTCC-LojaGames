using Microsoft.AspNetCore.Mvc;
using LojaGames.Repositorios;

namespace LojaGames.Controllers
{
    public class ProcuraControler : Controller
    {
        private readonly ProdutoRepositorio _produtoRepositorio;

        public ProcuraControler(ProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public IActionResult Procura(string pesquisa)
        {
            HttpContext.Session.SetString("redirecionarpesquisa", pesquisa);

            return View(_produtoRepositorio.ListaProdutos());
        }

        public void Teste()
        {
           
        }
    }
}
