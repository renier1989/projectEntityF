using System.ComponentModel.DataAnnotations;

namespace projectEF.Modles;

public class Categoria
{
    [Key] // esto es un datanotation para indicar que el campo CategoriaId sera tomado como la llave primaria
    public Guid CategoriaId { get; set; }
    [Required] // esto hace el campo sea siempre requirido en la tabla cuando se hace algun registro de datos
    [MaxLength(150)] // limite de caracteres para este campo
    public string Nombre { get; set; }
    public string Descripcion { get; set; }

    // esto es para poder establecer las relaciones entre las 2 tablas
    public virtual ICollection<Tarea> Tareas { get; set; }
}