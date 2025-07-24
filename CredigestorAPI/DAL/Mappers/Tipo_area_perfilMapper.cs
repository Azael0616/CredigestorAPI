using CredigestorAPI.Models;
using System.Data;

namespace CredigestorAPI.DAL.Mappers
{
    public static class Tipo_area_perfilMapper
    {
        //Este metodo retornará un objeto creado a partir de un DataRow
        public static Tipo_area_perfil ObtenerObjetoDataRow(DataRow dt)
        {
#nullable disable
            return new Tipo_area_perfil
            {
                TipoAreaPerfilID = (dt.Table.Columns.Contains("TipoAreaPerfilID") && dt["TipoAreaPerfilID"] != DBNull.Value) ? int.Parse(dt["TipoAreaPerfilID"].ToString()) : 0,
                Nombre = (dt.Table.Columns.Contains("Nombre") && dt["Nombre"] != DBNull.Value) ? dt["Nombre"].ToString() : "",
                Descripcion = (dt.Table.Columns.Contains("Descripcion") && dt["Descripcion"] != DBNull.Value) ? dt["Descripcion"].ToString() : "",
                Calificacion = (dt.Table.Columns.Contains("Calificacion") && dt["Calificacion"] != DBNull.Value) ? int.Parse(dt["Calificacion"].ToString()) : 0,
                Tipo = (dt.Table.Columns.Contains("Tipo") && dt["Tipo"] != DBNull.Value) ? dt["Tipo"].ToString() : "",
                Activo = (dt.Table.Columns.Contains("Activo") && dt["Activo"] != DBNull.Value) ? (bool)dt["Activo"] : false
            };
#nullable restore
        }
        //Este metodo retornará una lista de objetos creada a partir de un DataTable
        public static List<Tipo_area_perfil> ObtenerListaDataTable(DataTable dt)
        {
            List<Tipo_area_perfil> _lista = new List<Tipo_area_perfil>();
            if (dt != null && dt?.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Tipo_area_perfil _tipo = ObtenerObjetoDataRow(dr);
                    _lista.Add(_tipo);
                }
            }
            return _lista;
        }
    }
}
