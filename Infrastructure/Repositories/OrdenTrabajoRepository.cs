
using SmileArtLab.Domain.Entities;

namespace SmileArtLab.Infrastructure.Repositories
{
    public class OrdenTrabajoRepository(IDbConnection connection, ITenantService tenantService) : IOrdenTrabajoRespository
    {
        private readonly Guid tenantId = tenantService.TenantId;
        public async Task Create(OrdenTrabajo trabajo)
        {
            trabajo.TenantId = tenantId;
            const string sql = @"INSERT INTO orden_trabajo (Id, TenantId, idOrdenLab, numero, valor, observacion, fecha, estado) 
                                 VALUES (@Id, @TenantId, @IdOrdenLab, @Numero, @Valor, @Observacion, @Fecha, @Estado)";
            await connection.ExecuteAsync(sql, trabajo);
        }

        public async Task DeleteOrdenTrabajo(Guid Id)
        {
            const string sql = "DELETE FROM orden_trabajo WHERE Id = @Id AND TenantId = @TenantId";
            await connection.ExecuteAsync(sql, new { Id, TenantId = tenantId });
        }

        public async Task<IEnumerable<OrdenTrabajo>> GetAll()
        {
            const string sql = "SELECT * FROM orden_trabajo WHERE TenantId = @TenantId";
            return await connection.QueryAsync<OrdenTrabajo>(sql, new { TenantId = tenantId });
        }

        public async Task<OrdenTrabajo> GetOrdenTrabajo(Guid id)
        {
            const string sql = "SELECT * FROM orden_trabajo WHERE Id = @Id AND TenantId = @TenantId";
            return await connection.QuerySingleAsync<OrdenTrabajo>(sql, new { Id = id, TenantId = tenantId });
        }

        public async Task<OrdenTrabajo> GetOrdenTrabajoByIdOrdenLab(Guid idOrdenlab)
        {
             const string sql = "SELECT * FROM orden_trabajo WHERE IdOrdenLab = @Id AND TenantId = @TenantId";
            return await connection.QuerySingleAsync<OrdenTrabajo>(sql, new { Id = idOrdenlab, TenantId = tenantId });
        }

        public async Task Update(Guid Id, OrdenTrabajo trabajo)
        {
            trabajo.TenantId = tenantId;
            const string sql = @"UPDATE orden_trabajo 
                         SET idOrdenLab = @IdOrdenLab, numero = @Numero, valor = @Valor, 
                             observacion = @Observacion, fecha = @Fecha, estado = @Estado 
                         WHERE Id = @Id AND TenantId = @TenantId";
            await connection.ExecuteAsync(sql, trabajo);
        }
    }
}
