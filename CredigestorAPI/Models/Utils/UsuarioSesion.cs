using System.Data;

namespace CredigestorAPI.Models.Utils
{
    public class UsuarioSesion
    {
        public int UsuarioID { get; set; } = 0;
        public string Nombre_usuario { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string NivelUsuario {  get; set; } = string.Empty;
        public int NivelUsuarioID { get; set; } = 0;        
        public UsuarioSesion() { }
        public UsuarioSesion(int usuarioid, string nombre_usuario, string nombre, string nivelusuario, int nivelusuarioid) {
            this.UsuarioID = usuarioid;
            this.Nombre_usuario = nombre_usuario;
            this.Nombre = nombre;
            this.NivelUsuario = nivelusuario;
            this.NivelUsuarioID = nivelusuarioid;            
        }
        public UsuarioSesion(DataRow dt)
        {
#nullable disable            
            UsuarioID = (dt.Table.Columns.Contains("UsuarioID") && dt["UsuarioID"] != DBNull.Value) ? int.Parse(dt["UsuarioID"].ToString()) : 0;
            Nombre_usuario = dt.Table.Columns.Contains("Nombre_usuario") && dt["Nombre_usuario"] != DBNull.Value ? dt["Nombre_usuario"].ToString() : "";
            Nombre = dt.Table.Columns.Contains("Nombre") && dt["Nombre"] != DBNull.Value ? dt["Nombre"].ToString() : "";
            NivelUsuario = dt.Table.Columns.Contains("NivelUsuario") && dt["NivelUsuario"] != DBNull.Value ? dt["NivelUsuario"].ToString() : "";
            NivelUsuarioID = (dt.Table.Columns.Contains("NivelUsuarioID") && dt["NivelUsuarioID"] != DBNull.Value) ? int.Parse(dt["NivelUsuarioID"].ToString()) : 0;
#nullable restore
        }
    }
}
