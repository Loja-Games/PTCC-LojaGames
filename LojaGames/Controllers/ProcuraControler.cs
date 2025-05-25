using Microsoft.AspNetCore.Mvc;
using LojaGames.Repositorios;
using LojaGames.Models;
using System.Reflection.PortableExecutable;

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
            if (pesquisa == null) { pesquisa = "Xbox"; }
            HttpContext.Session.SetString("redirecionarpesquisa", pesquisa);
            _produtoRepositorio.listadeprodutoserdados.listadeprodutos = _produtoRepositorio.ListaProdutos();

            if (HttpContext.Session.GetString("perfil") != "Entrar na Conta" && string.IsNullOrEmpty(HttpContext.Session.GetString("perfil")) == false)
            {
                _produtoRepositorio.listadeprodutoserdados.listacarrinho = _produtoRepositorio.listaCarrinho(HttpContext.Session.GetString("Pedido"));
            }
            return View(_produtoRepositorio.listadeprodutoserdados);
        }

        [HttpPost]
        public IActionResult adicionarCarrinho(string Id)
        {
            Tb_produto produto = _produtoRepositorio.ObterProduto(Convert.ToInt32(Id));

            Tb_carrinho carrinho = new Tb_carrinho
            {
                Cpf_cli = HttpContext.Session.GetString("cpf"),
                Id_pedido = Convert.ToInt32(HttpContext.Session.GetString("Pedido")),
                Id_prod = produto.Id_prod,
                preco_prod = produto.ValorVenda_prod,
                Id_pag = 1,
                quantidade = 1,
            };

            _produtoRepositorio.carrinhoNovoProd(carrinho);

            return RedirectToAction("Procura");
        }

    }
}
