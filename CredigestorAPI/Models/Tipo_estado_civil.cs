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
    }
}
