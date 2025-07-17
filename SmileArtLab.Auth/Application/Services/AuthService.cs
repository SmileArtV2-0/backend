using System.Data;
using System.Security.Cryptography;
using System.Text;
using SmileArtLab.Auth.Application.Interfaces;
using SmileArtLab.Auth.Domain.Entities;
using SmileArtLab.Auth.Domain.Interfaces;

namespace SmileArtLab.Auth.Application.Services
{
    public class AuthService(IAuthRepository _authRepository, ITenantService tenantService) : IAuthService
    {

        public async Task<LoginRequest> GetByIdAsync(Guid id)
        {
            return await _authRepository.GetByIdAsync(id);
        }

        public async Task<LoginRequest> GetByUsernameAsync(string username)
        {
            return await _authRepository.GetByUsernameAsync(username);
        }

        public async Task CreateAsync(LoginRequest loginRequest, IDbTransaction transaction)
        {
            loginRequest.Password = HashPassword(loginRequest.Password);
            await _authRepository.CreateAsync(loginRequest, transaction);
        }

        public async Task UpdateAsync(LoginRequest loginRequest)
        {
            loginRequest.Password = HashPassword(loginRequest.Password);
            await _authRepository.UpdateAsync(loginRequest);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _authRepository.DeleteAsync(id);
        }

        public async Task<LoginRequest> ValidateCredentialsAsync(string username, string password)
        {
            var loginRequest = await _authRepository.GetByUsernameAsync(username);
            if (loginRequest == null) return null;
            var exist = HashPassword(password) == loginRequest.Password;
            return loginRequest;
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
