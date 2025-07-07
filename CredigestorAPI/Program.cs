using CredigestorAPI.DAL.Interfaces;
using CredigestorAPI.DAL.Utils;

var builder = WebApplication.CreateBuilder(args);

// Agrega los servicios necesarios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // Necesario para Swagger
builder.Services.AddSwaggerGen();           // Agrega generación de Swagger

// Leer orígenes permitidos del appsettings
var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();
#nullable disable
// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.WithOrigins(allowedOrigins)
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials(); // Solo si luego usas cookies o autenticación basada en sesión
    });
});
// Obtener la cadena de conexión desde la configuración
string? cadena_de_conexion = builder.Configuration.GetConnectionString("DefaultConnection");

// Registrar el conector de SQL
builder.Services.AddSingleton<ISqlAuxiliar>(new SqlAuxiliar(cadena_de_conexion));

#nullable restore
var app = builder.Build();

// Obtener la configuración
var configuration = app.Configuration;

// Endpoint que devuelve la versión
app.MapGet("/", () =>
{
    var version = configuration["Version"] ?? "Sin información"; 
    return $"API Versión: {version}";
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers(); // Importante para que funcionen los controladores

app.Run();
