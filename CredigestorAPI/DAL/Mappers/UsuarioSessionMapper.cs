using CredigestorAPI.Models.Utils;
using System.Data;

namespace CredigestorAPI.DAL.Mappers
{
    public static class UsuarioSessionMapper
    {
        public static UsuarioSesion ObtenerObjetoDataRow(DataRow dt)
        {
#nullable disable   
            return new UsuarioSesion
            {
                UsuarioID = (dt.Table.Columns.Contains("UsuarioID") && dt["UsuarioID"] != DBNull.Value) ? int.Parse(dt["UsuarioID"].ToString()) : 0,
                Nombre_usuario = dt.Table.Columns.Contains("Nombre_usuario") && dt["Nombre_usuario"] != DBNull.Value ? dt["Nombre_usuario"].ToString() : "",
                Nombre = dt.Table.Columns.Contains("Nombre") && dt["Nombre"] != DBNull.Value ? dt["Nombre"].ToString() : "",
                NivelUsuario = dt.Table.Columns.Contains("NivelUsuario") && dt["NivelUsuario"] != DBNull.Value ? dt["NivelUsuario"].ToString() : "",
                NivelUsuarioID = (dt.Table.Columns.Contains("NivelUsuarioID") && dt["NivelUsuarioID"] != DBNull.Value) ? int.Parse(dt["NivelUsuarioID"].ToString()) : 0
            };            
#nullable restore
        }
    }
}
