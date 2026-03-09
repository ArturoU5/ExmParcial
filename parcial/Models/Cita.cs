using System.ComponentModel.DataAnnotations;

public class Cita
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "El ID del paciente es obligatorio.")]
    public int PacienteId { get; set; }
    
    [Required(ErrorMessage = "El ID del médico es obligatorio.")]
    public int MedicoId { get; set; }

    [Required(ErrorMessage = "Debe agregar el estado de la cita.")]
    public string Estado { get; set; } ="" ;
    
    [Required(ErrorMessage = "Debe agregar el motivo de la cita.")]
    public string Motivo { get; set; } ="" ;
    
    [Required]
    public DateTime Fecha { get; set; }
}