using System.Data;

namespace CredigestorAPI.Models
{
    public class Cliente_direccion
    {
        public int ClienteID { get; set; } = 0;
        public string Calle {  get; set; } = string.Empty;
        public string Numero_exterior { get; set; } = string.Empty;
        public string Numero_interior { get; set; } = string.Empty;
        public string Entre_calle1 {  get; set; } = string.Empty;
        public string Entre_calle2 {  get; set; } = string.Empty;
        public string Colonia {  get; set; } = string.Empty;
        public int PaisID { get; set; } = 0;
        public int EstadoID { get; set; } = 0;
        public int MunicipioID { get; set; } = 0;
        public string Referencia_casa {  get; set; } = string.Empty;
        public Cliente_direccion() { }
        public Cliente_direccion(int clienteid, string calle, string numero_exterior, string numero_interior, string entre_calle1,string entre_calle2, string colonia,
            int paisid, int estadoid, int municipioid)
        {
            this.ClienteID = clienteid;
            this.Calle = calle;
            this.Numero_exterior = numero_exterior;
            this.Numero_interior = numero_interior;
            this.Entre_calle1 = entre_calle1;
            this.Entre_calle2 = entre_calle2;
            this.Colonia = colonia;
            this.PaisID= paisid;
            this.EstadoID= estadoid;
            this.MunicipioID = municipioid;
        }        
    }
}
