using System.Data;

namespace CredigestorAPI.Models
{
    public class Cliente_historial_previo
    {
        public int ClienteID { get; set; } = 0;
        public int Total_creditos_anteriores { get; set; } = 0;
        public int Total_creditos_liquidados { get; set; } = 0;
        public int Total_creditos_mora { get; set; } = 0;
        public bool Tiene_comprobantes { get; set; } = false;
        public byte[] Comprobante_digitalizado { get; set; } = Array.Empty<byte>();
        public int TipoDocumentoID { get; set; } = 0;
        public string Extension { get; set; } = string.Empty;
        public Cliente_historial_previo() { }
        public Cliente_historial_previo(int clienteID, int tca, int tcl, int tcm, bool tiene_comprobante, byte[] comprobate_digitalizado, int tipodocumentoid, string extension)
        {
            this.ClienteID = clienteID;
            this.Total_creditos_anteriores = tca;
            this.Total_creditos_liquidados = tcl;
            this.Total_creditos_mora = tcm;
            this.Tiene_comprobantes = tiene_comprobante;
            this.Comprobante_digitalizado = comprobate_digitalizado;
            this.TipoDocumentoID = tipodocumentoid;
            this.Extension = extension;
        }        
    }
}
