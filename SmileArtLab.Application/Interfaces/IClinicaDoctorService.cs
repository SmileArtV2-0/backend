namespace SmileArtLab.Application.Interfaces {
    public interface IClinicaDoctorService {
        Task CreateAsync(ClinicaDoctor clinicaDoctor);
        Task<bool> DeleteAsync(Guid id);
        Task<IEnumerable<ClinicaDoctor>> GetClinicasByDoctor(Guid idDoctor);
    }
}