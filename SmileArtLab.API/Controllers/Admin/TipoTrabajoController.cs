namespace SmileArtLab.API.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/[controller]")]
    public class TipoTrabajoController : ControllerBase
    {
        private readonly ITipoTrabajoService _tipoTrabajoService;

        public TipoTrabajoController(ITipoTrabajoService tipoTrabajoService)
        {
            _tipoTrabajoService = tipoTrabajoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoTrabajo>>> GetAllTiposTrabajos()
        {
            var tiposTrabajos = await _tipoTrabajoService.GetAllTiposTrabajosAsync();
            return Ok(tiposTrabajos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoTrabajo>> GetTipoTrabajoById(Guid id)
        {
            var tipoTrabajo = await _tipoTrabajoService.GetTipoTrabajoByIdAsync(id);
            if (tipoTrabajo == null)
            {
                return NotFound();
            }
            return Ok(tipoTrabajo);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTipoTrabajo(TipoTrabajo tipoTrabajo)
        {
            await _tipoTrabajoService.CreateTipoTrabajoAsync(tipoTrabajo);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTipoTrabajo(Guid id, TipoTrabajo tipoTrabajo)
        {
            if (id != tipoTrabajo.Id)
            {
                return BadRequest();
            }

            var result = await _tipoTrabajoService.UpdateTipoTrabajoAsync(tipoTrabajo);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoTrabajo(Guid id)
        {
            var result = await _tipoTrabajoService.DeleteTipoTrabajoAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }

}
