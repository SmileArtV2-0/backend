using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileArtLab.Application.Services
{
    public class TrabajoService : ITrabajoService
    {
        private readonly ITrabajoRepository _trabajoRepository;

        public TrabajoService(ITrabajoRepository trabajoRepository)
        {
            _trabajoRepository = trabajoRepository;
        }

        public async Task<IEnumerable<Trabajo>> GetAllTrabajosAsync()
        {
            return await _trabajoRepository.GetAllAsync();
        }

        public async Task<Trabajo> GetTrabajoByIdAsync(Guid id)
        {
            return await _trabajoRepository.GetByIdAsync(id);
        }

        public async Task CreateTrabajoAsync(Trabajo trabajo)
        {
            await _trabajoRepository.CreateAsync(trabajo);
        }

        public async Task<bool> UpdateTrabajoAsync(Trabajo trabajo)
        {
            return await _trabajoRepository.UpdateAsync(trabajo);
        }

        public async Task<bool> DeleteTrabajoAsync(Guid id)
        {
            return await _trabajoRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Trabajo>> GetTrabajoPorIdTipoAsync(Guid idTipo)
        {
            return await _trabajoRepository.GetTrabajoPorIdTipoAsync(idTipo);
        }
    }
}
