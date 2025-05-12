namespace LojaGames.Models
{
    public class LoginGlobal
    {
        public static Tb_usuario usuario { get; set; } = new Tb_usuario { Usuario_cli = "Minha Conta" };

        public Tb_usuario GetUsuario() { return usuario; }
    }
}
