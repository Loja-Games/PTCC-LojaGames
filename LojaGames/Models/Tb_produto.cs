namespace LojaGames.Models
{
    public class Tb_produto
    {
        public int Id_prod {  get; set; }
        public string Nome_prod {  get; set; }
        public string Descricao_prod { get; set; }
        public decimal ValorCusto_prod { get; set; }
        public decimal ValorVenda_prod { get; set; }
        public decimal Desconto_prod { get; set; }
        public string Tipo_prod { get; set; }
        public string Marca_prod { get; set; }
        public int QuantidadeEstoque_prod { get; set; }
        public bool VendaDisponivel_prod { get; set; }
    }
}
