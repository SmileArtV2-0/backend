using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileArtLab.Domain.Interfaces
{
    public interface ITrabajoRepository
    {
        Task<IEnumerable<Trabajo>> GetAllAsync();
        Task<Trabajo> GetByIdAsync(Guid id);
        Task CreateAsync(Trabajo trabajo);
        Task<bool> UpdateAsync(Trabajo trabajo);
        Task<bool> DeleteAsync(Guid id);
        Task<IEnumerable<Trabajo>> GetTrabajoPorIdTipoAsync(Guid idTipo);
    }
}
