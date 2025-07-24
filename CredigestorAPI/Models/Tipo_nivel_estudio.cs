using System.Data;

namespace CredigestorAPI.Models
{
    public class Tipo_nivel_estudio
    {
        public int TipoNivelEstudioID { get; set; } = 0;
        public string Nombre { get; set; } = string.Empty;
        public bool Activo { get; set; } = false;
        public Tipo_nivel_estudio() { }
        public Tipo_nivel_estudio(int tiponivelestudioid, string nombre, bool activo)
        {
            this.TipoNivelEstudioID = tiponivelestudioid;
            this.Nombre = nombre;
            this.Activo = activo;
        }        
    }
}
