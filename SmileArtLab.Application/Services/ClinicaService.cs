
namespace SmileArtLab.Application.Services
{
    public class ClinicaService : IClinicaService
    {
        private readonly IClinicaRepository _clinicaRepository;

        public ClinicaService(IClinicaRepository clinicaRepository)
        {
            _clinicaRepository = clinicaRepository;
        }

        public async Task<IEnumerable<Clinica>> GetAllClinicasAsync()
        {
            return await _clinicaRepository.GetAllAsync();
        }

        public async Task<Clinica> GetClinicaByIdAsync(Guid id)
        {
            return await _clinicaRepository.GetByIdAsync(id);
        }

        public async Task CreateClinicaAsync(Clinica clinica)
        {
            await _clinicaRepository.CreateAsync(clinica);
        }

        public async Task<bool> UpdateClinicaAsync(Clinica clinica)
        {
            return await _clinicaRepository.UpdateAsync(clinica);
        }

        public async Task<bool> DeleteClinicaAsync(Guid id)
        {
            return await _clinicaRepository.DeleteAsync(id);
        }
    }
}
