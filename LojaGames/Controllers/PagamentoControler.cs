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

        [HttpPost]
        public IActionResult Pagamento(string numerocartao, string datacartao, string cvccartao,string formulario,string nomecartao)
        {
            Console.WriteLine("Numero: "+numerocartao+" data do catao: "+datacartao+" cvc: "+cvccartao+" formulario: "+formulario+" nomecatao: "+nomecartao);

            string pedido = HttpContext.Session.GetString("Pedido");
            switch (formulario)
            {
                case "cartaocredito":
                    _produtoRepositorio.registrarPagCred(pedido,numerocartao,nomecartao);
                    HttpContext.Session.SetString("Pedido", _produtoRepositorio.novoPedido());

                    return RedirectToAction("Conta", "Conta");

                case "cartaodebito":
                    _produtoRepositorio.registrarPagDebt(pedido, numerocartao, nomecartao);
                    HttpContext.Session.SetString("Pedido", _produtoRepositorio.novoPedido());

                    return RedirectToAction("Conta", "Conta");

                case "boleto":
                    _produtoRepositorio.registrarPagBoleto(pedido);
                    HttpContext.Session.SetString("Pedido", _produtoRepositorio.novoPedido());

                    return RedirectToAction("Conta", "Conta");

                case "qrcode":
                    _produtoRepositorio.registrarPagQrcode(pedido);
                    HttpContext.Session.SetString("Pedido", _produtoRepositorio.novoPedido());

                    return RedirectToAction("Conta", "Conta");

                default:
                    Console.WriteLine("erro na seleção do formulario");
                    return View();
            }
            return View();
        }

    }
}
