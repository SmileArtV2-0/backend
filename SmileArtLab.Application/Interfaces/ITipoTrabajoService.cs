using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileArtLab.Application.Interfaces
{
    public interface ITipoTrabajoService
    {
        Task<IEnumerable<TipoTrabajo>> GetAllTiposTrabajosAsync();
        Task<TipoTrabajo> GetTipoTrabajoByIdAsync(Guid id);
        Task CreateTipoTrabajoAsync(TipoTrabajo tipoTrabajo);
        Task<bool> UpdateTipoTrabajoAsync(TipoTrabajo tipoTrabajo);
        Task<bool> DeleteTipoTrabajoAsync(Guid id);
    }
}
