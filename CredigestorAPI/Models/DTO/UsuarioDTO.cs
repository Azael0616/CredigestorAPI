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
        //Asgina los valores obtenidos desde la consulta de SQL
        public UsuarioDTO(DataRow dt)
        {
#nullable disable
            this.UsuarioID = (dt.Table.Columns.Contains("UsuarioID") && dt["UsuarioID"] != DBNull.Value) ? int.Parse(dt["UsuarioID"].ToString()) : 0;
            this.Nombre_usuario = (dt.Table.Columns.Contains("Nombre_usuario") && dt["Nombre_usuario"] != DBNull.Value) ? dt["Nombre_usuario"].ToString() : "";
            this.Nombre = (dt.Table.Columns.Contains("Nombre") && dt["Nombre"] != DBNull.Value) ? dt["Nombre"].ToString() : "";
            this.Segundo_nombre = (dt.Table.Columns.Contains("Segundo_nombre") && dt["Segundo_nombre"] != DBNull.Value) ? dt["Segundo_nombre"].ToString() : "";
            this.Apellido_paterno = (dt.Table.Columns.Contains("Apellido_paterno") && dt["Apellido_paterno"] != DBNull.Value) ? dt["Apellido_paterno"].ToString() : "";
            this.Apellido_materno = (dt.Table.Columns.Contains("Apellido_materno") && dt["Apellido_materno"] != DBNull.Value) ? dt["Apellido_materno"].ToString() : "";
            this.Fecha_nacimiento = (dt.Table.Columns.Contains("Fecha_nacimiento") && dt["Fecha_nacimiento"] != DBNull.Value) ? dt["Fecha_nacimiento"].ToString() : "";
            this.Fecha_ingreso = (dt.Table.Columns.Contains("Fecha_ingreso") && dt["Fecha_ingreso"] != DBNull.Value) ? dt["Fecha_ingreso"].ToString() : "";
            this.Telefono = (dt.Table.Columns.Contains("Telefono") && dt["Telefono"] != DBNull.Value) ? dt["Telefono"].ToString() : "";            
            this.Correo_electronico = (dt.Table.Columns.Contains("Correo_electronico") && dt["Correo_electronico"] != DBNull.Value) ? dt["Correo_electronico"].ToString() : "";
            this.NivelUsuario = (dt.Table.Columns.Contains("NivelUsuario") && dt["NivelUsuario"] != DBNull.Value) ? dt["NivelUsuario"].ToString() : "";
            this.Correo_validado = (dt.Table.Columns.Contains("Correo_validado") && dt["Correo_validado"] != DBNull.Value) ? (bool)dt["Correo_validado"] : false;
#nullable restore
        }
        //Este metodo retornará una lista de objetos creada a partir del parametro de la tabla
        public static List<UsuarioDTO> ObtenerListaDesdeTabla(DataTable dt)
        {
            List<UsuarioDTO> _lista = new List<UsuarioDTO>();
            if (dt != null && dt?.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    UsuarioDTO _usuario = new UsuarioDTO(dr);
                    _lista.Add(_usuario);
                }
            }
            return _lista;
        }
    }
}
