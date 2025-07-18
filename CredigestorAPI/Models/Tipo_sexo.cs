using System.Data;

namespace CredigestorAPI.Models
{
    public class Tipo_sexo
    {
        public int TipoSexoID { get; set; } = 0;
        public string Nombre { get; set; } = string.Empty;
        public bool Activo { get; set; } = false;
        public Tipo_sexo() { }  
        public Tipo_sexo(int tiposexoid, string nombre, bool activo)
        {
            this.TipoSexoID = tiposexoid;
            this.Nombre = nombre;
            this.Activo = activo;
        }
        public Tipo_sexo(DataRow dt)
        {
#nullable disable
            this.TipoSexoID = (dt.Table.Columns.Contains("TipoSexoID") && dt["TipoSexoID"] != DBNull.Value) ? int.Parse(dt["TipoSexoID"].ToString()) : 0;
            this.Nombre = (dt.Table.Columns.Contains("Nombre") && dt["Nombre"] != DBNull.Value) ? dt["Nombre"].ToString() : "";
            this.Activo = (dt.Table.Columns.Contains("Activo") && dt["Activo"] != DBNull.Value) ? (bool)dt["Activo"] : false;            
#nullable restore
        }
        public static List<Tipo_sexo> ObtenerListaDesdeTabla(DataTable dt)
        {
            List<Tipo_sexo> _lista = new List<Tipo_sexo>();
            if (dt != null && dt?.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Tipo_sexo _tipoSexo = new Tipo_sexo(dr);
                    _lista.Add(_tipoSexo);
                }
            }
            return _lista;
        }
    }
}
