using System.Data;

namespace CredigestorAPI.Models
{
    public class Nivel_usuario
    {
        public int NivelUsuarioID { get; set; } = 0;
        public string Nombre { get; set; } = string.Empty;
        public bool Activo { get; set; } = false;
        public bool Solo_administrador { get; set; } = false;
        public Nivel_usuario() { }
        public Nivel_usuario(int nivelusuarioid, string nombre, bool activo, bool solo_administrador)
        {
            this.NivelUsuarioID = nivelusuarioid;
            this.Nombre = nombre;
            this.Activo = activo;
            this.Solo_administrador = solo_administrador;
        }        
    }
}
