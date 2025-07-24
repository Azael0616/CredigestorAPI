using CredigestorAPI.Models;
using System.Data;

namespace CredigestorAPI.DAL.Mappers
{
    public static class Tipo_archivoMapper
    {
        //Este metodo retornará un objeto creado a partir de un DataRow
        public static Tipo_archivo ObtenerObjetoDataRow(DataRow dt)
        {
#nullable disable
            return new Tipo_archivo
            {
                TipoArchivoID = (dt.Table.Columns.Contains("TipoArchivoID") && dt["TipoArchivoID"] != DBNull.Value) ? int.Parse(dt["TipoArchivoID"].ToString()) : 0,
                Extension = (dt.Table.Columns.Contains("Extension") && dt["Extension"] != DBNull.Value) ? dt["Extension"].ToString() : "",
                Descripcion = (dt.Table.Columns.Contains("Descripcion") && dt["Descripcion"] != DBNull.Value) ? dt["Descripcion"].ToString() : "",                
                Activo = (dt.Table.Columns.Contains("Activo") && dt["Activo"] != DBNull.Value) ? (bool)dt["Activo"] : false                
            };

#nullable restore
        }
        //Este metodo retornará una lista de objetos creada a partir de un DataTable
        public static List<Tipo_archivo> ObtenerListaDataTable(DataTable dt)
        {
            List<Tipo_archivo> _lista = new List<Tipo_archivo>();
            if (dt != null && dt?.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Tipo_archivo _archivo = ObtenerObjetoDataRow(dr);
                    _lista.Add(_archivo);
                }
            }
            return _lista;
        }
    }
}
