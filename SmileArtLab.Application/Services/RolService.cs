namespace SmileArtLab.Application.Services
{
    public class RolService(IRolRepository rolRepository) : IRolService
    {
        public async Task<Rol> GetByIdAsync(Guid id, Guid? tenantId)
        {
            return await rolRepository.GetByIdAsync(id, tenantId);
        }

        public async Task<IEnumerable<Rol>> GetAllAsync()
        {
            return await rolRepository.GetAllAsync();
        }

        public async Task CreateAsync(Rol rol)
        {
            await rolRepository.CreateAsync(rol);
        }

        public async Task UpdateAsync(Rol rol)
        {
            await rolRepository.UpdateAsync(rol);
        }

        public async Task DeleteAsync(Guid id)
        {
            await rolRepository.DeleteAsync(id);
        }
    }

}
