using CredigestorAPI.Models;
using System.Data;

namespace CredigestorAPI.DAL.Mappers
{
    public static class Cliente_historial_previoMapper
    {
        //Este metodo retornará un objeto creado a partir de un DataRow
        public static Cliente_historial_previo ObtenerObjetoDataRow(DataRow dt)
        {
#nullable disable  
            return new Cliente_historial_previo
            {
                ClienteID = (dt.Table.Columns.Contains("ClienteID") && dt["ClienteID"] != DBNull.Value) ? int.Parse(dt["ClienteID"].ToString()) : 0,
                Total_creditos_anteriores = (dt.Table.Columns.Contains("TCA") && dt["TCA"] != DBNull.Value) ? int.Parse(dt["TCA"].ToString()) : 0,
                Total_creditos_liquidados = (dt.Table.Columns.Contains("TCL") && dt["TCL"] != DBNull.Value) ? int.Parse(dt["TCL"].ToString()) : 0,
                Total_creditos_mora = (dt.Table.Columns.Contains("TCM") && dt["TCM"] != DBNull.Value) ? int.Parse(dt["TCM"].ToString()) : 0,
                Tiene_comprobantes = (dt.Table.Columns.Contains("Tiene_comprobantes") && dt["Tiene_comprobantes"] != DBNull.Value) ? (bool)dt["Tiene_comprobantes"] : false,
                Comprobante_digitalizado = (dt.Table.Columns.Contains("Comprobante_digitalizado") && dt["Comprobante_digitalizado"] != DBNull.Value) ? (byte[])dt["Comprobante_digitalizado"] : Array.Empty<byte>(),
                TipoDocumentoID = (dt.Table.Columns.Contains("TipoDocumentoID") && dt["TipoDocumentoID"] != DBNull.Value) ? int.Parse(dt["TipoDocumentoID"].ToString()) : 0,
                Extension = (dt.Table.Columns.Contains("Extension") && dt["Extension"] != DBNull.Value) ? dt["Extension"].ToString() : ""
            };            
#nullable restore
        }
        //Este metodo retornará una lista de objetos creada a partir de un DataTable
        public static List<Cliente_historial_previo> ObtenerListaDataTable(DataTable dt)
        {
            List<Cliente_historial_previo> _lista = new List<Cliente_historial_previo>();
            if (dt != null && dt?.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cliente_historial_previo _cliente = ObtenerObjetoDataRow(dr);
                    _lista.Add(_cliente);
                }
            }
            return _lista;
        }
    }
}
