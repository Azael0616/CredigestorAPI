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
    }
}
