using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileArtLab.Application.Services
{
    public class TipoTrabajoService : ITipoTrabajoService
    {
        private readonly ITipoTrabajoRepository _tipoTrabajoRepository;

        public TipoTrabajoService(ITipoTrabajoRepository tipoTrabajoRepository)
        {
            _tipoTrabajoRepository = tipoTrabajoRepository;
        }

        public async Task<IEnumerable<TipoTrabajo>> GetAllTiposTrabajosAsync()
        {
            return await _tipoTrabajoRepository.GetAllAsync();
        }

        public async Task<TipoTrabajo> GetTipoTrabajoByIdAsync(Guid id)
        {
            return await _tipoTrabajoRepository.GetByIdAsync(id);
        }

        public async Task CreateTipoTrabajoAsync(TipoTrabajo tipoTrabajo)
        {
            await _tipoTrabajoRepository.CreateAsync(tipoTrabajo);
        }

        public async Task<bool> UpdateTipoTrabajoAsync(TipoTrabajo tipoTrabajo)
        {
            return await _tipoTrabajoRepository.UpdateAsync(tipoTrabajo);
        }

        public async Task<bool> DeleteTipoTrabajoAsync(Guid id)
        {
            return await _tipoTrabajoRepository.DeleteAsync(id);
        }
    }
}
