using MySql.Data.MySqlClient;
using LojaGames.Models;
using System.Configuration;
using System.Data;
using LojaGames.Repositorios;
using System.ComponentModel;


namespace LojaGames.Repositorios
{
    public class UsuarioRepositorio(IConfiguration configuration)
    {

        private readonly string _connectionString = configuration.GetConnectionString("MySQLConnection");

        private bool adicionarEstado(string uf, string nome)
        {
            try
            {
                var banco = new Conexao(_connectionString);
                var query = banco.MySqlCommand();

                query.CommandText = "Select * from Tb_estado where Uf_est=@uf";
                query.Parameters.AddWithValue("@uf", uf);
                using (var reader = query.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return true;
                    }
                }
                query.Parameters.Clear();
                query.CommandText = $"insert into Tb_estado(Uf_est,Nome_est) values(@uf,@nome)";
                query.Parameters.AddWithValue("@uf",uf);
                query.Parameters.AddWithValue("@nome", nome);
                query.ExecuteNonQuery();
                banco.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool adicionarCep(string cep, string cidade, string bairro)
        {
            try
            {
                var banco = new Conexao(_connectionString);
                var query = banco.MySqlCommand();

                query.CommandText = "Select * from Tb_cep where Cep=@cep";
                query.Parameters.AddWithValue("@cep", cep);
                using (var reader = query.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return true;
                    }
                }
                query.Parameters.Clear();
                query.CommandText = $"insert into Tb_cep(Cep,Bairro,Cidade) values(@cep,@bairro,@cidade)";
                query.Parameters.AddWithValue("@cep", cep);
                query.Parameters.AddWithValue("@bairro", bairro);
                query.Parameters.AddWithValue("@cidade", cidade);
                query.ExecuteNonQuery();
                banco.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void adicionarEndereco(string cpf, string cep,string numero,string uf,string endereco, string complemento, string cidade, string bairro,string estado)
        {
            try
            {
                if (adicionarEstado(uf, estado))
                {
                    Console.WriteLine("Estado Adicionado com Sucesso");
                }
                else
                {
                    Console.WriteLine("O Estado nao pode ser adicionado ao banco");
                }
                if (adicionarCep(cep, cidade, bairro))
                {
                    Console.WriteLine("Novo Cep cadastrado no banco com sucesso");
                }
                else
                {
                    Console.WriteLine("O Cep nao pode ser adicionado ao banco");
                }

                var banco = new Conexao(_connectionString);
                var query = banco.MySqlCommand();

                query.CommandText = $"insert into Tb_endereco(Cpf_cli,Cep,Numero_residencia,Uf_est,Endereco,Complemento) values(@cpf,@cep,@numero,@uf,@endereco,@complemento);";
                query.Parameters.AddWithValue("@cpf", cpf);
                query.Parameters.AddWithValue("@cep", cep);
                query.Parameters.AddWithValue("@numero", numero);
                query.Parameters.AddWithValue("@uf", uf);
                query.Parameters.AddWithValue("@endereco", endereco);
                query.Parameters.AddWithValue("@complemento", complemento);
                Console.WriteLine("Novo Endereco cadastrado com sucesso");
                query.ExecuteNonQuery();
                banco.Dispose();
            }
            catch
            {
                Console.WriteLine("Nao foi possivel cadastrar o endereco");
            }
        }

        public void AdicionarUsuario(Tb_usuario usuario, Tb_cliente cliente, Tb_email email)
        {
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.MySqlCommand();

                cmd.CommandText = "INSERT INTO Tb_cliente (Cpf_cli, Nome_cli) VALUES (@Cpf,@Nome)";
                cmd.Parameters.AddWithValue("@Cpf", cliente.Cpf_cli);
                cmd.Parameters.AddWithValue("@Nome", cliente.Nome_cli);
                cmd.ExecuteNonQuery();

            }
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.MySqlCommand();

                cmd.CommandText = "INSERT INTO Tb_usuario (Cpf_cli, Usuario_cli, Senha_cli) VALUES (@Cpf,@Usuario,@Senha)";
                cmd.Parameters.AddWithValue("@Cpf", usuario.Cpf_cli);
                cmd.Parameters.AddWithValue("@Usuario", usuario.Usuario_cli);
                cmd.Parameters.AddWithValue("@Senha", usuario.Senha_cli);
                cmd.ExecuteNonQuery();

            }
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.MySqlCommand();

                cmd.CommandText = "INSERT INTO Tb_email (Cpf_cli, Email) VALUES (@Cpf,@Email)";
                cmd.Parameters.AddWithValue("@Cpf", email.Cpf_cli);
                cmd.Parameters.AddWithValue("@Email", email.Email);
                cmd.ExecuteNonQuery();

            }
        }

        public bool ValidarExistenciaUsuario(Tb_usuario tb_Usuario)
        {
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.MySqlCommand();
                cmd.CommandText = "SELECT * FROM Tb_usuario WHERE Cpf_cli = @Cpf";
                cmd.Parameters.AddWithValue("@Cpf", tb_Usuario.Cpf_cli);
                cmd.ExecuteNonQuery();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var usuariobanco = new Tb_usuario
                        {
                            Cpf_cli = reader.GetString("Cpf_cli"),
                            Usuario_cli = reader.GetString("Usuario_cli"),
                        };
                        if (tb_Usuario.Cpf_cli == usuariobanco.Cpf_cli || tb_Usuario.Usuario_cli == usuariobanco.Usuario_cli)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }

        }

        
        public Tb_usuario ObterUsuarioCpf(Tb_usuario tb_Usuario)
        {
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.MySqlCommand();
                cmd.CommandText = "SELECT * FROM Tb_usuario WHERE Cpf_cli = @Cpf";
                cmd.Parameters.AddWithValue("@Cpf", tb_Usuario.Cpf_cli);
                cmd.ExecuteNonQuery();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Tb_usuario
                        {
                            Cpf_cli = reader.GetString("Cpf_cli"),
                            Usuario_cli = reader.GetString("Usuario_cli"),
                            Senha_cli = reader.GetString("Senha_cli"),
                            Cargo_cli = reader.GetString("Cargo_cli"),
                            Ativo_cli = reader.GetBoolean("Ativo_cli"),
                        };
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
        public Tb_usuario ObterUsuarioUsu(Tb_usuario tb_Usuario)
        {
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.MySqlCommand();
                cmd.CommandText = "SELECT * FROM Tb_usuario WHERE Usuario_cli = @Usuario";
                cmd.Parameters.AddWithValue("@Usuario", tb_Usuario.Usuario_cli);
                cmd.ExecuteNonQuery();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Tb_usuario
                        {
                            Cpf_cli = reader.GetString("Cpf_cli"),
                            Usuario_cli = reader.GetString("Usuario_cli"),
                            Senha_cli = reader.GetString("Senha_cli"),
                            Cargo_cli = reader.GetString("Cargo_cli"),
                            Ativo_cli = reader.GetBoolean("Ativo_cli"),
                        };
                    }
                }
                return new Tb_usuario();
            }
        }
        public string ObterEmail(Tb_usuario tb_Usuario)
        {
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.MySqlCommand();
                cmd.CommandText = "SELECT * FROM Tb_Email WHERE Cpf_cli = @Cpf";
                cmd.Parameters.AddWithValue("@Cpf", tb_Usuario.Cpf_cli);
                cmd.ExecuteNonQuery();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetString("Email");
                    }
                    else
                    {
                        return "nenhum Email";
                    }
                }
            }
        }
        public string ObterNome(Tb_usuario tb_Usuario)
        {
            using (var db = new Conexao(_connectionString))
            {
                var cmd = db.MySqlCommand();
                cmd.CommandText = "SELECT * FROM Tb_cliente WHERE Cpf_cli = @Cpf";
                cmd.Parameters.AddWithValue("@Cpf", tb_Usuario.Cpf_cli);
                cmd.ExecuteNonQuery();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetString("Nome_cli");
                    }
                    else
                    {
                        return "nenhum Nome";
                    }
                }
            }
        }
    }
}