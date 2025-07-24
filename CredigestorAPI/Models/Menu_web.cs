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
    }
}
