using SmileArtLab.Auth.Domain;
using SmileArtLab.Auth.Domain.Entities;
using System.Data;

namespace SmileArtLab.Auth.Application.Interfaces
{
    public interface IAuthService
    {
        Task<LoginRequest> GetByIdAsync(Guid id);
        Task<LoginRequest> GetByUsernameAsync(string username);
        Task CreateAsync(LoginRequest loginRequest, IDbTransaction transaction);
        Task UpdateAsync(LoginRequest loginRequest);
        Task DeleteAsync(Guid id);
        Task<LoginRequest> ValidateCredentialsAsync(string username, string password);
    }
}
