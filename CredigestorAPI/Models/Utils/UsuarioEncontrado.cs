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
        public UsuarioEncontrado(DataRow dt)
        {
#nullable disable            
            this.UsuarioID = (dt.Table.Columns.Contains("UsuarioID") && dt["UsuarioID"] != DBNull.Value) ? int.Parse(dt["UsuarioID"].ToString()) : 0;
            this.Nombre_usuario = dt.Table.Columns.Contains("Nombre_usuario") && dt["Nombre_usuario"] != DBNull.Value ? dt["Nombre_usuario"].ToString() : "";
            this.Password = dt.Table.Columns.Contains("PasswordHash") && dt["PasswordHash"] != DBNull.Value ? dt["PasswordHash"].ToString() : "";
#nullable restore
        }
    }
}
