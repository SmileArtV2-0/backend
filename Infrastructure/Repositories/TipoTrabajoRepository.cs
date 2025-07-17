namespace SmileArtLab.Infrastructure.Repositories
{
    public class TipoTrabajoRepository(IDbConnection _dbConnection, ITenantService tenantService) : ITipoTrabajoRepository
    {
        private readonly Guid tenantId = tenantService.TenantId;
        public async Task<IEnumerable<TipoTrabajo>> GetAllAsync()
        {
            const string sql = "SELECT * FROM tipo_trabajo WHERE TenantId = @TenantId";
            return await _dbConnection.QueryAsync<TipoTrabajo>(sql, new { TenantId = tenantId });
        }

        public async Task<TipoTrabajo> GetByIdAsync(Guid id)
        {
            const string sql = "SELECT * FROM tipo_trabajo WHERE Id = @Id AND TenantId = @TenantId";
            return await _dbConnection.QuerySingleAsync<TipoTrabajo>(sql, new { Id = id, TenantId = tenantId });
        }

        public async Task CreateAsync(TipoTrabajo tipoTrabajo)
        {
            const string sql = @"INSERT INTO tipo_trabajo (Id, TenantId, Nombre, Activo) 
                             VALUES (@Id, @TenantId, @Nombre, @Activo)";
            tipoTrabajo.TenantId = tenantId;
            await _dbConnection.ExecuteAsync(sql, tipoTrabajo);
        }

        public async Task<bool> UpdateAsync(TipoTrabajo tipoTrabajo)
        {
            const string sql = @"UPDATE tipo_trabajo 
                             SET Nombre = @Nombre, Activo = @Activo 
                             WHERE Id = @Id AND TenantId = @TenantId";
            tipoTrabajo.TenantId = tenantId;
            int affectedRows = await _dbConnection.ExecuteAsync(sql, tipoTrabajo);
            return affectedRows > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            const string sql = "DELETE FROM tipo_trabajo WHERE Id = @Id AND TenantId = @TenantId";
            int affectedRows = await _dbConnection.ExecuteAsync(sql, new { Id = id, TenantId = tenantId });
            return affectedRows > 0;
        }
    }
}
