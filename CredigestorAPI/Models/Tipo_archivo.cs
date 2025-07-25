namespace CredigestorAPI.Models
{
    public class Tipo_archivo
    {
        public int TipoArchivoID { get; set; } = 0;
        public string Extension { get; set; } = string.Empty;
        public string Descripcion {  get; set; } = string.Empty;
        public bool Activo { get; set; } = false;
        public Tipo_archivo() { }
        public Tipo_archivo(int tipoarchivoid, string extension, string descripcion, bool activo)
        {
            this.TipoArchivoID = tipoarchivoid;
            this.Extension = extension;
            this.Descripcion = descripcion;
            this.Activo = activo;
        }
    }
}
