namespace LojaGames.Models
{
    public class LoginGlobal
    {
        public static Tb_usuario usuario { get; set; } = new Tb_usuario { Usuario_cli = "Minha Conta" };
        public static Tb_email Email { get; set; } = new Tb_email { Email = "Nenhum Email" };
        public static Tb_endereco Endereco { get; set; } = new Tb_endereco { Endereco = "Nenhum Endereco", Cep = "Nenhum CEP", Complemento = "Nenhum Complemento", Numero_residencia = "Nenhum Numero", Uf_est = "Nenhum Estado" };
        public static Tb_cliente cliente { get; set; } = new Tb_cliente { Nome_cli = "Nenhum Nome" };

        public void AlterarEmail(string email)
        {
            usuario.Email = email;
        }
        public void AlterarNome(string nome)
        {
            usuario.Nome = nome;
        }

        public string GetUsuario() { return usuario.Usuario_cli; }
        public string GetEmail() { return Email.Email; }
        public string GetNome() { return cliente.Nome_cli; }
    }
}
