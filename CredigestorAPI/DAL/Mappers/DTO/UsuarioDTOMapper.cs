using CredigestorAPI.Models.DTO;
using System.Data;

namespace CredigestorAPI.DAL.Mappers.DTO
{
    public static class UsuarioDTOMapper
    {
        //Este metodo retornará un objeto creado a partir de un DataRow
        public static UsuarioDTO ObtenerObjetoDataRow(DataRow dt)
        {
#nullable disable
            return new UsuarioDTO
            {
                UsuarioID = (dt.Table.Columns.Contains("UsuarioID") && dt["UsuarioID"] != DBNull.Value) ? int.Parse(dt["UsuarioID"].ToString()) : 0,
                Nombre_usuario = (dt.Table.Columns.Contains("Nombre_usuario") && dt["Nombre_usuario"] != DBNull.Value) ? dt["Nombre_usuario"].ToString() : "",
                Nombre = (dt.Table.Columns.Contains("Nombre") && dt["Nombre"] != DBNull.Value) ? dt["Nombre"].ToString() : "",
                Segundo_nombre = (dt.Table.Columns.Contains("Segundo_nombre") && dt["Segundo_nombre"] != DBNull.Value) ? dt["Segundo_nombre"].ToString() : "",
                Apellido_paterno = (dt.Table.Columns.Contains("Apellido_paterno") && dt["Apellido_paterno"] != DBNull.Value) ? dt["Apellido_paterno"].ToString() : "",
                Apellido_materno = (dt.Table.Columns.Contains("Apellido_materno") && dt["Apellido_materno"] != DBNull.Value) ? dt["Apellido_materno"].ToString() : "",
                Fecha_nacimiento = (dt.Table.Columns.Contains("Fecha_nacimiento") && dt["Fecha_nacimiento"] != DBNull.Value) ? dt["Fecha_nacimiento"].ToString() : "",
                Fecha_ingreso = (dt.Table.Columns.Contains("Fecha_ingreso") && dt["Fecha_ingreso"] != DBNull.Value) ? dt["Fecha_ingreso"].ToString() : "",
                Telefono = (dt.Table.Columns.Contains("Telefono") && dt["Telefono"] != DBNull.Value) ? dt["Telefono"].ToString() : "",
                Correo_electronico = (dt.Table.Columns.Contains("Correo_electronico") && dt["Correo_electronico"] != DBNull.Value) ? dt["Correo_electronico"].ToString() : "",
                NivelUsuario = (dt.Table.Columns.Contains("NivelUsuario") && dt["NivelUsuario"] != DBNull.Value) ? dt["NivelUsuario"].ToString() : "",
                Correo_validado = (dt.Table.Columns.Contains("Correo_validado") && dt["Correo_validado"] != DBNull.Value) ? (bool)dt["Correo_validado"] : false
            };            
#nullable restore
        }
        //Este metodo retornará una lista de objetos creada a partir de un DataTable
        public static List<UsuarioDTO> ObtenerListaDataTable(DataTable dt)
        {
            List<UsuarioDTO> _lista = new List<UsuarioDTO>();
            if (dt != null && dt?.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    UsuarioDTO _usuario = ObtenerObjetoDataRow(dr);
                    _lista.Add(_usuario);
                }
            }
            return _lista;
        }
    }
}
