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
        //Asgina los valores obtenidos desde la consulta de SQL
        public Usuario(DataRow dt)
        {
#nullable disable
            this.UsuarioID = (dt.Table.Columns.Contains("UsuarioID") && dt["UsuarioID"] != DBNull.Value) ? int.Parse(dt["UsuarioID"].ToString()) : 0;
            this.Nombre_usuario = (dt.Table.Columns.Contains("Nombre_usuario") && dt["Nombre_usuario"] != DBNull.Value) ? dt["Nombre_usuario"].ToString() : "";
            this.Nombre = (dt.Table.Columns.Contains("Nombre") && dt["Nombre"] != DBNull.Value) ? dt["Nombre"].ToString() : "";
            this.Segundo_nombre = (dt.Table.Columns.Contains("Segundo_nombre") && dt["Segundo_nombre"] != DBNull.Value) ? dt["Segundo_nombre"].ToString() : "";
            this.Apellido_paterno = (dt.Table.Columns.Contains("Apellido_paterno") && dt["Apellido_paterno"] != DBNull.Value) ? dt["Apellido_paterno"].ToString() : "";
            this.Apellido_materno = (dt.Table.Columns.Contains("Apellido_materno") && dt["Apellido_materno"] != DBNull.Value) ? dt["Apellido_materno"].ToString() : "";
            this.Fecha_nacimiento = (dt.Table.Columns.Contains("Fecha_nacimiento") && dt["Fecha_nacimiento"] != DBNull.Value) ? DateTime.Parse(dt["Fecha_nacimiento"].ToString()) : DateTime.Now;
            this.Fecha_ingreso = (dt.Table.Columns.Contains("Fecha_ingreso") && dt["Fecha_ingreso"] != DBNull.Value) ? DateTime.Parse(dt["Fecha_ingreso"].ToString()) : DateTime.Now;
            this.Telefono = (dt.Table.Columns.Contains("Telefono") && dt["Telefono"] != DBNull.Value) ? dt["Telefono"].ToString() : "";
            this.Telefono_prefijo = (dt.Table.Columns.Contains("Telefono_prefijo") && dt["Telefono_prefijo"] != DBNull.Value) ? dt["Telefono_prefijo"].ToString() : "";
            this.Correo_electronico = (dt.Table.Columns.Contains("Correo_electronico") && dt["Correo_electronico"] != DBNull.Value) ? dt["Correo_electronico"].ToString() : "";
            this.NivelUsuarioID = (dt.Table.Columns.Contains("NivelUsuarioID") && dt["NivelUsuarioID"] != DBNull.Value) ? int.Parse(dt["NivelUsuarioID"].ToString()) : 0;
#nullable restore
        }
        //Este metodo retornará una lista de objetos creada a partir del parametro de la tabla
        public static List<Usuario> ObtenerListaDesdeTabla(DataTable dt)
        {
            List<Usuario> _lista = new List<Usuario>();
            if (dt != null && dt?.Rows.Count>0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Usuario _usuario = new Usuario(dr);
                    _lista.Add(_usuario);
                }
            }            
            return _lista;
        }
    }
}
