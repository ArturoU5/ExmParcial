using Microsoft.AspNetCore.Mvc;
namespace PacienteController.Controllers

{
    [ApiController]
    [Route("api/pacientes")]
    public class PacienteController : ControllerBase
    {
        private static List<Paciente> pacientes = new List<Paciente>()
        {
            new Paciente { Id = 1, Nombre = "Pepe", Apellido = "Maravi", DNI = "12345678", Telefono = "984654123" },
            new Paciente { Id = 2, Nombre = "Isabel", Apellido = "Jackson", DNI = "87654321", Telefono = "984654124" }
        };

        //Get -> lee datos
        [HttpGet]
        public IActionResult GetPacientes()
        {
            try
            {
                return Ok(pacientes);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor: ");
            }
        }
        ///api/pacientes/{id}
        [HttpGet("{id}")]
        public IActionResult GetPaciente(int id)
        {
            try
            {
                if(id <= 0)
                {
                    return BadRequest("El id debe ser mayor a 0");
                }
                foreach (Paciente p in pacientes)
                {
                    if (p.Id == id)
                    {
                        return Ok(p);
                    }
                }
                return NotFound("Paciente no encontrado");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor: ");
            }
        }



        //Post -> registra elementos
        [HttpPost]
        public IActionResult AgregarPaciente ([FromBody] Paciente nuevoPaciente)
        {
            try
            {
                if (nuevoPaciente == null)
                {
                    return BadRequest("Debe completar los datos del paciente");
                }
                //obtiene id para agregar
                nuevoPaciente.Id=pacientes.Max(p=>p.Id)+1;
                pacientes.Add(nuevoPaciente);
                //guarda en la ruta
                return Created($"/api/pacientes/{nuevoPaciente.Id}", nuevoPaciente);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor: ");
            }
        }

        //Put -> actualiza elementos
        [HttpPut("{id}")]
        public IActionResult ActualizarPaciente(int id, [FromBody] Paciente pacienteActualizado)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("El id debe ser mayor a 0");
                }
                foreach (Paciente p in pacientes)
                {
                    if (p.Id == id)
                    {
                        p.Nombre = pacienteActualizado.Nombre;
                        p.Apellido = pacienteActualizado.Apellido;
                        p.DNI = pacienteActualizado.DNI;
                        p.Telefono = pacienteActualizado.Telefono;
                        return Ok("Paciente actualizado correctamente");
                    }
                }

                return NotFound("Paciente no encontrado");

            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor: ");
            }
        }

        //Delete -> elimina elementos
        [HttpDelete("{id}")]
        public IActionResult EliminarPaciente(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("El id debe ser mayor a 0");
                }
                foreach (Paciente p in pacientes)
                {
                    if (p.Id == id)
                    {
                        pacientes.Remove(p);
                        return Ok("El paciente a sido eliminado correctamente");
                    }
                }



                return NotFound("Paciente no encontrado");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor: ");
            }
        }

    }
}