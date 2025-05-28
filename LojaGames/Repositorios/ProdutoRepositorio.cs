using MySql.Data.MySqlClient;
using LojaGames.Models;
using System.Configuration;
using System.Data;
using LojaGames.Repositorios;
using MySqlX.XDevAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mysqlx.Crud;


namespace LojaGames.Repositorios
{
    public class ProdutoRepositorio(IConfiguration configuration)
    {
        public ListasProdutos listadeprodutoserdados = new ListasProdutos();
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
                cmd.Parameters.AddWithValue("@Venda", (produto.Desconto_prod) * (produto.ValorCusto_prod));
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

        public Tb_produto ObterProduto(int id)
        {
            using (var db = new Conexao(_connectionString))
            {
                var Prompt = db.MySqlCommand();
                Prompt.CommandText = $"Select * from Tb_produto where Id_prod={id}";

                using (var reader = Prompt.ExecuteReader())
                {
                    if (reader.Read())
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

                        return produto;
                    }

                    return new Tb_produto();
                }

            }
        }

        public IEnumerable<Tb_carrinho> listaCarrinho(string id)
        {
            using (var db = new Conexao(_connectionString))
            {
                string pedido = id;

                List<Tb_carrinho> listacarrinho = new List<Tb_carrinho>();
                var Prompt = db.MySqlCommand();
                Prompt.CommandText = $"Select * from Tb_carrinho where Id_pedido={pedido}";

                using (var reader = Prompt.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Tb_carrinho carrinho = new Tb_carrinho
                        {
                            Id_carrinho = reader.GetInt32("Id_carrinho"),
                            Cpf_cli = reader.GetString("Cpf_cli"),
                            Id_prod = reader.GetInt32("Id_prod"),
                            preco_prod = reader.GetDecimal("preco_prod"),
                            tb_Produto = ObterProduto(reader.GetInt32("Id_prod"))
                        };

                        listacarrinho.Add(carrinho);
                    }

                    return listacarrinho;
                }

            }
        }


        public string novoPedido()
        {
            using (var db = new Conexao(_connectionString))
            {
                var Prompt = db.MySqlCommand();
                Prompt.CommandText = "select max(Id_pedido) as 'max' from Tb_carrinho";

                using (var reader = Prompt.ExecuteReader())
                {
                    if (reader.Read() && reader.IsDBNull("max") == false)
                    {
                        return Convert.ToString(reader.GetInt32("max") + 1); 
                    }
                    else
                    {
                        return "0";
                    }
                }

            }
        }

        public void carrinhoNovoProd(Tb_carrinho tb_Carrinho)
        {
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.MySqlCommand();

                cmd.CommandText = "INSERT INTO Tb_carrinho (Id_pedido, Cpf_cli, Id_prod,Id_pag, quantidade, preco_prod) VALUES (@Id_pedido,@cpf,@Id_prod,@Id_pag,@quantidade,@preco_prod)";
                cmd.Parameters.AddWithValue("@Id_pedido", tb_Carrinho.Id_pedido);
                cmd.Parameters.AddWithValue("@cpf", tb_Carrinho.Cpf_cli);
                cmd.Parameters.AddWithValue("@Id_prod", tb_Carrinho.Id_prod);
                cmd.Parameters.AddWithValue("@Id_pag", (tb_Carrinho.Id_pag));
                cmd.Parameters.AddWithValue("@quantidade", tb_Carrinho.quantidade);
                cmd.Parameters.AddWithValue("@preco_prod", tb_Carrinho.preco_prod);
                cmd.ExecuteNonQuery();
            }
        }


        public void registrarPagBoleto(string id)
        {
            string Idpedido = id;
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.MySqlCommand();
                cmd.CommandText = "SET SQL_SAFE_UPDATES = 0;Update Tb_carrinho set Id_pag=4,inforamacaoad_pag='Pagamento de Boleto Online', Data_pedido_car=curdate(), Data_entrega_car=DATE_ADD(CURDATE(), INTERVAL 3 DAY),Tipo_entrega_car='Premium' where Id_pedido=@ID;SET SQL_SAFE_UPDATES = 1;";
                cmd.Parameters.AddWithValue("@ID", Idpedido);
                cmd.ExecuteNonQuery();
            }
        }
        public void registrarPagDebt(string id, string numero, string nome)
        {
            string Idpedido = id;
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.MySqlCommand();
                cmd.CommandText = $"SET SQL_SAFE_UPDATES = 0;Update Tb_carrinho set Id_pag=2,inforamacaoad_pag='(Cartao de Debito) Dono: {nome}, Cartao: {numero}', Data_pedido_car=curdate(), Data_entrega_car=DATE_ADD(CURDATE(), INTERVAL 3 DAY),Tipo_entrega_car='Premium' where Id_pedido=@ID;SET SQL_SAFE_UPDATES = 1;";
                cmd.Parameters.AddWithValue("@ID", Idpedido);
                cmd.ExecuteNonQuery();
            }
            
        }
        public void registrarPagCred(string id, string numero, string nome)
        {
            string Idpedido = id;
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.MySqlCommand();
                cmd.CommandText = $"SET SQL_SAFE_UPDATES = 0;Update Tb_carrinho set Id_pag=3,inforamacaoad_pag='(Cartao de credito) Dono: {nome}, Cartao: {numero}', Data_pedido_car=curdate(), Data_entrega_car=DATE_ADD(CURDATE(), INTERVAL 3 DAY),Tipo_entrega_car='Premium' where Id_pedido=@ID;SET SQL_SAFE_UPDATES = 1;";
                cmd.Parameters.AddWithValue("@ID", Idpedido);
                cmd.ExecuteNonQuery();
            }
        }
        public void registrarPagQrcode(string id)
        {
            string Idpedido = id;
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.MySqlCommand();
                cmd.CommandText = "SET SQL_SAFE_UPDATES = 0;Update Tb_carrinho set Id_pag=5,inforamacaoad_pag='PIX Online', Data_pedido_car=curdate(), Data_entrega_car=DATE_ADD(CURDATE(), INTERVAL 3 DAY),Tipo_entrega_car='Premium' where Id_pedido=@ID;SET SQL_SAFE_UPDATES = 1;";
                cmd.Parameters.AddWithValue("@ID", Idpedido);
                cmd.ExecuteNonQuery();
            }
        }







    }
}
