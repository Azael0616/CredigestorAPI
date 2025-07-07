var builder = WebApplication.CreateBuilder(args);

// Agrega los servicios necesarios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // Necesario para Swagger
builder.Services.AddSwaggerGen();           // Agrega generación de Swagger

var app = builder.Build();

// Obtener la configuración
var configuration = app.Configuration;

// Endpoint que devuelve la versión
app.MapGet("/", () =>
{
    var version = configuration["Version"] ?? "N.A"; 
    return $"API Versión: {version}";
});

// Habilita Swagger SIEMPRE (sin condicionar al entorno)
app.UseSwagger();
app.UseSwaggerUI(); // Esto muestra la UI en /swagger

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers(); // Importante para que funcionen los controladores

app.Run();
