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
        public ClienteDTO(DataRow dt)
        {
#nullable disable
            this.ClienteID = (dt.Table.Columns.Contains("ClienteID") && dt["ClienteID"] != DBNull.Value) ? int.Parse(dt["ClienteID"].ToString()) : 0;
            this.Nombre = (dt.Table.Columns.Contains("Nombre") && dt["Nombre"] != DBNull.Value) ? dt["Nombre"].ToString() : "";
            this.Segundo_nombre = (dt.Table.Columns.Contains("Segundo_nombre") && dt["Segundo_nombre"] != DBNull.Value) ? dt["Segundo_nombre"].ToString() : "";
            this.Apellido_paterno = (dt.Table.Columns.Contains("Apellido_paterno") && dt["Apellido_paterno"] != DBNull.Value) ? dt["Apellido_paterno"].ToString() : "";
            this.Apellido_materno = (dt.Table.Columns.Contains("Apellido_materno") && dt["Apellido_materno"] != DBNull.Value) ? dt["Apellido_materno"].ToString() : "";
            this.Fecha_nacimiento = (dt.Table.Columns.Contains("Fecha_nacimiento") && dt["Fecha_nacimiento"] != DBNull.Value) ? dt["Fecha_nacimiento"].ToString() : "";
            this.Sexo = (dt.Table.Columns.Contains("Sexo") && dt["Sexo"] != DBNull.Value) ? dt["Sexo"].ToString() : "";
            this.Estado_civil = (dt.Table.Columns.Contains("Estado_civil") && dt["Estado_civil"] != DBNull.Value) ? dt["Estado_civil"].ToString() : "";
            this.CURP = (dt.Table.Columns.Contains("CURP") && dt["CURP"] != DBNull.Value) ? dt["CURP"].ToString() : "";
            this.RFC = (dt.Table.Columns.Contains("RFC") && dt["RFC"] != DBNull.Value) ? dt["RFC"].ToString() : "";
            this.Clave_elector = (dt.Table.Columns.Contains("Clave_elector") && dt["Clave_elector"] != DBNull.Value) ? dt["Clave_elector"].ToString() : "";
            this.Telefono = (dt.Table.Columns.Contains("Telefono") && dt["Telefono"] != DBNull.Value) ? dt["Telefono"].ToString() : "";            
            this.Correo_electronico = (dt.Table.Columns.Contains("Correo_electronico") && dt["Correo_electronico"] != DBNull.Value) ? dt["Correo_electronico"].ToString() : "";
            this.Activo = (dt.Table.Columns.Contains("Activo") && dt["Activo"] != DBNull.Value) ? (bool)dt["Activo"] : false;
#nullable restore
        }
        public static List<ClienteDTO> ObtenerListaDesdeTabla(DataTable dt)
        {
            List<ClienteDTO> _lista = new List<ClienteDTO>();
            if (dt != null && dt?.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ClienteDTO _cliente = new ClienteDTO(dr);
                    _lista.Add(_cliente);
                }
            }
            return _lista;
        }
    }
}
