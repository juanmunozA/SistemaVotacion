using Microsoft.EntityFrameworkCore;
using SistemaDeVotaciones.Datos;

var builder = WebApplication.CreateBuilder(args);

// 1. Agregar la conexión a la base de datos
builder.Services.AddDbContext<BaseDeDatos>(opciones =>
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Agregar controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(int.Parse(port));
});

var app = builder.Build();

// 3. Configurar el pipeline HTTP

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


app.Run();
