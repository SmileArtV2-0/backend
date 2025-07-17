using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileArtLab.Application.Interfaces
{
    public interface ITrabajoService
    {
        Task<IEnumerable<Trabajo>> GetAllTrabajosAsync();
        Task<Trabajo> GetTrabajoByIdAsync(Guid id);
        Task CreateTrabajoAsync(Trabajo trabajo);
        Task<bool> UpdateTrabajoAsync(Trabajo trabajo);
        Task<bool> DeleteTrabajoAsync(Guid id);
        Task<IEnumerable<Trabajo>> GetTrabajoPorIdTipoAsync(Guid idTipo);
    }
}
