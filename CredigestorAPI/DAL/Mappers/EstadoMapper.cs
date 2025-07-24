using CredigestorAPI.Models;
using System.Data;

namespace CredigestorAPI.DAL.Mappers
{
    public static class EstadoMapper
    {
        //Este metodo retornará un objeto creado a partir de un DataRow
        public static Estado ObtenerObjetoDataRow(DataRow dt)
        {
#nullable disable
            return new Estado
            {
                EstadoID = (dt.Table.Columns.Contains("EstadoID") && dt["EstadoID"] != DBNull.Value) ? int.Parse(dt["EstadoID"].ToString()) : 0,
                PaisID = (dt.Table.Columns.Contains("PaisID") && dt["PaisID"] != DBNull.Value) ? int.Parse(dt["PaisID"].ToString()) : 0,
                Nombre = (dt.Table.Columns.Contains("Nombre") && dt["Nombre"] != DBNull.Value) ? dt["Nombre"].ToString() : "",
                Siglas = (dt.Table.Columns.Contains("Siglas") && dt["Siglas"] != DBNull.Value) ? dt["Siglas"].ToString() : "",
                Activo = (dt.Table.Columns.Contains("Activo") && dt["Activo"] != DBNull.Value) ? (bool)dt["Activo"] : false
            };           
#nullable restore
        }
        //Este metodo retornará una lista de objetos creada a partir de un DataTable
        public static List<Estado> ObtenerListaDataTable(DataTable dt)
        {
            List<Estado> _lista = new List<Estado>();
            if (dt != null && dt?.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Estado _estado = ObtenerObjetoDataRow(dr);
                    _lista.Add(_estado);
                }
            }
            return _lista;
        }
    }
}
