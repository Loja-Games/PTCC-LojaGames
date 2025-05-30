using LojaGames.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace LojaGames.Controllers
{
    public class Endereco : Controller
    {

        private readonly ProdutoRepositorio _produtoRepositorio;

        public Endereco(ProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }
        public IActionResult EnderecoLista()
        {
            return View(_produtoRepositorio.listadeprodutoserdados);
        }
    }
}
