using System.Data;

namespace CredigestorAPI.Models.Utils
{
    public class UsuarioLogin
    {
        public string Nombre_usuario {  get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public UsuarioLogin() { }
        public UsuarioLogin(string nombre_usuario, string password) {
            this.Nombre_usuario = nombre_usuario;
            this.Password = password;
        }        
    }
}
