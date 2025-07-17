
using SmileArtLab.Domain.Entities;

namespace SmileArtLab.Infrastructure.Repositories
{
    public class OrdenLaboratorioRepository(IDbConnection _connection, ITenantService tenantService) : IOrdenLaboratorioRepository
    {
        private readonly Guid tenantId = tenantService.TenantId;

        public async Task CreateOrden(Domain.Entities.OrdenLaboratorio orden)
        {
            _connection.Open();
            const string sqlOrden = @"INSERT INTO orden_laboratorio (id, tenantId, idDoctor, idClinica, paciente, fechaEntrada, estado, numeroOrden, numeroCaja, total, observacion, fechaPrueba1, fechaPrueba2, fechaFinalizacion) 
                VALUES (@Id, @TenantId, @IdDoctor, @IdClinica, @Paciente, @FechaEntrada, @Estado, @NumeroOrden, @NumeroCaja, @Total, @Observacion, @FechaPrueba1, @FechaPrueba2, @FechaFinalizacion)";
            const string sqlDetalle = @"INSERT INTO orden_laboratorio_detalle (id, tenantId, idOrden, idTrabajo, cantidad, precioUnitario, itbms, descuento, porcentaje, valorTotal) 
                VALUES (@Id, @TenantId, @IdOrden, @IdTrabajo, @Cantidad, @PrecioUnitario, @Itbms, @Descuento, @Porcentaje, @ValorTotal)";

            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    orden.TenantId = tenantId;
                    await _connection.ExecuteAsync(sqlOrden, orden, transaction);
                    foreach (var item in orden.DetalleOrden)
                    {
                        item.TenantId = tenantId;
                        await _connection.ExecuteAsync(sqlDetalle, item, transaction);
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public async Task<OrdenLaboratorio> ObtenerOrden(Guid idOrden)
        {
            _connection.Open();
            const string sql = @"SELECT * FROM orden_laboratorio WHERE id = @Id AND tenantId = @TenantId";
            return await _connection.QueryFirstAsync<OrdenLaboratorio>(sql, new { Id = idOrden, TenantId = tenantId });
        }

        public Task<IEnumerable<OrdenLaboratorio>> ObtenerOrdenes()
        {
            _connection.Open();
            const string sql = @"SELECT * FROM orden_laboratorio Where tenantId = @TenantId ORDER BY fechaEntrada DESC";
            return _connection.QueryAsync<OrdenLaboratorio>(sql, new { TenantId = tenantId });
        }

        public async Task<IEnumerable<OrdenLaboratorioDetalle>> obtenerDetalle(Guid idOrden)
        {
            _connection.Open();
            const string sql = "SELECT * FROM orden_laboratorio_detalle WHERE idOrden = @idOrden AND tenantId = @TenantId";
            return await _connection.QueryAsync<OrdenLaboratorioDetalle>(sql, new { idOrden, TenantId = tenantId });
        }

        public async Task AgregarFechaPrueba(Guid idOrden, DateTime fecha)
        {

            var consultarPrueba1 = await this.ObtenerOrden(idOrden);
            if (consultarPrueba1.FechaPrueba1 == default(DateTime))
            {
                const string sql = "UPDATE orden_laboratorio SET fechaPrueba1 = @Fecha WHERE id = @Id AND tenantId = @TenantId";
                await _connection.ExecuteAsync(sql, new { Fecha = fecha, Id = idOrden, TenantId = tenantId });
            }
            else if (consultarPrueba1.FechaPrueba2 == default(DateTime))
            {
                const string sql = "UPDATE orden_laboratorio SET fechaPrueba2 = @Fecha WHERE id = @Id AND tenantId = @TenantId";
                await _connection.ExecuteAsync(sql, new { Fecha = fecha, Id = idOrden, TenantId = tenantId });
            }
        }

        public Task AgregarFechaFactura(Guid idOrden, DateTime fecha, int numeroFactura)
        {
            _connection.Open();
            const string sql = "UPDATE orden_laboratorio SET fechaFactura = @Fecha, numeroOrdenTrabajo = @NumeroFactura WHERE id = @Id AND tenantId = @TenantId";
            return _connection.ExecuteAsync(sql, new { Fecha = fecha, Id = idOrden, NumeroFactura = numeroFactura, TenantId = tenantId });
        }

        public async Task UpdateOrdenDetalle(Guid ordenId, IEnumerable<OrdenLaboratorioDetalle> detalles)
        {
            _connection.Open();
            const string sqlDeleteDetalle = @"DELETE FROM orden_laboratorio_detalle WHERE idOrden = @OrdenId AND tenantId = @TenantId";
            const string sqlInsertDetalle = @"INSERT INTO orden_laboratorio_detalle (id, tenantId, idOrden, idTrabajo, cantidad, precioUnitario, itbms, descuento, porcentaje, valorTotal) 
        VALUES (@Id, @TenantId, @IdOrden, @IdTrabajo, @Cantidad, @PrecioUnitario, @Itbms, @Descuento, @Porcentaje, @ValorTotal)";

            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    // Delete existing details for the order
                    await _connection.ExecuteAsync(sqlDeleteDetalle, new { OrdenId = ordenId, TenantId = tenantId }, transaction);

                    // Insert new details
                    foreach (var item in detalles)
                    {
                        item.TenantId = tenantId;
                        await _connection.ExecuteAsync(sqlInsertDetalle, item, transaction);
                    }

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public async Task CambiarEstadoOrden(Guid idOrden, string nuevoEstado)
        {
            _connection.Open();
            const string sql = "UPDATE orden_laboratorio SET estado = @Estado WHERE id = @Id and tenantId = @TenantId";
            await _connection.ExecuteAsync(sql, new { Estado = nuevoEstado, Id = idOrden, TenantId = tenantId });
        }

        public async Task<int> ObtenerNumeroOrdenTrabajo()
        {
             _connection.Open();
            const string sql = @"SELECT MAX(numeroOrdenTrabajo) FROM orden_laboratorio WHERE tenantId = @TenantId";
            var result = await _connection.QueryFirstAsync<int?>(sql, new { TenantId = tenantId });
            if (result == null || result == 0) 
            {
                return 1;
            }
            else
            {
                return result.Value + 1;
            }
        }
    }

}


