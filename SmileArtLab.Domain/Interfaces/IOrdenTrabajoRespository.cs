namespace SmileArtLab.Domain.Interfaces
{
    public interface IOrdenTrabajoRespository
    {
        Task<OrdenTrabajo> GetOrdenTrabajo(Guid id);
        Task<OrdenTrabajo> GetOrdenTrabajoByIdOrdenLab(Guid idOrdenlab);
        Task<IEnumerable<OrdenTrabajo>> GetAll();
        Task Create(OrdenTrabajo trabajo);
        Task Update(Guid Id, OrdenTrabajo trabajo);
        Task DeleteOrdenTrabajo(Guid Id);
    }
}
