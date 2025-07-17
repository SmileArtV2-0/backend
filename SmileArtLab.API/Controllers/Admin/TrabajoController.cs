namespace SmileArtLab.API.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/[controller]")]
    public class TrabajoController : ControllerBase
    {
        private readonly ITrabajoService _trabajoService;

        public TrabajoController(ITrabajoService trabajoService)
        {
            _trabajoService = trabajoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trabajo>>> GetAllTrabajos()
        {
            var trabajos = await _trabajoService.GetAllTrabajosAsync();
            return Ok(trabajos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Trabajo>> GetTrabajoById(Guid id)
        {
            var trabajo = await _trabajoService.GetTrabajoByIdAsync(id);
            if (trabajo == null)
            {
                return NotFound();
            }
            return Ok(trabajo);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTrabajo(Trabajo trabajo)
        {
            await _trabajoService.CreateTrabajoAsync(trabajo);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrabajo(Guid id, Trabajo trabajo)
        {
            if (id != trabajo.Id)
            {
                return BadRequest();
            }

            var result = await _trabajoService.UpdateTrabajoAsync(trabajo);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrabajo(Guid id)
        {
            var result = await _trabajoService.DeleteTrabajoAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("tipo/{idTipo}")]
        public async Task<ActionResult<IEnumerable<Trabajo>>> GetTrabajoPorIdTipo(Guid idTipo)
        {
            var trabajos = await _trabajoService.GetTrabajoPorIdTipoAsync(idTipo);
            return Ok(trabajos);
        }
    }
}
