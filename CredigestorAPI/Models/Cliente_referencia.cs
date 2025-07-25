using System.Data;

namespace CredigestorAPI.Models
{
    public class Cliente_referencia
    {
        public int ReferenciaID { get; set; } = 0;
        public int ClienteID { get; set; } = 0;
        public string Nombre_completo { get; set; } = string.Empty;
        public string Telefono_referencia {  get; set; } = string.Empty;
        public string Telefono_referencia_prefijo { get; set; } = string.Empty;
        public string Correo_electronico {  get; set; } = string.Empty;
        public Cliente_referencia() { }
        public Cliente_referencia(int referenciaid, int clienteid, string nombre_completo, string telefono_referencia, string telefono_referencia_prefijo, string correo_electronico)
        {
            this.ReferenciaID = referenciaid;
            this.ClienteID = clienteid;
            this.Nombre_completo = nombre_completo;
            this.Telefono_referencia = telefono_referencia;
            this.Telefono_referencia_prefijo = telefono_referencia_prefijo;
            this.Correo_electronico = correo_electronico;
        }        
    }
}
