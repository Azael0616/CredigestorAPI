using CredigestorAPI.Models;
using System.Data;

namespace CredigestorAPI.DAL.Mappers
{
    public static class MunicipioMapper
    {
        //Este metodo retornará un objeto creado a partir de un DataRow
        public static Municipio ObtenerObjetoDataRow(DataRow dt)
        {
#nullable disable
            return new Municipio
            {
                MunicipioID = (dt.Table.Columns.Contains("MunicipioID") && dt["MunicipioID"] != DBNull.Value) ? int.Parse(dt["MunicipioID"].ToString()) : 0,
                EstadoID = (dt.Table.Columns.Contains("EstadoID") && dt["EstadoID"] != DBNull.Value) ? int.Parse(dt["EstadoID"].ToString()) : 0,
                Nombre = (dt.Table.Columns.Contains("Nombre") && dt["Nombre"] != DBNull.Value) ? dt["Nombre"].ToString() : "",
                Siglas = (dt.Table.Columns.Contains("Siglas") && dt["Siglas"] != DBNull.Value) ? dt["Siglas"].ToString() : "",
                Activo = (dt.Table.Columns.Contains("Activo") && dt["Activo"] != DBNull.Value) ? (bool)dt["Activo"] : false
            };            
#nullable restore
        }
        //Este metodo retornará una lista de objetos creada a partir de un DataTable
        public static List<Municipio> ObtenerListaDataTable(DataTable dt)
        {
            List<Municipio> _lista = new List<Municipio>();
            if (dt != null && dt?.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Municipio _municipio = ObtenerObjetoDataRow(dr);
                    _lista.Add(_municipio);
                }
            }
            return _lista;
        }
    }
}
