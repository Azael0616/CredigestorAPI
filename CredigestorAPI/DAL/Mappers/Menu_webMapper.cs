using CredigestorAPI.Models;
using System.Data;

namespace CredigestorAPI.DAL.Mappers
{
    public static class Menu_webMapper
    {
        //Este metodo retornará un objeto creado a partir de un DataRow
        public static Menu_web ObtenerObjetoDataRow(DataRow dt)
        {
#nullable disable
            return new Menu_web
            {
                MenuWebID = (dt.Table.Columns.Contains("MenuWebID") && dt["MenuWebID"] != DBNull.Value) ? int.Parse(dt["MenuWebID"].ToString()) : 0,
                Nombre = (dt.Table.Columns.Contains("Nombre") && dt["Nombre"] != DBNull.Value) ? dt["Nombre"].ToString() : "",
                URL = (dt.Table.Columns.Contains("URL") && dt["URL"] != DBNull.Value) ? dt["URL"].ToString() : "",
                TipoMenuID = (dt.Table.Columns.Contains("TipoMenuID") && dt["TipoMenuID"] != DBNull.Value) ? int.Parse(dt["TipoMenuID"].ToString()) : 0,
                MenuPadreID = (dt.Table.Columns.Contains("MenuPadreID") && dt["MenuPadreID"] != DBNull.Value) ? int.Parse(dt["MenuPadreID"].ToString()) : 0,
                Activo = (dt.Table.Columns.Contains("Activo") && dt["Activo"] != DBNull.Value) ? (bool)dt["Activo"] : false,
                Icono = (dt.Table.Columns.Contains("Icono") && dt["Icono"] != DBNull.Value) ? dt["Icono"].ToString() : ""
            };            
#nullable restore
        }
        //Este metodo retornará una lista de objetos creada a partir de un DataTable
        public static List<Menu_web> ObtenerListaDataTable(DataTable dt)
        {
            List<Menu_web> _lista = new List<Menu_web>();
            if (dt != null && dt?.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Menu_web _menuWeb = ObtenerObjetoDataRow(dr);
                    _lista.Add(_menuWeb);
                }
            }
            return _lista;
        }
    }
}
