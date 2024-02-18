using Microsoft.EntityFrameworkCore;
using projectEF.Modles;

namespace projectEF;

public class TareasContext : DbContext
{

    //  se crea un set de datos
    // esto es para representar la coleccion de tods los datos
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }

    // metodo base del contructor
    public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }
}

// esto es un configuracion general para entity framework, 
// esto se hace para el entity framework tome los modelos como si fueran tablas en la base de datos