using System.Data;

namespace CredigestorAPI.Models
{
    public class Pais
    {
        public int PaisID { get; set; } = 0;
        public string Nombre { get; set; } = string.Empty;
        public string Siglas {  get; set; } = string.Empty;
        public bool Activo { get; set; } = false;
        public Pais() { }
        public Pais(int paisid, string nombre, string siglas, bool activo)
        {
            this.PaisID = paisid;
            this.Nombre = nombre;
            this.Siglas = siglas;
            this.Activo = activo;
        }        
    }
}
