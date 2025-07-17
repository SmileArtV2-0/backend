

namespace SmileArtLab.Application.Services
{
    public class ClinicaDoctorService : IClinicaDoctorService
    {
        private readonly IClinicaDoctorRepository clinicaDoctorRepository;

        public ClinicaDoctorService(IClinicaDoctorRepository clinicaDoctorRepository)
{
            this.clinicaDoctorRepository = clinicaDoctorRepository;
        }

        public async Task CreateAsync(ClinicaDoctor clinicaDoctor)
        {
            await clinicaDoctorRepository.CreateAsync(clinicaDoctor);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
           return await clinicaDoctorRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ClinicaDoctor>> GetClinicasByDoctor(Guid idDoctor)
        {
           return await clinicaDoctorRepository.GetClinicasByDoctor(idDoctor);
        }
    }
}