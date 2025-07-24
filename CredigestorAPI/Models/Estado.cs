using System.Data;

namespace CredigestorAPI.Models
{
    public class Estado
    {
        public int EstadoID { get; set; } = 0;
        public int PaisID { get; set; } = 0;
        public string Nombre { get; set; } = string.Empty;
        public string Siglas {  get; set; } = string.Empty;
        public bool Activo { get; set; } = false;
        public Estado() { }
        public Estado(int estadoid, int paisid, string nombre, bool activo, string siglas) {
            this.EstadoID = estadoid;
            this.PaisID = paisid;
            this.Nombre = nombre;
            this.Activo = activo;
            this.Siglas = siglas;
        }        
    }
}
