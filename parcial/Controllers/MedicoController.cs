using Microsoft.AspNetCore.Mvc;
namespace MedicoController.Controllers
{
    [ApiController] [Route("api/medicos")]
    public class MedicoController : ControllerBase
    {
        // lista de especialidades permitidas para validación
        private static readonly List<string> especialidadesValidas = new List<string>
        {
            "Cardiologia",
            "Pediatria",
            "Dermatologia",
            "Neurologia",
            "Oftalmologia"
        };

        // lista de valores simulados
        private static List<Medico> medicos = new List<Medico>()
        {
            new Medico { Id = 1, Nombre = "Alonzo", Apellido = "Huaman", Especialidad = "Cardiologia", DNI = "12345678" },
            new Medico { Id = 2, Nombre = "María", Apellido = "Gómez", Especialidad = "Pediatria", DNI = "87654321" }
        };

        //Get -> lee datos
        [HttpGet]
        public IActionResult GetMedicos()
        {
            try
            {
                return Ok(medicos);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor: ");
            }
        }

        ///api/medicos/{id}
        [HttpGet("{id}")]
        public IActionResult GetMedico(int id)
        {
            try
            {
                if(id <= 0)
                {
                    return BadRequest("El id debe ser mayor a 0");
                }
                foreach (Medico m in medicos)
                {
                    if (m.Id == id)
                    {
                        return Ok(m);
                    }
                }
                return NotFound("Médico no encontrado");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor: ");
            }
        }

        //Post -> registra elementos
        [HttpPost]
        public IActionResult AgregarMedico([FromBody] Medico nuevoMedico)
        {
            try
            {
                if (nuevoMedico == null)
                {
                    return BadRequest("Debe completar los datos del médico");
                }
                if (string.IsNullOrWhiteSpace(nuevoMedico.Especialidad))
                {
                    return BadRequest("La especialidad del médico es obligatoria.");
                }
                if (!especialidadesValidas.Contains(nuevoMedico.Especialidad))
                {
                    return BadRequest($"Especialidad no válida. Valores permitidos: {string.Join(", ", especialidadesValidas)}");
                }
                //obtiene id para agregar
                nuevoMedico.Id = medicos.Max(m => m.Id) + 1;
                medicos.Add(nuevoMedico);
                //guarda en la ruta
                return Created($"/api/medicos/{nuevoMedico.Id}", nuevoMedico);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor: ");
            }
        }

        //Put -> actualiza elementos
        [HttpPut("{id}")]
        public IActionResult ActualizarMedico(int id, [FromBody] Medico medicoActualizado)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("El id debe ser mayor a 0");
                }
                foreach (Medico m in medicos)
                {
                    if (m.Id == id)
                    {
                        m.Nombre = medicoActualizado.Nombre;
                        m.Apellido = medicoActualizado.Apellido;
                        if (string.IsNullOrWhiteSpace(medicoActualizado.Especialidad))
                        {
                            return BadRequest("La especialidad del médico es obligatoria.");
                        }
                        if (!especialidadesValidas.Contains(medicoActualizado.Especialidad))
                        {
                            return BadRequest($"Especialidad no válida. Valores permitidos: {string.Join(", ", especialidadesValidas)}");
                        }
                        m.Especialidad = medicoActualizado.Especialidad;
                        m.DNI = medicoActualizado.DNI;
                        return Ok("Médico actualizado correctamente");
                    }
                }

                return NotFound("Médico no encontrado");

            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor: ");
            }
        }

        //Delete -> elimina elementos
        [HttpDelete("{id}")]
        public IActionResult EliminarMedico(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("El id debe ser mayor a 0");
                }
                foreach (Medico m in medicos)
                {
                    if (m.Id == id)
                    {
                        medicos.Remove(m);
                        return Ok("El médico ha sido eliminado correctamente");
                    }
                }

                return NotFound("Médico no encontrado");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno del servidor: ");
            }
        }

    }
}