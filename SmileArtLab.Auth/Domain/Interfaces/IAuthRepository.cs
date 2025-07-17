using SmileArtLab.Auth.Domain.Entities;
using System.Data;

namespace SmileArtLab.Auth.Domain.Interfaces
{
    public interface IAuthRepository
    {
        Task<LoginRequest> GetByIdAsync(Guid id);
        Task<LoginRequest> GetByUsernameAsync(string username);
        Task CreateAsync(LoginRequest loginRequest, IDbTransaction? transaction);
        Task UpdateAsync(LoginRequest loginRequest);
        Task DeleteAsync(Guid id);
    }
}
