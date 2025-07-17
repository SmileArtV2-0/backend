
namespace SmileArtLab.Application.Services
{
    public class OrdenTrabajoService(IOrdenTrabajoRespository repository) : IOrdenTrabajoService
    {
        public async Task Create(OrdenTrabajo trabajo)
        {
            await repository.Create(trabajo);
        }

        public async Task DeleteOrdenTrabajo(Guid Id)
        {
            await repository.DeleteOrdenTrabajo(Id);
        }

        public Task<IEnumerable<OrdenTrabajo>> GetAll()
        {
            return repository.GetAll();
        }

        public Task<OrdenTrabajo> GetOrdenTrabajo(Guid id)
        {
            return repository.GetOrdenTrabajo(id);
        }

        public async Task Update(Guid Id, OrdenTrabajo trabajo)
        {
            await repository.Update(Id, trabajo);
        }

        public async Task<OrdenTrabajo> GetOrdenTrabajoByIdOrdenLab(Guid idOrdenlab)
        {
            return await repository.GetOrdenTrabajoByIdOrdenLab(idOrdenlab);
        }
    }
}
