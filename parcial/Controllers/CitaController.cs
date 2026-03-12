using Microsoft.AspNetCore.Mvc;
namespace CitaController.Controllers
{
    [ApiController] [Route("api/citas")]
    public class CitaController : ControllerBase
    {
        private static List<Cita> citas = new List<Cita>()
        {
            new Cita { Id = 1, PacienteId = 1, MedicoId = 1, Estado = "Confirmada", Motivo = "Revisión general", FechaCreacion = DateTime.Now, FechaActualizacion = DateTime.Now },
            new Cita { Id = 2, PacienteId = 2, MedicoId = 2, Estado = "Pendiente", Motivo = "Consulta pediátrica", FechaCreacion = DateTime.Now, FechaActualizacion = DateTime.Now }
        };

        // datos para probar la validación de PacienteId y MedicoId
        private static List<int> pacientesExistentes = new List<int> { 1, 2 };
        private static List<int> medicosExistentes = new List<int> { 1, 2 };

        //Get -> lee datos
        [HttpGet]
        public IActionResult GetCitas()
        {
            try
            {
                return Ok(citas);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor: ");
            }
        }

        ///api/citas/{id}
        [HttpGet("{id}")]
        public IActionResult GetCita(int id)
        {
            try
            {
                if(id <= 0)
                {
                    return BadRequest("El id debe ser mayor a 0");
                }
                foreach (Cita c in citas)
                {
                    if (c.Id == id)
                    {
                        return Ok(c);
                    }
                }
                return NotFound("Cita no encontrada");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor: ");
            }
        }

        //Post -> registra elementos
        [HttpPost]
        public IActionResult AgregarCita([FromBody] Cita nuevaCita)
        {
            try
            {
                if (nuevaCita == null)
                {
                    return BadRequest("Debe completar los datos de la cita");
                }

                // Validar que las id de paciente y médico existan
                if (!pacientesExistentes.Contains(nuevaCita.PacienteId))
                {
                    return BadRequest($"El Paciente con ID {nuevaCita.PacienteId} no existe.");
                }
                if (!medicosExistentes.Contains(nuevaCita.MedicoId))
                {
                    return BadRequest($"El Médico con ID {nuevaCita.MedicoId} no existe.");
                }

                //obtiene id para agregar
                nuevaCita.Id = citas.Max(c => c.Id) + 1;
                // asignar fecha de actualización al momento de la creación
                nuevaCita.FechaActualizacion = DateTime.Now;
                citas.Add(nuevaCita);
                //guarda en la ruta
                return Created($"/api/citas/{nuevaCita.Id}", nuevaCita);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor: ");
            }
        }

        //Put -> actualiza elementos
        [HttpPut("{id}")]
        public IActionResult ActualizarCita(int id, [FromBody] Cita citaActualizada)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("El id debe ser mayor a 0");
                }

                // validar que las id existan
                if (!pacientesExistentes.Contains(citaActualizada.PacienteId))
                {
                    return BadRequest($"El Paciente con ID {citaActualizada.PacienteId} no existe.");
                }
                if (!medicosExistentes.Contains(citaActualizada.MedicoId))
                {
                    return BadRequest($"El Médico con ID {citaActualizada.MedicoId} no existe.");
                }

                foreach (Cita c in citas)
                {
                    if (c.Id == id)
                    {
                        c.PacienteId = citaActualizada.PacienteId;
                        c.MedicoId = citaActualizada.MedicoId;
                        c.Estado = citaActualizada.Estado;
                        c.Motivo = citaActualizada.Motivo;
                        c.FechaCreacion = citaActualizada.FechaCreacion;
                        c.FechaActualizacion = DateTime.Now;
                        return Ok("Cita actualizada correctamente");
                    }
                }

                return NotFound("Cita no encontrada");

            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor: ");
            }
        }

        //Delete -> elimina elementos
        [HttpDelete("{id}")]
        public IActionResult EliminarCita(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("El id debe ser mayor a 0");
                }
                foreach (Cita c in citas)
                {
                    if (c.Id == id)
                    {
                        citas.Remove(c);
                        return Ok("La cita ha sido eliminada correctamente");
                    }
                }

                return NotFound("Cita no encontrada");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor: ");
            }
        }

    }
}