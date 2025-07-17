using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileArtLab.Domain.Interfaces
{
    public interface ITipoTrabajoRepository
    {
        Task<IEnumerable<TipoTrabajo>> GetAllAsync();
        Task<TipoTrabajo> GetByIdAsync(Guid id);
        Task CreateAsync(TipoTrabajo tipoTrabajo);
        Task<bool> UpdateAsync(TipoTrabajo tipoTrabajo);
        Task<bool> DeleteAsync(Guid id);
    }
}
