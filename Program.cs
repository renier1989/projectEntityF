using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectEF;

var builder = WebApplication.CreateBuilder(args);


// configuracion general de entity framework en el proyecto
builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", async([FromServicesAttribute] TareasContext dbContext)=>{
    dbContext.Database.EnsureCreated();
    return Results.Ok($"Base de Datos Creado en Memoria: {dbContext.Database.IsInMemory()} ");
});

app.Run();


