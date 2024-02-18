using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectEF;

var builder = WebApplication.CreateBuilder(args);

// // configuracion general de entity framework en el proyecto para probar la configuracion con un BD en memoria
// builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));

// esto es para la conexion con mysql, aqui uso el puerto 3333 porque es el que esta desplegado en docker el puerto por defecto es el 3306
builder.Services.AddDbContext<TareasContext>(p => p.UseMySQL("Server=localhost;Database=TareasDB;Port=3333;User=root;Password=root;"));

// string connStr = "server=localhost;user=root;database=world;password=root";
// MySqlConnection conn = new MySqlConnection(connStr);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// esto es para verificar que la configuracion de los modelos y entity framework funcionan correctamente
app.MapGet("/dbconexion", async([FromServicesAttribute] TareasContext dbContext)=>{
    dbContext.Database.EnsureCreated();
    return Results.Ok($"Base de Datos Creado en Memoria: {dbContext.Database.IsInMemory()} ");
});

app.Run();