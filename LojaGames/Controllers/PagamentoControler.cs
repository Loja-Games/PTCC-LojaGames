using LojaGames.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace LojaGames.Controllers
{
    public class PagamentoControler : Controller
    {
        private readonly ProdutoRepositorio _produtoRepositorio;

        public PagamentoControler(ProdutoRepositorio produtoRepositorio)
        {
         _produtoRepositorio = produtoRepositorio;
        }



        public IActionResult Pagamento()
        {

            _produtoRepositorio.listadeprodutoserdados.listadeprodutos = _produtoRepositorio.ListaProdutos();
            _produtoRepositorio.listadeprodutoserdados.listacarrinho = _produtoRepositorio.listaCarrinho(HttpContext.Session.GetString("Pedido"));
            return View(_produtoRepositorio.listadeprodutoserdados);
        }
    }
}
