using System.Data;

namespace CredigestorAPI.Models
{
    public class Municipio
    {
        public int MunicipioID { get; set; } = 0;
        public int EstadoID { get; set; } = 0;
        public string Nombre { get; set; } = string.Empty;
        public string Siglas {  get; set; } = string.Empty;
        public bool Activo { get; set; } = false;
        public Municipio() { }
        public Municipio(int municipioid, int estadoid, string nombre, string siglas, bool activo)
        {
            this.MunicipioID = municipioid;
            this.EstadoID = estadoid;
            this.Nombre = nombre;
            this.Siglas = siglas;
            this.Activo = activo;
        }        
    }
}
