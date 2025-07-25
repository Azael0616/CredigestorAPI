using CredigestorAPI.Models.Utils;
using System.Data;

namespace CredigestorAPI.DAL.Mappers
{
    public static class UsuarioEncontradoMapper
    {
        public static UsuarioEncontrado ObtenerObjetoDataRow(DataRow dt)
        {
#nullable disable
            return new UsuarioEncontrado
            {
                UsuarioID = (dt.Table.Columns.Contains("UsuarioID") && dt["UsuarioID"] != DBNull.Value) ? int.Parse(dt["UsuarioID"].ToString()) : 0,
                Nombre_usuario = dt.Table.Columns.Contains("Nombre_usuario") && dt["Nombre_usuario"] != DBNull.Value ? dt["Nombre_usuario"].ToString() : "",
                Password = dt.Table.Columns.Contains("PasswordHash") && dt["PasswordHash"] != DBNull.Value ? dt["PasswordHash"].ToString() : ""
            };            
#nullable restore
        }
    }
}
