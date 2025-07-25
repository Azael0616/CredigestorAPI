using CredigestorAPI.Models;
using System.Data;

namespace CredigestorAPI.DAL.Mappers
{
    public static class UsuarioMapper
    {
        //Este metodo retornará un objeto creado a partir de un DataRow
        public static Usuario ObtenerObjetoDataRow(DataRow dt)
        {
#nullable disable
            return new Usuario
            {
                UsuarioID = (dt.Table.Columns.Contains("UsuarioID") && dt["UsuarioID"] != DBNull.Value) ? int.Parse(dt["UsuarioID"].ToString()) : 0,
                Nombre_usuario = (dt.Table.Columns.Contains("Nombre_usuario") && dt["Nombre_usuario"] != DBNull.Value) ? dt["Nombre_usuario"].ToString() : "",
                Nombre = (dt.Table.Columns.Contains("Nombre") && dt["Nombre"] != DBNull.Value) ? dt["Nombre"].ToString() : "",
                Segundo_nombre = (dt.Table.Columns.Contains("Segundo_nombre") && dt["Segundo_nombre"] != DBNull.Value) ? dt["Segundo_nombre"].ToString() : "",
                Apellido_paterno = (dt.Table.Columns.Contains("Apellido_paterno") && dt["Apellido_paterno"] != DBNull.Value) ? dt["Apellido_paterno"].ToString() : "",
                Apellido_materno = (dt.Table.Columns.Contains("Apellido_materno") && dt["Apellido_materno"] != DBNull.Value) ? dt["Apellido_materno"].ToString() : "",
                Fecha_nacimiento = (dt.Table.Columns.Contains("Fecha_nacimiento") && dt["Fecha_nacimiento"] != DBNull.Value) ? DateTime.Parse(dt["Fecha_nacimiento"].ToString()) : DateTime.Now,
                Fecha_ingreso = (dt.Table.Columns.Contains("Fecha_ingreso") && dt["Fecha_ingreso"] != DBNull.Value) ? DateTime.Parse(dt["Fecha_ingreso"].ToString()) : DateTime.Now,
                Telefono = (dt.Table.Columns.Contains("Telefono") && dt["Telefono"] != DBNull.Value) ? dt["Telefono"].ToString() : "",
                Telefono_prefijo = (dt.Table.Columns.Contains("Telefono_prefijo") && dt["Telefono_prefijo"] != DBNull.Value) ? dt["Telefono_prefijo"].ToString() : "",
                Correo_electronico = (dt.Table.Columns.Contains("Correo_electronico") && dt["Correo_electronico"] != DBNull.Value) ? dt["Correo_electronico"].ToString() : "",
                NivelUsuarioID = (dt.Table.Columns.Contains("NivelUsuarioID") && dt["NivelUsuarioID"] != DBNull.Value) ? int.Parse(dt["NivelUsuarioID"].ToString()) : 0
            };            
#nullable restore
        }
        //Este metodo retornará una lista de objetos creada a partir del un DataTable
        public static List<Usuario> ObtenerListaDataTable(DataTable dt)
        {
            List<Usuario> _lista = new List<Usuario>();
            if (dt != null && dt?.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Usuario _usuario = ObtenerObjetoDataRow(dr);
                    _lista.Add(_usuario);
                }
            }
            return _lista;
        }
    }
}
