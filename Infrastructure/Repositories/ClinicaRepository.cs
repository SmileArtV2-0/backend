
namespace SmileArtLab.Infrastructure.Repositories
{
    // SmileArtLab.Infrastructure/Repositories/ClinicaRepository.cs
    public class ClinicaRepository(IDbConnection _dbConnection, ITenantService tenantService) : IClinicaRepository
    {
        private readonly Guid tenantId = tenantService.TenantId;

        public async Task<IEnumerable<Clinica>> GetAllAsync()
        {
            const string sql = "SELECT * FROM Clinicas WHERE TenantId = @TenantId";
            return await _dbConnection.QueryAsync<Clinica>(sql, new { TenantId = tenantId });
        }

        public async Task<Clinica> GetByIdAsync(Guid id)
        {
            const string sql = "SELECT * FROM Clinicas WHERE Id = @Id AND TenantId = @TenantId";
            return await _dbConnection.QuerySingleAsync<Clinica>(sql, new { Id = id, TenantId = tenantId });
        }

        public async Task CreateAsync(Clinica clinica)
        {
            clinica.TenantId = tenantId;
            const string sql = @"INSERT INTO Clinicas (Id, TenantId, Nombre, Direccion, Telefono, Activo) 
                                 VALUES (@Id, @TenantId, @Nombre, @Direccion, @Telefono, @Activo)";
            await _dbConnection.ExecuteAsync(sql, clinica);
        }

        public async Task<bool> UpdateAsync(Clinica clinica)
        {
            const string sql = @"UPDATE Clinicas 
                                 SET Nombre = @Nombre, Direccion = @Direccion, Telefono = @Telefono, Activo = @Activo 
                                 WHERE Id = @Id AND TenantId = @TenantId";
            int affectedRows = await _dbConnection.ExecuteAsync(sql, new { clinica.Id, TenantId = tenantId, clinica.Nombre, clinica.Direccion, clinica.Telefono, clinica.Activo });
            return affectedRows > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            const string sql = "DELETE FROM Clinicas WHERE Id = @Id AND TenantId = @TenantId";
            int affectedRows = await _dbConnection.ExecuteAsync(sql, new { Id = id, TenantId = tenantId });
            return affectedRows > 0;
        }
    }


}
