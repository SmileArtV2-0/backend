
namespace SmileArtLab.Infrastructure.Repositories
{
    public class ClinicaDoctorRepository(IDbConnection _dbConnection, ITenantService tenantService) : IClinicaDoctorRepository
    {
        private readonly Guid tenantId = tenantService.TenantId;   
        public async Task CreateAsync(ClinicaDoctor clinicaDoctor)
        {
            clinicaDoctor.TenantId = tenantId;
            const string sql = "INSERT INTO clinica_doctor (id, doctorId, clinicaId, activo, tenantId) VALUES (@Id, @DoctorId, @ClinicaId, @Activo, @TenantId)";
            await _dbConnection.ExecuteAsync(sql, clinicaDoctor);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            const string sql = "DELETE FROM clinica_doctor WHERE Id = @Id and TenantId = @TenantId";
            int affectedRows = await _dbConnection.ExecuteAsync(sql, new { Id = id, TenantId = tenantId });
            return affectedRows > 0;
        }

        public async Task<IEnumerable<ClinicaDoctor>> GetClinicasByDoctor(Guid idDoctor)
        {

            const string sql = "SELECT * FROM clinica_doctor WHERE doctorId = @idDoctor and TenantId = @TenantId";
            return await _dbConnection.QueryAsync<ClinicaDoctor>(sql, new { idDoctor, TenantId = tenantId });
        }
    }
}