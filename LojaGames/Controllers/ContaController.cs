using LojaGames.Models;
using LojaGames.Repositorios;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Cms;

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

        public IActionResult Dados()
        {
            Tb_usuario usuario = new Tb_usuario();
            usuario.Cpf_cli = HttpContext.Session.GetString("cpf");
            _produtoRepositorio.listadeprodutoserdados.usuario = _usuarioRepositorio.ObterUsuarioCpf(usuario);
            _produtoRepositorio.listadeprodutoserdados.listadohistorico = _produtoRepositorio.getHistorico(HttpContext.Session.GetString("cpf"));
            _produtoRepositorio.listadeprodutoserdados.listadeprodutos = _produtoRepositorio.ListaProdutos("Xbox");
            _produtoRepositorio.listadeprodutoserdados.listacarrinho = _produtoRepositorio.listaCarrinho(HttpContext.Session.GetString("Pedido"));
            return View(_produtoRepositorio.listadeprodutoserdados);
        }


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Conta()
        {
            Tb_usuario usuario = new Tb_usuario();
            usuario.Cpf_cli = HttpContext.Session.GetString("cpf");
            _produtoRepositorio.listadeprodutoserdados.usuario = _usuarioRepositorio.ObterUsuarioCpf(usuario);
            _produtoRepositorio.listadeprodutoserdados.listadohistorico = _produtoRepositorio.getHistorico(usuario.Cpf_cli);
            _produtoRepositorio.listadeprodutoserdados.listadeprodutos = _produtoRepositorio.ListaProdutos("Xbox");
            _produtoRepositorio.listadeprodutoserdados.listacarrinho = _produtoRepositorio.listaCarrinho(usuario.Cpf_cli);

            return View(_produtoRepositorio.listadeprodutoserdados);
        }



        // FOI NECESSARIO MUDAR A ROTA DA IMAGEM PROQUE O FETCH DO JAVASCRIPT NAO ESTAVA ACHANDO ESSE METODO
        [Route("conta/imagem")]
        [HttpPost]
        public IActionResult SalvarImagem(IFormFile imagemform)
        {
            string cpf = HttpContext.Session.GetString("cpf");
            byte[] imagemBytes;
            MemoryStream memoryStream = new MemoryStream();
            imagemform.CopyTo(memoryStream);
            imagemBytes = memoryStream.ToArray();
            if(_usuarioRepositorio.enviarImgBD(imagemBytes, cpf))
            {
                string nomeimagem = cpf + System.DateTime.Now.ToString("yyyyMMdd_HHmmss");
                byte[] imagemvolta = _usuarioRepositorio.receberImgBD(cpf);
                string caminhoimagem = _usuarioRepositorio.salvarByteLocal(imagemvolta,nomeimagem,"jpg");
                _usuarioRepositorio.salvarCaminhoBd(caminhoimagem,cpf);

                return Ok(caminhoimagem);
            }
            else
            {
                return Ok("Não foi possivel colocar a imagem no banco");
            }



        }




    }
}
