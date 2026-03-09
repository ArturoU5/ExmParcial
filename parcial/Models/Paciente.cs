using System.ComponentModel.DataAnnotations;

public class Paciente
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage ="El nombre del paciente es obligatorio.")]
    public string Nombre { get; set; } ="" ;
    
    [Required(ErrorMessage ="Los apellidos del paciente son obligatorios.")]
    public string Apellido { get; set; } ="" ;
    
    [Required(ErrorMessage ="El DNI del paciente es obligatorio.")]
    [MinLength(8, ErrorMessage = "El DNI debe ser de 8 caracteres.")]
    [MaxLength(8, ErrorMessage = "El DNI debe ser de 8 caracteres.")]
    public string DNI { get; set; } ="" ;

    [Required(ErrorMessage ="El teléfono del paciente es obligatorio.")]
    public string Telefono { get; set; } ="" ;
}