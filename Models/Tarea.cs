using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projectEF.Modles;

public class Tarea
{
    [Key]
    public Guid TareaId { get; set; }
    [ForeignKey("FK_CaterogiaId")] // definicion de una clave foranea
    public Guid CategoriaId { get; set; }
    [Required]
    [MaxLength(200)]
    public string Titulo { get; set; }
    public string Descripcion { get; set; }
    public Prioridad PrioridadTarea { get; set; }
    public DateTime FechaCreaccion { get; set; }

    // este campo es para poder establecar la relaciones entre las 2 tablas
    public virtual Categoria Categoria { get; set; }
    [NotMapped] // esto para que se omita el campo al momento de la creacion de la base datos
    public string Resumen { get; set; }
}

public enum Prioridad
{
    Baja, Media, Alta
}