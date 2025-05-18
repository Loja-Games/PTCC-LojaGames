using MySql.Data.MySqlClient;
using LojaGames.Models;
using System.Configuration;
using System.Data;
using LojaGames.Repositorios;
using MySqlX.XDevAPI;


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

        public IEnumerable<Tb_produto> ListaProdutos()
        {
            using (var db = new Conexao(_connectionString))
            {
                List<Tb_produto> listaproduto = new List<Tb_produto>();
                var Prompt = db.MySqlCommand();
                Prompt.CommandText = "Select * from Tb_produto";

                using (var reader = Prompt.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Tb_produto produto = new Tb_produto
                        {
                            Id_prod = reader.GetInt32("Id_prod"),
                            Nome_prod = reader.GetString("Nome_prod"),
                            Descricao_prod = reader.GetString("Descricao_prod"),
                            ValorCusto_prod = reader.GetDecimal("ValorCusto_prod"),
                            ValorVenda_prod = reader.GetDecimal("ValorVenda_prod"),
                            Desconto_prod = reader.GetDecimal("Desconto_prod"),
                            Tipo_prod = reader.GetString("Tipo_prod"),
                            Marca_prod = reader.GetString("Marca_prod"),
                            QuantidadeEstoque_prod = reader.GetInt32("QuantidadeEstoque_prod"),
                            VendaDisponivel_prod = reader.GetBoolean("VendaDisponivel_prod"),
                            img_path = reader.GetString("img_path"),
                        };

                        listaproduto.Add(produto);
                    }
                    return listaproduto;
                }

            }
        }



    }
}
