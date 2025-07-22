using System.Data;

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
        public Cliente(DataRow dt)
        {
#nullable disable
            this.ClienteID = (dt.Table.Columns.Contains("ClienteID") && dt["ClienteID"] != DBNull.Value) ? int.Parse(dt["ClienteID"].ToString()) : 0;
            this.Nombre = (dt.Table.Columns.Contains("Nombre") && dt["Nombre"] != DBNull.Value) ? dt["Nombre"].ToString() : "";
            this.Segundo_nombre = (dt.Table.Columns.Contains("Segundo_nombre") && dt["Segundo_nombre"] != DBNull.Value) ? dt["Segundo_nombre"].ToString() : "";
            this.Apellido_paterno = (dt.Table.Columns.Contains("Apellido_paterno") && dt["Apellido_paterno"] != DBNull.Value) ? dt["Apellido_paterno"].ToString() : "";
            this.Apellido_materno = (dt.Table.Columns.Contains("Apellido_materno") && dt["Apellido_materno"] != DBNull.Value) ? dt["Apellido_materno"].ToString() : "";
            this.Fecha_nacimiento = (dt.Table.Columns.Contains("Fecha_nacimiento") && dt["Fecha_nacimiento"] != DBNull.Value) ? DateTime.Parse(dt["Fecha_nacimiento"].ToString()) : DateTime.Now;
            this.TipoSexoID = (dt.Table.Columns.Contains("TipoSexoID") && dt["TipoSexoID"] != DBNull.Value) ? int.Parse(dt["TipoSexoID"].ToString()) : 0;
            this.TipoEstadoCivilID = (dt.Table.Columns.Contains("TipoEstadoCivilID") && dt["TipoEstadoCivilID"] != DBNull.Value) ? int.Parse(dt["TipoEstadoCivilID"].ToString()) : 0;
            this.CURP = (dt.Table.Columns.Contains("CURP") && dt["CURP"] != DBNull.Value) ? dt["CURP"].ToString() : "";
            this.RFC = (dt.Table.Columns.Contains("RFC") && dt["RFC"] != DBNull.Value) ? dt["RFC"].ToString() : "";
            this.Clave_elector = (dt.Table.Columns.Contains("Clave_elector") && dt["Clave_elector"] != DBNull.Value) ? dt["Clave_elector"].ToString() : "";
            this.Telefono = (dt.Table.Columns.Contains("Telefono") && dt["Telefono"] != DBNull.Value) ? dt["Telefono"].ToString() : "";
            this.Telefono_prefijo = (dt.Table.Columns.Contains("Telefono_prefijo") && dt["Telefono_prefijo"] != DBNull.Value) ? dt["Telefono_prefijo"].ToString() : "";
            this.Correo_electronico = (dt.Table.Columns.Contains("Correo_electronico") && dt["Correo_electronico"] != DBNull.Value) ? dt["Correo_electronico"].ToString() : "";
            this.Activo = (dt.Table.Columns.Contains("Activo") && dt["Activo"] != DBNull.Value) ? (bool)dt["Activo"] : false;
#nullable restore
        }
        public static List<Cliente> ObtenerListaDesdeTabla(DataTable dt)
        {
            List<Cliente> _lista = new List<Cliente>();
            if (dt != null && dt?.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cliente _cliente = new Cliente(dr);
                    _lista.Add(_cliente);
                }
            }
            return _lista;
        }
    }
}
