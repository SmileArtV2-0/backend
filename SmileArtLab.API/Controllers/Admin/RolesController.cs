using Microsoft.AspNetCore.Authorization;

namespace SmileArtLab.API.Controllers.Admin
{
    [Authorize]
    [ApiController]
    [Route("api/admin/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IRolService _rolService;

        public RolesController(IRolService rolService)
        {
            _rolService = rolService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RolDTO>> GetById(Guid id)
        {
            var rol = await _rolService.GetByIdAsync(id, null);
            if (rol == null)
                return NotFound();

            return Ok(rol);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rol>>> GetAll()
        {
            var roles = await _rolService.GetAllAsync();
            return Ok(roles);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Rol rol)
        {
            await _rolService.CreateAsync(rol);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Rol rol)
        {
            if (id != rol.Id)
                return BadRequest();

            await _rolService.UpdateAsync(rol);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _rolService.DeleteAsync(id);
            return NoContent();
        }
    }
}
