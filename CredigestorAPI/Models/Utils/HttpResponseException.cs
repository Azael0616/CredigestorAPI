namespace CredigestorAPI.Models.Utils
{
    public class HttpResponseException : Exception
    {
        public int Codigo { get; }
        public string Mensaje { get; }
        public string Icono { get; }

        public HttpResponseException(int codigo, string mensaje,string icono = "info") : base(mensaje)
        {
            Codigo = codigo;
            Mensaje = mensaje;
            Icono = icono;
        }        
    }
}
