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
                await context.Response.WriteAsJsonAsync(ex.Mensaje);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(new
                {
                    error = true,
                    errorDesc = "Error interno del servidor",
                    icon = "error",
                    code = 500,
                    detalle = ex.Message
                });
            }
        }
    }
}
