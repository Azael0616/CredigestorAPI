using System.Data;

namespace CredigestorAPI.Models
{
    public class Cliente_documento
    {
        public int DocumentoID { get; set; } = 0;
        public int ClienteID { get; set; } = 0;
        public int TipoDocumentoID { get; set; } = 0;
        public byte[] Contenido {  get; set; } = Array.Empty<byte>();
        public string Extension { get; set; } = string.Empty;
        public Cliente_documento() { }
        public Cliente_documento(int documentoid, int clienteid, int tipodocumentoid, byte[] contenido,string extension)
        {
            this.DocumentoID = documentoid;
            this.ClienteID = clienteid;
            this.TipoDocumentoID = tipodocumentoid;
            this.Contenido = contenido;
            this.Extension = extension;
        }        
    }
}
