using CredigestorAPI.BLL;
using CredigestorAPI.BLL.Interfaces;
using CredigestorAPI.BLL.Utils;
using CredigestorAPI.DAL;
using CredigestorAPI.DAL.Interfaces;
using CredigestorAPI.DAL.Utils;
using CredigestorAPI.Models.Utils;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

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
              .AllowAnyMethod();              
    });
});
// Obtener la cadena de conexión desde la configuración
string cadena_de_conexion = builder.Configuration.GetConnectionString("DefaultConnection");
//Información del swagger
var config = builder.Configuration;
var swaggerTitulo = config["Swagger:Titulo"] ?? "Credigestor API";
var swaggerDescripcion = config["Swagger:Descripcion"] ?? "API por defecto";
var swaggerVersion = config["Version"] ?? "Sin información";
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = swaggerTitulo, Version = swaggerVersion, Description = swaggerDescripcion });

    // Agregar soporte para JWT
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Introduce el token aquí: Bearer {token}"
    });

    c.EnableAnnotations();

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});
//Para el JWT
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddAuthorization();

// Registrar el conector de SQL
builder.Services.AddSingleton<ISqlAuxiliar>(new SqlAuxiliar(cadena_de_conexion));

//Registrar DAL
builder.Services.AddScoped<IUsuarioDAL, UsuarioDAL>();
builder.Services.AddScoped<INivel_usuarioDAL, Nivel_usuarioDAL>();
builder.Services.AddScoped<IMenu_webDAL, Menu_webDAL>();
builder.Services.AddScoped<IClienteDAL, ClienteDAL>();
builder.Services.AddScoped<ITipo_sexoDAL, Tipo_sexoDAL>();
builder.Services.AddScoped<ITipo_estado_civilDAL, Tipo_estado_civilDAL>();
builder.Services.AddScoped<IPaisDAL, PaisDAL>();
builder.Services.AddScoped<IEstadoDAL, EstadoDAL>();
builder.Services.AddScoped<IMunicipioDAL, MunicipioDAL>();
builder.Services.AddScoped<ITipo_area_perfilDAL, Tipo_area_perfilDAL>();
builder.Services.AddScoped<ITipo_nivel_estudioDAL, Tipo_nivel_estudioDAL>();
builder.Services.AddScoped<ITipo_documentoDAL, Tipo_documentoDAL>();
builder.Services.AddScoped<ITipo_archivoDAL, Tipo_archivoDAL>();

//Registrar BLL
builder.Services.AddScoped<IUsuarioUtils, UsuarioUtils>();
builder.Services.AddScoped<IGeneralUtils, GeneralUtils>();
builder.Services.AddScoped<IUsuarioBLL, UsuarioBLL>();
builder.Services.AddScoped<INivel_usuarioBLL, Nivel_usuarioBLL>();
builder.Services.AddScoped<IMenu_webBLL, Menu_webBLL>();
builder.Services.AddScoped<IClienteBLL, ClienteBLL>();
builder.Services.AddScoped<ITipo_sexoBLL, Tipo_sexoBLL>();
builder.Services.AddScoped<ITipo_estado_civilBLL, Tipo_estado_civilBLL>();
builder.Services.AddScoped<IPaisBLL, PaisBLL>();
builder.Services.AddScoped<IEstadoBLL, EstadoBLL>();
builder.Services.AddScoped<IMunicipioBLL, MunicipioBLL>();
builder.Services.AddScoped<ITipo_area_perfilBLL, Tipo_area_perfilBLL>();
builder.Services.AddScoped<ITipo_nivel_estudioBLL, Tipo_nivel_estudioBLL>();
builder.Services.AddScoped<ITipo_documentoBLL, Tipo_documentoBLL>();
builder.Services.AddScoped<ITipo_archivoBLL, Tipo_archivoBLL>();

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

app.UseMiddleware<ExcepcionMiddleware>(); //Manejo de errores

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers(); // Importante para que funcionen los controladores

app.UseCors("CorsPolicy");

app.Run();
