using System.Data;

namespace CredigestorAPI.Models
{
    public class Tipo_estado_civil
    {
        public int TipoEstadoCivilID { get; set; } = 0;
        public string Nombre { get; set; } = string.Empty;
        public bool Activo { get; set; } = false;
        public Tipo_estado_civil() { }
        public Tipo_estado_civil(int tipoestadocivilid, string nombre, bool activo) {
            this.TipoEstadoCivilID = tipoestadocivilid;
            this.Nombre = nombre;
            this.Activo = activo;
        }
        public Tipo_estado_civil(DataRow dt)
        {
#nullable disable
            this.TipoEstadoCivilID = (dt.Table.Columns.Contains("TipoEstadoCivilID") && dt["TipoEstadoCivilID"] != DBNull.Value) ? int.Parse(dt["TipoEstadoCivilID"].ToString()) : 0;
            this.Nombre = (dt.Table.Columns.Contains("Nombre") && dt["Nombre"] != DBNull.Value) ? dt["Nombre"].ToString() : "";
            this.Activo = (dt.Table.Columns.Contains("Activo") && dt["Activo"] != DBNull.Value) ? (bool)dt["Activo"] : false;            
#nullable restore
        }
        public static List<Tipo_estado_civil> ObtenerListaDesdeTabla(DataTable dt)
        {
            List<Tipo_estado_civil> _lista = new List<Tipo_estado_civil>();
            if (dt != null && dt?.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Tipo_estado_civil _tipoEstadoCivil = new Tipo_estado_civil(dr);
                    _lista.Add(_tipoEstadoCivil);
                }
            }
            return _lista;
        }

    }
}
