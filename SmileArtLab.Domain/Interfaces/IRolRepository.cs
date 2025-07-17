namespace SmileArtLab.Domain.Interfaces
{
    public interface IRolRepository
    {
        Task<Rol> GetByIdAsync(Guid id, Guid? tenantId);
        Task<IEnumerable<Rol>> GetAllAsync();
        Task CreateAsync(Rol rol);
        Task UpdateAsync(Rol rol);
        Task DeleteAsync(Guid id);
    }
}
