

namespace LojaGames.Models
{
    public class DadosUsuario
    {
        public Tb_email? Tb_email;
        public Tb_usuario? Tb_usuario;
        public Tb_endereco? Tb_endereco;
        public Tb_telefone? Tb_telefone;

        public DadosUsuario(Tb_usuario tb_Usuario, Tb_email tb_Email, Tb_endereco tb_Endereco, Tb_telefone tb_Telefone)
        {
            Tb_email = tb_Email;
            Tb_usuario = tb_Usuario;
            Tb_endereco = tb_Endereco;
            Tb_telefone = tb_Telefone;
        }
    }
}
