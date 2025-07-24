namespace CredigestorAPI.Models
{
    public class Tipo_area_perfil
    {
        public int TipoAreaPerfilID { get; set; } = 0;
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion {  get; set; } = string.Empty;
        public int Calificacion {  get; set; } = 0;
        public string Tipo { get; set; } = string.Empty;
        public bool Activo { get; set; } = false;
        public Tipo_area_perfil() { }
        public Tipo_area_perfil(int tipoareaperfilid, string nombre, string descripcion, int calificacion, string tipo, bool activo)
        {
            this.TipoAreaPerfilID = tipoareaperfilid;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Calificacion = calificacion;
            this.Tipo = tipo;
            this.Activo = activo;
        }
    }
}
