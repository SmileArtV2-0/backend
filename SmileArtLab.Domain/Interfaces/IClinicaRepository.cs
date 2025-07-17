namespace SmileArtLab.Domain.Interfaces
{
    public interface IClinicaRepository
    {
        Task<IEnumerable<Clinica>> GetAllAsync();
        Task<Clinica> GetByIdAsync(Guid id);
        Task CreateAsync(Clinica clinica);
        Task<bool> UpdateAsync(Clinica clinica);
        Task<bool> DeleteAsync(Guid id);
    }
}
