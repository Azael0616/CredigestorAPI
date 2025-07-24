using CredigestorAPI.Models;
using System.Data;

namespace CredigestorAPI.DAL.Mappers
{
    public static class Tipo_nivel_estudioMapper
    {
        //Este metodo retornará un objeto creado a partir de un DataRow
        public static Tipo_nivel_estudio ObtenerObjetoDataRow(DataRow dt)
        {
#nullable disable
            return new Tipo_nivel_estudio
            {
                TipoNivelEstudioID = (dt.Table.Columns.Contains("TipoNivelEstudioID") && dt["TipoNivelEstudioID"] != DBNull.Value) ? int.Parse(dt["TipoNivelEstudioID"].ToString()) : 0,
                Nombre = (dt.Table.Columns.Contains("Nombre") && dt["Nombre"] != DBNull.Value) ? dt["Nombre"].ToString() : "",
                Activo = (dt.Table.Columns.Contains("Activo") && dt["Activo"] != DBNull.Value) ? (bool)dt["Activo"] : false
            };            
#nullable restore
        }
        //Este metodo retornará una lista de objetos creada a partir de un DataTable
        public static List<Tipo_nivel_estudio> ObtenerListaDataTable(DataTable dt)
        {
            List<Tipo_nivel_estudio> _lista = new List<Tipo_nivel_estudio>();
            if (dt != null && dt?.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Tipo_nivel_estudio _nivelEstudio = ObtenerObjetoDataRow(dr);
                    _lista.Add(_nivelEstudio);
                }
            }
            return _lista;
        }
    }
}
