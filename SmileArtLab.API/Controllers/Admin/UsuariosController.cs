using Microsoft.AspNetCore.Authorization;
using SmileArtLab.Auth.Application.Interfaces;
using SmileArtLab.Auth.Domain.Entities;

//[Authorize]
[ApiController]
[Route("api/admin/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;
    private readonly IAuthService _authService;

    public UsuariosController(IUsuarioService usuarioService, IAuthService authService)
    {
        _usuarioService = usuarioService;
        _authService = authService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UsuarioDTO>> GetById(Guid id)
    {
        var usuario = await _usuarioService.GetByIdAsync(id, null);
        if (usuario == null)
            return NotFound();

        return Ok(usuario);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Usuario>>> GetAll()
    {
        var usuarios = await _usuarioService.GetAllAsync();
        return Ok(usuarios);
    }

    [HttpPost]
    public async Task<ActionResult> Create(Usuario usuario)
    {

        await _usuarioService.CreateAsync(usuario);
        return Created();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, Usuario usuario)
    {
        if (id != usuario.Id)
            return BadRequest();

        await _usuarioService.UpdateAsync(usuario);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _usuarioService.DeleteAsync(id);
        return NoContent();
    }


}
