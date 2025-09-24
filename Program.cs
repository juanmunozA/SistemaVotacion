using Microsoft.EntityFrameworkCore;
using SistemaDeVotaciones.Datos;

var builder = WebApplication.CreateBuilder(args);

// 1. Construir cadena de conexión desde variables de entorno
var dbUser = Environment.GetEnvironmentVariable("DB_USER");
var dbPass = Environment.GetEnvironmentVariable("DB_PASS");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");


var connectionString = $"Server={dbHost};Database={dbName};User Id={dbUser};Password={dbPass};TrustServerCertificate=True;";

builder.Services.AddDbContext<BaseDeDatos>(opciones =>
    opciones.UseSqlServer(connectionString));

// 3. Agregar controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(int.Parse(port));
});

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

