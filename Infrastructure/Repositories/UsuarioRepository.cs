
using SmileArtLab.Auth.Application.Interfaces;
using SmileArtLab.Auth.Domain.Entities;
using SmileArtLab.Auth.Domain.Interfaces;

namespace SmileArtLab.Infrastructure.Repositories
{
    public class UsuarioRepository(IDbConnection dbConnection, IAuthService authService, ITenantService tenantService) : IUsuarioRepository
    {
        private readonly Guid tenantId = tenantService.TenantId;

        public async Task<Usuario> GetByIdAsync(Guid id, Guid? tenantId)
        {
            const string query = "SELECT * FROM Usuario WHERE Id = @Id AND tenantId = @tenantId";
            return await dbConnection.QueryFirstAsync<Usuario>(query, new { Id = id, tenantId });
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            const string query = @"
                SELECT U.Id, U.Nombres, U.Telefono, U.Email, U.Cedula, U.id_rol, U.Activo, L.Username
                FROM Usuario U 
                LEFT JOIN Login L ON U.Id = L.idUser AND L.tenantId = @tenantId
                WHERE U.tenantId = @tenantId";
            return await dbConnection.QueryAsync<Usuario>(query, new { tenantId });
        }

        public async Task CreateAsync(Usuario usuario)
        {
            const string userQuery = @"
                INSERT INTO Usuario (Id, Nombres, Telefono, Email, Cedula, id_rol, Activo, tenantId) 
                VALUES (@Id, @Nombres, @Telefono, @Email, @Cedula, @id_rol, @Activo, @tenantId)";

            LoginRequest loginRequest = new LoginRequest
            {
                IdUser = usuario.Id,
                Username = usuario.UserName,
                Password = usuario.Cedula,
                TenantId = tenantId
            };

            if (dbConnection.State != ConnectionState.Open)
            {
                dbConnection.Open();
            }

            using var transaction = dbConnection.BeginTransaction();
            try
            {
                await dbConnection.ExecuteAsync(userQuery, new { usuario.Id, usuario.Nombres, usuario.Telefono, usuario.Email, usuario.Cedula, usuario.Id_rol, usuario.Activo, tenantId }, transaction);
                await authService.CreateAsync(loginRequest, transaction);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            const string query = @"
                UPDATE Usuario 
                SET Nombres = @Nombres, Telefono = @Telefono, Email = @Email, Cedula = @Cedula,
                    id_rol = @id_rol, Activo = @Activo 
                WHERE Id = @Id AND tenantId = @tenantId";
            await dbConnection.ExecuteAsync(query, new
            {
                usuario.Id,
                usuario.Nombres,
                usuario.Telefono,
                usuario.Email,
                usuario.Cedula,
                usuario.Id_rol,
                usuario.Activo,
                tenantId
            });
        }

        public async Task DeleteAsync(Guid id)
        {
            const string query = @"
                DELETE FROM login WHERE IdUser = @Id AND tenantId = @tenantId;
                DELETE FROM Usuario WHERE Id = @Id AND tenantId = @tenantId;";

            if (dbConnection.State != ConnectionState.Open)
            {
                dbConnection.Open();
            }

            using var transaction = dbConnection.BeginTransaction();
            try
            {
                await dbConnection.ExecuteAsync(query, new { Id = id, tenantId }, transaction);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}
