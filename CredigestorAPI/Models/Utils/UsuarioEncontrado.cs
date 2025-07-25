using System.Data;

namespace CredigestorAPI.Models.Utils
{
    public class UsuarioEncontrado
    {
        public int UsuarioID { get; set; } = 0;
        public string Nombre_usuario { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public UsuarioEncontrado() { }
        public UsuarioEncontrado(int usuarioid, string nombre_usuario, string password)
        {
            this.UsuarioID = usuarioid;
            this.Nombre_usuario = nombre_usuario;
            this.Password = password;
        }        
    }
}
