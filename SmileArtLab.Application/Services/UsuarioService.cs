
namespace SmileArtLab.Application.Services
{
    public class UsuarioService(IUsuarioRepository usuarioRepository) : IUsuarioService
    {
        public async Task<Usuario> GetByIdAsync(Guid id, Guid? tenantId)
        {
            return await usuarioRepository.GetByIdAsync(id, tenantId);
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await usuarioRepository.GetAllAsync();
        }

        public async Task CreateAsync(Usuario usuario)
        {
            await usuarioRepository.CreateAsync(usuario);
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            await usuarioRepository.UpdateAsync(usuario);
        }

        public async Task DeleteAsync(Guid id)
        {
            await usuarioRepository.DeleteAsync(id);
        }
    }
}