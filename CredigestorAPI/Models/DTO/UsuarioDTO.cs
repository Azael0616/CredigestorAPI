using System.Data;

namespace CredigestorAPI.Models.DTO
{
    public class UsuarioDTO
    {
        public int UsuarioID { get; set; } = 0;
        public string Nombre_usuario { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Segundo_nombre { get; set; } = string.Empty;
        public string Apellido_paterno { get; set; } = string.Empty;
        public string Apellido_materno { get; set; } = string.Empty;
        public string Fecha_nacimiento { get; set; } = string.Empty;
        public string Fecha_ingreso { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;        
        public string Correo_electronico { get; set; } = string.Empty;
        public string NivelUsuario { get; set; } = string.Empty;
        public bool Correo_validado { get; set; } = false;
        public UsuarioDTO() { }
        public UsuarioDTO(int usuarioid, string nombre_usuario,string nombre, string segundo_nombre, string apellido_paterno, string apellido_materno,
            string fecha_nacimiento, string fecha_ingreso, string telefono, string correo_electronico, string nivelusuario, bool correovalidado)
        {
            this.UsuarioID = usuarioid;
            this.Nombre_usuario = nombre_usuario;            
            this.Nombre = nombre;
            this.Segundo_nombre = segundo_nombre;
            this.Apellido_paterno = apellido_paterno;
            this.Apellido_materno = apellido_materno;
            this.Fecha_nacimiento = fecha_nacimiento;
            this.Fecha_ingreso = fecha_ingreso;
            this.Telefono = telefono;            
            this.Correo_electronico = correo_electronico;
            this.NivelUsuario = nivelusuario;
            this.Correo_validado = correovalidado;
        }        
    }
}
