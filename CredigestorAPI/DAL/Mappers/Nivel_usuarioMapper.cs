using CredigestorAPI.Models;
using System.Data;

namespace CredigestorAPI.DAL.Mappers
{
    public static class Nivel_usuarioMapper
    {
        //Este metodo retornará un objeto creado a partir de un DataRow
        public static Nivel_usuario ObtenerObjetoDataRow(DataRow dt)
        {
#nullable disable
            return new Nivel_usuario
            {
                NivelUsuarioID = (dt.Table.Columns.Contains("NivelUsuarioID") && dt["NivelUsuarioID"] != DBNull.Value) ? int.Parse(dt["NivelUsuarioID"].ToString()) : 0,
                Nombre = (dt.Table.Columns.Contains("Nombre") && dt["Nombre"] != DBNull.Value) ? dt["Nombre"].ToString() : "",
                Activo = (dt.Table.Columns.Contains("Activo") && dt["Activo"] != DBNull.Value) ? (bool)dt["Activo"] : false,
                Solo_administrador = (dt.Table.Columns.Contains("Solo_administrador") && dt["Solo_administrador"] != DBNull.Value) ? (bool)dt["Solo_administrador"] : false
            };            
#nullable restore
        }
        //Este metodo retornará una lista de objetos creada a partir de un DataTable
        public static List<Nivel_usuario> ObtenerListaDataTable(DataTable dt)
        {
            List<Nivel_usuario> _lista = new List<Nivel_usuario>();
            if (dt != null && dt?.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Nivel_usuario _nivelUsuario = ObtenerObjetoDataRow(dr);
                    _lista.Add(_nivelUsuario);
                }
            }
            return _lista;
        }
    }
}
