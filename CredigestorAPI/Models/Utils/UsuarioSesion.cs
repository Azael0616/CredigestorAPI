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
    }
}
