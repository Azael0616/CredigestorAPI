using CredigestorAPI.Models;
using System.Data;

namespace CredigestorAPI.DAL.Mappers
{
    public static class Cliente_referenciaMapper
    {
        //Este metodo retornará un objeto creado a partir de un DataRow
        public static Cliente_referencia ObtenerObjetoDataRow(DataRow dt)
        {
#nullable disable
            return new Cliente_referencia
            {
                ReferenciaID = (dt.Table.Columns.Contains("ReferenciaID") && dt["ReferenciaID"] != DBNull.Value) ? int.Parse(dt["ReferenciaID"].ToString()) : 0,
                ClienteID = (dt.Table.Columns.Contains("ClienteID") && dt["ClienteID"] != DBNull.Value) ? int.Parse(dt["ClienteID"].ToString()) : 0,
                Nombre_completo = (dt.Table.Columns.Contains("Nombre_completo") && dt["Nombre_completo"] != DBNull.Value) ? dt["Nombre_completo"].ToString() : "",
                Telefono_referencia = (dt.Table.Columns.Contains("Telefono_referencia") && dt["Telefono_referencia"] != DBNull.Value) ? dt["Telefono_referencia"].ToString() : "",
                Telefono_referencia_prefijo = (dt.Table.Columns.Contains("Telefono_referencia_prefijo") && dt["Telefono_referencia_prefijo"] != DBNull.Value) ? dt["Telefono_referencia_prefijo"].ToString() : "",
                Correo_electronico = (dt.Table.Columns.Contains("Correo_electronico") && dt["Correo_electronico"] != DBNull.Value) ? dt["Correo_electronico"].ToString() : ""
            };            
#nullable restore
        }
        //Este metodo retornará una lista de objetos creada a partir de un DataTable
        public static List<Cliente_referencia> ObtenerListaDataTable(DataTable dt)
        {
            List<Cliente_referencia> _lista = new List<Cliente_referencia>();
            if (dt != null && dt?.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Cliente_referencia _cliente = ObtenerObjetoDataRow(dr);
                    _lista.Add(_cliente);
                }
            }
            return _lista;
        }
    }
}
