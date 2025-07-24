using CredigestorAPI.Models;
using System.Data;

namespace CredigestorAPI.DAL.Mappers
{
    public static class Tipo_estado_civilMapper
    {
        //Este metodo retornará un objeto creado a partir de un DataRow
        public static Tipo_estado_civil ObtenerObjetoDataRow(DataRow dt)
        {
#nullable disable
            return new Tipo_estado_civil
            {
                TipoEstadoCivilID = (dt.Table.Columns.Contains("TipoEstadoCivilID") && dt["TipoEstadoCivilID"] != DBNull.Value) ? int.Parse(dt["TipoEstadoCivilID"].ToString()) : 0,
                Nombre = (dt.Table.Columns.Contains("Nombre") && dt["Nombre"] != DBNull.Value) ? dt["Nombre"].ToString() : "",
                Activo = (dt.Table.Columns.Contains("Activo") && dt["Activo"] != DBNull.Value) ? (bool)dt["Activo"] : false
            };
#nullable restore
        }
        //Este metodo retornará una lista de objetos creada a partir de un DataTable
        public static List<Tipo_estado_civil> ObtenerListaDataTable(DataTable dt)
        {
            List<Tipo_estado_civil> _lista = new List<Tipo_estado_civil>();
            if (dt != null && dt?.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Tipo_estado_civil _tipoEstadoCivil = ObtenerObjetoDataRow(dr);
                    _lista.Add(_tipoEstadoCivil);
                }
            }
            return _lista;
        }
    }
}
