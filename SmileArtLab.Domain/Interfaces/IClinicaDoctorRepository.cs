namespace SmileArtLab.Domain.Interfaces {
    public interface IClinicaDoctorRepository
    {
        Task CreateAsync(ClinicaDoctor clinicaDoctor);
        Task<bool> DeleteAsync(Guid id);
        Task<IEnumerable<ClinicaDoctor>> GetClinicasByDoctor( Guid idDoctor);
    }
}