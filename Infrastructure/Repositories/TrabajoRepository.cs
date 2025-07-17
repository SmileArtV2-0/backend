namespace SmileArtLab.Infrastructure.Repositories
{
    public class TrabajoRepository(IDbConnection _dbConnection, ITenantService tenantService) : ITrabajoRepository
    {
        private readonly Guid tenantId = tenantService.TenantId;
        public async Task<IEnumerable<Trabajo>> GetAllAsync()
        {
            const string sql = "SELECT * FROM trabajo WHERE TenantId = @TenantId";
            return await _dbConnection.QueryAsync<Trabajo>(sql, new { TenantId = tenantId });
        }

        public async Task<Trabajo> GetByIdAsync(Guid id)
        {
            const string sql = "SELECT * FROM trabajo WHERE Id = @Id AND TenantId = @TenantId";
            return await _dbConnection.QuerySingleAsync<Trabajo>(sql, new { Id = id, TenantId = tenantId });
        }

        public async Task CreateAsync(Trabajo trabajo)
        {
            const string sql = @"INSERT INTO trabajo (Id, TenantId, Nombre, Precio, Id_TipoTrabajo, Activo) 
                                 VALUES (@Id, @TenantId, @Nombre, @Precio, @Id_TipoTrabajo, @Activo)";
            await _dbConnection.ExecuteAsync(sql, trabajo);
        }

        public async Task<bool> UpdateAsync(Trabajo trabajo)
        {
            const string sql = @"UPDATE trabajo 
                                 SET Nombre = @Nombre, Precio = @Precio, 
                                     Id_TipoTrabajo = @Id_TipoTrabajo, Activo = @Activo 
                                 WHERE Id = @Id AND TenantId = @TenantId";
            int affectedRows = await _dbConnection.ExecuteAsync(sql, trabajo);
            return affectedRows > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            const string sql = "DELETE FROM trabajo WHERE Id = @Id AND TenantId = @TenantId";
            int affectedRows = await _dbConnection.ExecuteAsync(sql, new { Id = id, TenantId = tenantId });
            return affectedRows > 0;
        }

        public Task<IEnumerable<Trabajo>> GetTrabajoPorIdTipoAsync(Guid idTipo)
        {
            const string sql = "SELECT * FROM trabajo WHERE Id_TipoTrabajo = @IdTipo AND TenantId = @TenantId";
            return _dbConnection.QueryAsync<Trabajo>(sql, new { IdTipo = idTipo, TenantId = tenantId });
        }
    }
}
