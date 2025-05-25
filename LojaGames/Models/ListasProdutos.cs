using System.Reflection.PortableExecutable;

namespace LojaGames.Models
{
    public class ListasProdutos
    {
        public IEnumerable<Tb_produto> listadeprodutos { get; set; }

        public IEnumerable<Tb_carrinho>? listacarrinho { get; set; }

        public void teste()
        {

        }
    }
}
