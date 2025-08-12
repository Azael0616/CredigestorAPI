namespace CredigestorAPI.Models.Utils
{
    public class ExcepcionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExcepcionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (HttpResponseException ex)
            {
                context.Response.StatusCode = ex.Codigo;
                context.Response.ContentType = "application/json";
                var resultado = new ResultadoBD
                {
                    Error = true,
                    ErrorDesc = ex.Mensaje,
                    Icon = ex.Icono,
                    Code = ex.Codigo                    
                };
                await context.Response.WriteAsJsonAsync(resultado);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(new ResultadoBD
                {
                    Error = true,
                    ErrorDesc = "Error interno del servidor",
                    Icon = "error",
                    Code = 500,
                    Detalle = ex.Message
                });
            }
        }
    }
}
