using CredigestorAPI.Models;
using System.Data;

namespace CredigestorAPI.DAL.Mappers
{
    public static class Tipo_documentoMapper
    {
        //Este metodo retornará un objeto creado a partir de un DataRow
        public static Tipo_documento ObtenerObjetoDataRow(DataRow dt)
        {
#nullable disable
            return new Tipo_documento
            {
                TipoDocumentoID = (dt.Table.Columns.Contains("TipoDocumentoID") && dt["TipoDocumentoID"] != DBNull.Value) ? int.Parse(dt["TipoDocumentoID"].ToString()) : 0,
                Nombre = (dt.Table.Columns.Contains("Nombre") && dt["Nombre"] != DBNull.Value) ? dt["Nombre"].ToString() : "",
                Descripcion = (dt.Table.Columns.Contains("Descripcion") && dt["Descripcion"] != DBNull.Value) ? dt["Descripcion"].ToString() : "",
                TipoArchivoID = (dt.Table.Columns.Contains("TipoArchivoID") && dt["TipoArchivoID"] != DBNull.Value) ? int.Parse(dt["TipoArchivoID"].ToString()) : 0,
                Activo = (dt.Table.Columns.Contains("Activo") && dt["Activo"] != DBNull.Value) ? (bool)dt["Activo"] : false,
                Obligatorio = (dt.Table.Columns.Contains("Obligatorio") && dt["Obligatorio"] != DBNull.Value) ? (bool)dt["Obligatorio"] : false,
                Ejemplo = (dt.Table.Columns.Contains("Ejemplo") && dt["Ejemplo"] != DBNull.Value) ? (byte[])dt["Ejemplo"] : Array.Empty<byte>(),
                TipoFormularioID = (dt.Table.Columns.Contains("TipoFormularioID") && dt["TipoFormularioID"] != DBNull.Value) ? int.Parse(dt["TipoFormularioID"].ToString()) : 0
            };

#nullable restore
        }
        //Este metodo retornará una lista de objetos creada a partir de un DataTable
        public static List<Tipo_documento> ObtenerListaDataTable(DataTable dt)
        {
            List<Tipo_documento> _lista = new List<Tipo_documento>();
            if (dt != null && dt?.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Tipo_documento _documento = ObtenerObjetoDataRow(dr);
                    _lista.Add(_documento);
                }
            }
            return _lista;
        }
    }
}
