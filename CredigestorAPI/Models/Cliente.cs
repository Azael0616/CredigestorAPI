
namespace CredigestorAPI.Models
{
    public class Cliente
    {
        public int ClienteID { get; set; } = 0;
        public string Nombre { get; set; } = string.Empty;
        public string Segundo_nombre {  get; set; } = string.Empty;
        public string Apellido_paterno {  get; set; } = string.Empty;
        public string Apellido_materno { get ; set; } = string.Empty;
        public DateTime Fecha_nacimiento {  get; set; } = DateTime.Now;
        public int TipoSexoID { get; set; } = 0;
        public int TipoEstadoCivilID { get; set; } = 0;
        public string CURP {  get; set; } = string.Empty;
        public string RFC {  get; set; } = string.Empty;
        public string Clave_elector {  get; set; } = string.Empty;
        public string Telefono {  get; set; } = string.Empty;
        public string Telefono_prefijo {  get; set; } = string.Empty;
        public string Correo_electronico {  get; set; } = string.Empty;
        public bool Activo { get; set; } = false;
        public Cliente() { }
        public Cliente(int clienteid, string nombre, string segundo_nombre, string apellido_paterno, string apellido_materno,
            DateTime fecha_nacimiento,int tiposexoid, int tipoestadocivilid, string curp, string rfc, string clave_elector,
            string telefono, string telefono_prefijo, string correo_electronico, bool activo)
        {
            this.ClienteID = clienteid;
            this.Nombre = nombre;
            this.Segundo_nombre = segundo_nombre;
            this.Apellido_paterno = apellido_paterno;
            this.Apellido_materno = apellido_materno;
            this.Fecha_nacimiento = fecha_nacimiento;
            this.TipoSexoID = tiposexoid;
            this.TipoEstadoCivilID = tipoestadocivilid;
            this.CURP = curp;
            this.RFC = rfc;
            this.Clave_elector = clave_elector;
            this.Telefono = telefono;
            this.Telefono_prefijo = telefono_prefijo;
            this.Correo_electronico = correo_electronico;
            this.Activo = activo;
        }                
    }
}
