namespace SmileArtLab.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario> GetByIdAsync(Guid id, Guid? tenantId);
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task CreateAsync(Usuario usuario);
        Task UpdateAsync(Usuario usuario);
        Task DeleteAsync(Guid id);
    }
}
