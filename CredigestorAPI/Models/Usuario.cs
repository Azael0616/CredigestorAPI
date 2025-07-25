using System.Data;

namespace CredigestorAPI.Models
{
    public class Usuario
    {
        public int UsuarioID { get; set; } = 0;
        public string Nombre_usuario { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Segundo_nombre { get; set; } = string.Empty;
        public string Apellido_paterno { get; set; } = string.Empty;
        public string Apellido_materno { get; set; } = string.Empty;
        public DateTime Fecha_nacimiento { get; set; } = DateTime.Now;
        public DateTime Fecha_ingreso { get; set; } = DateTime.Now;
        public string Telefono { get; set; } = string.Empty;
        public string Telefono_prefijo { get; set; } = string.Empty;
        public string Correo_electronico { get; set; } = string.Empty;
        public int NivelUsuarioID { get; set; } = 0;
        public Usuario()
        {

        }
        public Usuario(int usuarioid, string nombre_usuario, string passwordhash, string nombre, string segundo_nombre, string apellido_paterno, string apellido_materno,
            DateTime fecha_nacimiento, DateTime fecha_ingreso, string telefono, string telefono_prefijo, string correo_electronico, int nivelusuarioid)
        {
            this.UsuarioID = usuarioid;
            this.Nombre_usuario = nombre_usuario;
            this.PasswordHash = passwordhash;
            this.Nombre = nombre;
            this.Segundo_nombre = segundo_nombre;
            this.Apellido_paterno = apellido_paterno;
            this.Apellido_materno = apellido_materno;
            this.Fecha_nacimiento = fecha_nacimiento;
            this.Fecha_ingreso = fecha_ingreso;
            this.Telefono = telefono;
            this.Telefono_prefijo = telefono_prefijo;
            this.Correo_electronico = correo_electronico;
            this.NivelUsuarioID = nivelusuarioid;
        }        
    }
}
