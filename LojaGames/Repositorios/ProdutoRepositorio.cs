using MySql.Data.MySqlClient;
using LojaGames.Models;
using System.Configuration;
using System.Data;
using LojaGames.Repositorios;


namespace LojaGames.Repositorios
{
    public class ProdutoRepositorio(IConfiguration configuration)
    {
        private readonly string _connectionString = configuration.GetConnectionString("MySQLConnection");

        public void AdicionarProduto(Tb_produto produto)
        {
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.MySqlCommand();

                cmd.CommandText = "INSERT INTO Tb_produto (Nome_prod, Descricao_prod, ValorCusto_prod,ValorVenda_prod, Desconto_prod, Tipo_prod, Marca_prod, QuantidadeEstoque_prod) VALUES (@Nome,@Descricao,@Custo,@Venda,@Desconto,@tipo,@marca,@quantidade)";
                cmd.Parameters.AddWithValue("@Nome", produto.Nome_prod);
                cmd.Parameters.AddWithValue("@Descricao", produto.Descricao_prod);
                cmd.Parameters.AddWithValue("@Custo", produto.ValorCusto_prod);
                cmd.Parameters.AddWithValue("@Venda", (produto.Desconto_prod)*(produto.ValorCusto_prod));
                cmd.Parameters.AddWithValue("@Desconto", produto.Desconto_prod);
                cmd.Parameters.AddWithValue("@tipo", produto.Tipo_prod);
                cmd.Parameters.AddWithValue("@marca", produto.Marca_prod);
                cmd.Parameters.AddWithValue("@quantidade", produto.QuantidadeEstoque_prod);
                cmd.ExecuteNonQuery();
            }
        }




    }
}
