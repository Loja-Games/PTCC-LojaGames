﻿using MySql.Data.MySqlClient;
using LojaGames.Models;
using System.Configuration;
using System.Data;
using LojaGames.Repositorios;


namespace LojaGames.Repositorios
{
    public class UsuarioRepositorio(IConfiguration configuration)
    {

        private readonly string _connectionString = configuration.GetConnectionString("MySQLConnection");

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