using CredigestorAPI.Models;
using System.Data;

namespace CredigestorAPI.DAL.Mappers
{
    public static class Tipo_sexoMapper
    {
        //Este metodo retornará un objeto creado a partir de un DataRow
        public static Tipo_sexo ObtenerObjetoDataRow(DataRow dt)
        {
#nullable disable
            return new Tipo_sexo
            {
                TipoSexoID = (dt.Table.Columns.Contains("TipoSexoID") && dt["TipoSexoID"] != DBNull.Value) ? int.Parse(dt["TipoSexoID"].ToString()) : 0,
                Nombre = (dt.Table.Columns.Contains("Nombre") && dt["Nombre"] != DBNull.Value) ? dt["Nombre"].ToString() : "",
                Activo = (dt.Table.Columns.Contains("Activo") && dt["Activo"] != DBNull.Value) ? (bool)dt["Activo"] : false
            };            
#nullable restore
        }
        //Este metodo retornará una lista de objetos creada a partir de un DataTable
        public static List<Tipo_sexo> ObtenerListaDataTable(DataTable dt)
        {
            List<Tipo_sexo> _lista = new List<Tipo_sexo>();
            if (dt != null && dt?.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Tipo_sexo _tipoSexo = ObtenerObjetoDataRow(dr);
                    _lista.Add(_tipoSexo);
                }
            }
            return _lista;
        }
    }
}
