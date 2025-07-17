using System.Data;
using SmileArtLab.Auth.Domain.Entities;
using SmileArtLab.Auth.Domain.Interfaces;
using Dapper;
using SmileArtLab.Auth.Application.Interfaces;

namespace SmileArtLab.Auth.Infrastructure.Repository
{
    public class AuthRepository(IDbConnection _dbConnection) : IAuthRepository
    {
          public async Task<LoginRequest> GetByIdAsync(Guid id)
        {
            const string sql = "SELECT * FROM dbo.login WHERE IdUser = @Id";
            return await _dbConnection.QuerySingleOrDefaultAsync<LoginRequest>(sql, new { Id = id });
        }

        public async Task<LoginRequest> GetByUsernameAsync(string username)
        {
            const string sql = "SELECT * FROM login WHERE Username = @Username";
            return await _dbConnection.QuerySingleAsync<LoginRequest>(sql, new { Username = username });
        }

        public async Task CreateAsync(LoginRequest loginRequest, IDbTransaction transaction)
        {
            const string sql = @"INSERT INTO login (IdUser, Username, Password, TenantId) 
                                 VALUES (@IdUser, @Username, @Password, @TenantId)";
            await _dbConnection.ExecuteAsync(sql, loginRequest, transaction);
        }

        public async Task UpdateAsync(LoginRequest loginRequest)
        {
            const string sql = @"UPDATE login 
                                 SET Username = @Username, Password = @Password 
                                 WHERE IdUser = @IdUser";
            await _dbConnection.ExecuteAsync(sql, loginRequest);
        }

        public async Task DeleteAsync(Guid id)
        {
            const string sql = "DELETE FROM login WHERE IdUser = @Id";
            await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
