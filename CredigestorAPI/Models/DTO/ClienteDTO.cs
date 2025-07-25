using System.Data;

namespace CredigestorAPI.Models.DTO
{
    public class ClienteDTO
    {
        public int ClienteID { get; set; } = 0;
        public string Nombre { get; set; } = string.Empty;
        public string Segundo_nombre { get; set; } = string.Empty;
        public string Apellido_paterno { get; set; } = string.Empty;
        public string Apellido_materno { get; set; } = string.Empty;
        public string Fecha_nacimiento { get; set; } = string.Empty;
        public string Sexo { get; set; } = string.Empty;
        public string Estado_civil { get; set; } = string.Empty;
        public string CURP { get; set; } = string.Empty;
        public string RFC { get; set; } = string.Empty;
        public string Clave_elector { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;        
        public string Correo_electronico { get; set; } = string.Empty;
        public bool Activo { get; set; } = false;
        public ClienteDTO() { }
        public ClienteDTO(int clienteid, string nombre, string segundo_nombre, string apellido_paterno, string apellido_materno,
            string fecha_nacimiento, string sexo, string estado_civil, string curp, string rfc, string clave_elector,
            string telefono, string telefono_prefijo, string correo_electronico, bool activo)
        {
            this.ClienteID = clienteid;
            this.Nombre = nombre;
            this.Segundo_nombre = segundo_nombre;
            this.Apellido_paterno = apellido_paterno;
            this.Apellido_materno = apellido_materno;
            this.Fecha_nacimiento = fecha_nacimiento;
            this.Sexo = sexo;
            this.Estado_civil = estado_civil;
            this.CURP = curp;
            this.RFC = rfc;
            this.Clave_elector = clave_elector;
            this.Telefono = telefono;            
            this.Correo_electronico = correo_electronico;
            this.Activo = activo;
        }        
    }
}
