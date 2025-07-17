
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using SmileArtLab.Auth.Application.Interfaces;
using SmileArtLab.Auth.Domain.Entities;

namespace SmileArtLab.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _loginService;
        private readonly IUsuarioService _usuarioService;
        private readonly IRolService _rolService;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthService loginService, IConfiguration configuration, IUsuarioService usuarioService, IRolService rolService)
        {
            _loginService = loginService;
            _configuration = configuration;
            _usuarioService = usuarioService;
            _rolService = rolService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var isValid = await _loginService.ValidateCredentialsAsync(loginRequest.Username, loginRequest.Password);
            if (isValid == null) return Unauthorized();
            var usuario = await _usuarioService.GetByIdAsync(isValid.IdUser, isValid.TenantId);
            var rol = await _rolService.GetByIdAsync(usuario.Id_rol, isValid.TenantId);

            var token = GenerateJwtToken(usuario, rol.Nombre);
            return Ok(new { Token = token });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var loginRequest = await _loginService.GetByIdAsync(id);
            if (loginRequest == null) return NotFound();
            return Ok(loginRequest);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LoginRequest loginRequest)
        {
            await _loginService.CreateAsync(loginRequest, null);
            return CreatedAtAction(nameof(GetById), new { id = loginRequest.IdUser }, loginRequest);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] LoginRequest loginRequest)
        {
            if (id != loginRequest.IdUser) return BadRequest();
            await _loginService.UpdateAsync(loginRequest);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _loginService.DeleteAsync(id);
            return NoContent();
        }

        private string GenerateJwtToken(Usuario user, string rol)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: new[] {
                    new Claim(ClaimTypes.Name, user.Nombres),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Authentication, user.TenantId.ToString()),
                    new Claim(ClaimTypes.Email, user.Email.ToString()),
                    new Claim(ClaimTypes.Role, rol),
                    new Claim(ClaimTypes.MobilePhone, user.Telefono),
                    
                 },
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
