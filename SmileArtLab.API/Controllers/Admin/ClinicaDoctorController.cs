using Microsoft.AspNetCore.Authorization;

namespace SmileArtLab.API.Controllers.Admin
{
    //[Authorize]
    [ApiController]
    [Route("api/admin/[controller]")]
    public class ClinicaDoctorController : ControllerBase
    {
        private readonly IClinicaDoctorService clinicaDoctorService;

        public ClinicaDoctorController(IClinicaDoctorService clinicaDoctorService)
        {
            this.clinicaDoctorService = clinicaDoctorService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateClinicaDoctor(ClinicaDoctor clinicaDoctor){
            var clinicas = await clinicaDoctorService.GetClinicasByDoctor(clinicaDoctor.DoctorId);
            var exist = clinicas.Where(x => x.ClinicaId == clinicaDoctor.ClinicaId);
            if (exist == null || exist.Count() == 0)
            {
                await clinicaDoctorService.CreateAsync(clinicaDoctor);
                return Created();
            }
            else
            {
                return BadRequest("Ya esta clinica se encuentra asignada a este Doctor");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClinicaDoctor(Guid id)
        {
            await clinicaDoctorService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("Doctor/{id}")]
        public async Task<IActionResult> GetClinicasByDoctor(Guid id)
        {
            var clinicas = await clinicaDoctorService.GetClinicasByDoctor(id);
            return Ok(clinicas);
        }


    }
}