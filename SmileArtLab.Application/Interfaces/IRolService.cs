namespace SmileArtLab.Application.Interfaces
{
    public interface IRolService
    {
        Task<Rol> GetByIdAsync(Guid id, Guid ?tenantId);
        Task<IEnumerable<Rol>> GetAllAsync();
        Task CreateAsync(Rol rol);
        Task UpdateAsync(Rol rol);
        Task DeleteAsync(Guid id);
    }
}
