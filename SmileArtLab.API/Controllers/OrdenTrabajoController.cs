namespace SmileArtLab.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class OrdenTrabajoController(IOrdenTrabajoService ordenTrabajoService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrdenTrabajo ordenTrabajo)
        {
            await ordenTrabajoService.Create(ordenTrabajo);
            return Created();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ordenesTrabajo = await ordenTrabajoService.GetAll();
            return Ok(ordenesTrabajo);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var orden = await ordenTrabajoService.GetOrdenTrabajo(id);
            return Ok();
        }

        [HttpGet("byIdOrdenLab/{idOrdenLab}")]
        public async Task<IActionResult> GetByIdOrdenLab(Guid idOrdenLab)
        {
            var orden = await ordenTrabajoService.GetOrdenTrabajo(idOrdenLab);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] OrdenTrabajo ordenTrabajo)
        {
            await ordenTrabajoService.Update(id, ordenTrabajo);
            return Created();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await ordenTrabajoService.DeleteOrdenTrabajo(id);
            return NoContent();
        }
    }
}
