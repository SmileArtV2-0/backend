using Microsoft.AspNetCore.Authorization;

namespace SmileArtLab.API.Controllers.Admin
{
    // SmileArtLab.API/Controllers/ClinicaController.cs
    [ApiController]
    [Route("api/admin/[controller]")]
    public class ClinicaController : ControllerBase
    {
        private readonly IClinicaService _clinicaService;

        public ClinicaController(IClinicaService clinicaService)
        {
            _clinicaService = clinicaService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clinica>>> GetAllClinicas()
        {
            var clinicas = await _clinicaService.GetAllClinicasAsync();
            return Ok(clinicas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Clinica>> GetClinicaById(Guid id)
        {
            var clinica = await _clinicaService.GetClinicaByIdAsync(id);
            if (clinica == null)
            {
                return NotFound();
            }
            return Ok(clinica);
        }

        [HttpPost]
        public async Task<ActionResult> CreateClinica(Clinica clinica)
        {
            await _clinicaService.CreateClinicaAsync(clinica);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClinica(Guid id, Clinica clinica)
        {
            if (id != clinica.Id)
            {
                return BadRequest();
            }

            var result = await _clinicaService.UpdateClinicaAsync(clinica);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClinica(Guid id)
        {
            var result = await _clinicaService.DeleteClinicaAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }

}
