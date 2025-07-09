using System.Data;

namespace CredigestorAPI.Models.Utils
{
    public class UsuarioLogin
    {
        public string Nombre_usuario {  get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public UsuarioLogin() { }
        public UsuarioLogin(string nombre_usuario, string password) {
            Nombre_usuario = nombre_usuario;
            Password = password;
        }
        public UsuarioLogin(DataRow dt)
        {
#nullable disable            
            Nombre_usuario = dt.Table.Columns.Contains("Nombre_usuario") && dt["Nombre_usuario"] != DBNull.Value ? dt["Nombre_usuario"].ToString() : "";
            Password = dt.Table.Columns.Contains("PasswordHash") && dt["PasswordHash"] != DBNull.Value ? dt["PasswordHash"].ToString() : "";
#nullable restore
        }
    }
}
