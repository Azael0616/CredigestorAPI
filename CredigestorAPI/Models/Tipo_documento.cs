namespace CredigestorAPI.Models
{
    public class Tipo_documento
    {
        public int TipoDocumentoID { get; set; } = 0;
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion {  get; set; } = string.Empty;
        public int TipoArchivoID { get; set; } = 0;
        public bool Activo { get; set; } = false;
        public bool Obligatorio { get; set; } = false;
        public byte[] Ejemplo { get; set; } = Array.Empty<byte>();
        public int TipoFormularioID { get; set; } = 0;
        public Tipo_documento() { }
        public Tipo_documento(int tipodocumentoid, string nombre, string descripcion, int tipoarchivoid, bool activo, bool obligatorio, byte[] ejemplo, int tipoformularioid) {
            this.TipoDocumentoID = tipodocumentoid;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.TipoArchivoID = tipoarchivoid;
            this.Activo = activo;
            this.Obligatorio = obligatorio;
            this.Ejemplo = ejemplo;
            this.TipoFormularioID = tipoformularioid;
        }
    }
}
