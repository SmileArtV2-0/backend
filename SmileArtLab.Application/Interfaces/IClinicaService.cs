using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileArtLab.Application.Interfaces
{
    public interface IClinicaService
    {
        Task<IEnumerable<Clinica>> GetAllClinicasAsync();
        Task<Clinica> GetClinicaByIdAsync(Guid id);
        Task CreateClinicaAsync(Clinica clinica);
        Task<bool> UpdateClinicaAsync(Clinica clinica);
        Task<bool> DeleteClinicaAsync(Guid id);
    }
}
