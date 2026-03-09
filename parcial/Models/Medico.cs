using System.ComponentModel.DataAnnotations;

public class Medico
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage ="El nombre del médico es obligatorio.")]
    public string Nombre { get; set; } ="" ;
    
    [Required(ErrorMessage ="Los apellidos del médico son obligatorios.")]
    public string Apellido { get; set; } ="" ;
    
    [Required(ErrorMessage ="La especialidad del médico es obligatoria.")]
    public string Especialidad { get; set; } ="" ;

    [Required(ErrorMessage ="El DNI del médico es obligatorio.")]
    [MinLength(8, ErrorMessage = "El DNI debe ser de 8 caracteres.")]
    public string DNI { get; set; } ="" ;

}