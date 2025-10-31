using Microsoft.EntityFrameworkCore;
using webEscuela.Infrastructure.Data; // <= Namespace del DbContext
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configuration: leer connection string desde env var o appsettings
var configuration = builder.Configuration;
var envConn = Environment.GetEnvironmentVariable("CONNECTION_STRING");
var connectionString = string.IsNullOrWhiteSpace(envConn)
    ? configuration.GetConnectionString("DefaultConnection")
    : envConn;

// Registrar DbContext con Pomelo MySQL
builder.Services.AddDbContext<EscuelaDbContext>(options =>
{
    // ServerVersion.AutoDetect funciona bien si la cadena apunta a un servidor MySQL accesible
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

// Agregar controladores si existen
builder.Services.AddControllers();

// Swagger (opcional)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Plataforma Educativa API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Plataforma Educativa API v1"));
}

app.UseRouting();
app.UseAuthorization();

app.MapControllers();

// Si todavía tienes endpoints mínimos (mapGet etc.), mantenlos o móvalos a controladores.
app.Run();