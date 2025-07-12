using System.Data;

namespace CredigestorAPI.Models
{
    public class Nivel_usuario
    {
        public int NivelUsuarioID { get; set; } = 0;
        public string Nombre { get; set; } = string.Empty;
        public bool Activo { get; set; } = false;
        public bool Solo_administrador { get; set; } = false;
        public Nivel_usuario() { }
        public Nivel_usuario(int nivelusuarioid, string nombre, bool activo, bool solo_administrador)
        {
            this.NivelUsuarioID = nivelusuarioid;
            this.Nombre = nombre;
            this.Activo = activo;
            this.Solo_administrador = solo_administrador;
        }
        public Nivel_usuario(DataRow dt)
        {
#nullable disable
            this.NivelUsuarioID = (dt.Table.Columns.Contains("NivelUsuarioID") && dt["NivelUsuarioID"] != DBNull.Value) ? int.Parse(dt["NivelUsuarioID"].ToString()) : 0;            
            this.Nombre = (dt.Table.Columns.Contains("Nombre") && dt["Nombre"] != DBNull.Value) ? dt["Nombre"].ToString() : "";
            this.Activo = (dt.Table.Columns.Contains("Activo") && dt["Activo"] != DBNull.Value) ? (bool)dt["Activo"] : false;
            this.Solo_administrador = (dt.Table.Columns.Contains("Solo_administrador") && dt["Solo_administrador"] != DBNull.Value) ? (bool)dt["Solo_administrador"] : false;
#nullable restore
        }
        public static List<Nivel_usuario> ObtenerListaDesdeTabla(DataTable dt)
        {
            List<Nivel_usuario> _lista = new List<Nivel_usuario>();
            if (dt != null && dt?.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Nivel_usuario _nivelUsuario = new Nivel_usuario(dr);
                    _lista.Add(_nivelUsuario);
                }
            }
            return _lista;
        }
    }
}
