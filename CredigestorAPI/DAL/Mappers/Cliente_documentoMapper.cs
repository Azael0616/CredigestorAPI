using CredigestorAPI.Models;
using System.Data;

namespace CredigestorAPI.DAL.Mappers
{
    public static class Cliente_documentoMapper
    {
        //Este metodo retornará un objeto creado a partir de un DataRow
        public static Cliente_documento ObtenerObjetoDataRow(DataRow dt)
        {
#nullable disable
            return new Cliente_documento
            {
                DocumentoID = (dt.Table.Columns.Contains("DocumentoID") && dt["DocumentoID"] != DBNull.Value) ? int.Parse(dt["DocumentoID"].ToString()) : 0,
                ClienteID = (dt.Table.Columns.Contains("ClienteID") && dt["ClienteID"] != DBNull.Value) ? int.Parse(dt["ClienteID"].ToString()) : 0,
                Contenido = (dt.Table.Columns.Contains("Contenido") && dt["Contenido"] != DBNull.Value) ? (byte[])dt["Contenido"] : Array.Empty<byte>(),
                TipoDocumentoID = (dt.Table.Columns.Contains("TipoDocumentoID") && dt["TipoDocumentoID"] != DBNull.Value) ? int.Parse(dt["TipoDocumentoID"].ToString()) : 0,
                Extension = (dt.Table.Columns.Contains("Extension") && dt["Extension"] != DBNull.Value) ? dt["Extension"].ToString() : ""
            };
            
#nullable restore
        }
        //Este metodo retornará una lista de objetos creada a partir de un DataTable
        public static List<Cliente_documento> ObtenerListaDataTable(DataTable dt)
        {
            List<Cliente_documento> _lista = new List<Cliente_documento>();
            if (dt != null && dt?.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cliente_documento _cliente = ObtenerObjetoDataRow(dr);  
                    _lista.Add(_cliente);
                }
            }
            return _lista;
        }
    }
}
