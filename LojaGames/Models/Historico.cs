namespace LojaGames.Models
{
    public class Historico
    {
        public int Id_carrinho { get; set; }
        public int Id_pedido { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco_prod { get; set; }
        public string Inforamacaoad_pag { get; set; }
        public DateTime Data_pedido_car { get; set; }
        public DateTime Data_entrega_car { get; set; }
        public string Tipo_entrega_car { get; set; }
        public string Nome_prod { get; set; }
        public string Descricao_prod { get; set; }
        public string Tipo_prod { get; set; }
        public string Marca_prod { get; set; }
        public string Img_path { get; set; }
        public decimal Desconto_prod { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string Numero_residencia { get; set; }
        public string Uf_est { get; set; }
        public string Nome_est { get; set; }
    }
}
