namespace SmileArtLab.Infrastructure.Repositories
{
    public class RolRepository(IDbConnection _dbConnection, ITenantService _tenantService) : IRolRepository
    {
        private readonly Guid tenantId = _tenantService.TenantId;
        public async Task<Rol> GetByIdAsync(Guid id, Guid? tenantId)
        {
            var query = "SELECT * FROM Rol WHERE Id = @Id AND TenantId = @tenantId";
            return await _dbConnection.QuerySingleAsync<Rol>(query, new { Id = id, tenantId });
        }

        public async Task<IEnumerable<Rol>> GetAllAsync()
        {
            var query = "SELECT * FROM Rol WHERE TenantId = @tenantId";
            return await _dbConnection.QueryAsync<Rol>(query, new { tenantId });
        }

        public async Task CreateAsync(Rol rol)
        {
            var query = @"INSERT INTO Rol (Id, Nombre, Activo, TenantId) 
                  VALUES (@Id, @Nombre, @Activo, @tenantId)";
            rol.TenantId = tenantId;
            await _dbConnection.ExecuteAsync(query, rol);
        }

        public async Task UpdateAsync(Rol rol)
        {
            var query = @"UPDATE Rol SET Nombre = @Nombre, Activo = @Activo 
                  WHERE Id = @Id AND TenantId = @tenantId";
            rol.TenantId = tenantId;
            await _dbConnection.ExecuteAsync(query, rol);
        }

        public async Task DeleteAsync(Guid id)
        {
            var query = "DELETE FROM Rol WHERE Id = @Id AND TenantId = @tenantId";
            await _dbConnection.ExecuteAsync(query, new { Id = id, tenantId });
        }

    }
}
