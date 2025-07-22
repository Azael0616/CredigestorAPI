using System.Data;

namespace CredigestorAPI.Models
{
    public class Menu_web
    {
        public int MenuWebID { get; set; } = 0;
        public string Nombre { get; set; } = string.Empty;
        public string URL { get; set; } = string.Empty;
        public int TipoMenuID { get; set; } = 0;
        public int? MenuPadreID { get; set; } = null;
        public bool Activo { get; set; } = false;
        public string Icono {  get; set; } = string.Empty;
        public List<Menu_web> Hijos { get; set; } = new();
        public Menu_web() { }
        public Menu_web(int menuwebid, string nombre, string url, int tipomenuid, int menupadreid, bool activo, string icono)
        {
            this.MenuWebID = menuwebid;
            this.Nombre = nombre;
            this.URL = url;
            this.TipoMenuID = tipomenuid;
            this.MenuPadreID = menupadreid;
            this.Activo = activo;
            this.Icono = icono;
        }
        public Menu_web(DataRow dt)
        {
#nullable disable
            this.MenuWebID = (dt.Table.Columns.Contains("MenuWebID") && dt["MenuWebID"] != DBNull.Value) ? int.Parse(dt["MenuWebID"].ToString()) : 0;
            this.Nombre = (dt.Table.Columns.Contains("Nombre") && dt["Nombre"] != DBNull.Value) ? dt["Nombre"].ToString() : "";
            this.URL = (dt.Table.Columns.Contains("URL") && dt["URL"] != DBNull.Value) ? dt["URL"].ToString() : "";
            this.TipoMenuID = (dt.Table.Columns.Contains("TipoMenuID") && dt["TipoMenuID"] != DBNull.Value) ? int.Parse(dt["TipoMenuID"].ToString()) : 0;
            this.MenuPadreID = (dt.Table.Columns.Contains("MenuPadreID") && dt["MenuPadreID"] != DBNull.Value) ? int.Parse(dt["MenuPadreID"].ToString()) : 0;
            this.Activo = (dt.Table.Columns.Contains("Activo") && dt["Activo"] != DBNull.Value) ? (bool)dt["Activo"] : false;
            this.Icono = (dt.Table.Columns.Contains("Icono") && dt["Icono"] != DBNull.Value) ? dt["Icono"].ToString() : "";
#nullable restore
        }
        public static List<Menu_web> ObtenerListaDesdeTabla(DataTable dt)
        {
            List<Menu_web> _lista = new List<Menu_web>();
            if (dt != null && dt?.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Menu_web _menuWeb = new Menu_web(dr);
                    _lista.Add(_menuWeb);
                }
            }
            return _lista;
        }
    }
}
