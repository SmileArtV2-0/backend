namespace SmileArtLab.Domain.Interfaces
{
    public interface IOrdenLaboratorioRepository
    {
        Task CreateOrden(OrdenLaboratorio orden);
        Task<OrdenLaboratorio> ObtenerOrden(Guid idOrden);
        Task<IEnumerable<OrdenLaboratorio>> ObtenerOrdenes();
        Task<IEnumerable<OrdenLaboratorioDetalle>> obtenerDetalle(Guid idOrden);
        Task AgregarFechaPrueba(Guid idOrden, DateTime fecha);
        Task AgregarFechaFactura(Guid idOrden, DateTime fecha, int numeroFactura);
        Task UpdateOrdenDetalle(Guid ordenId, IEnumerable<OrdenLaboratorioDetalle> detalles);
        Task CambiarEstadoOrden(Guid idOrden, string nuevoEstado);
        Task<int> ObtenerNumeroOrdenTrabajo();
    }
}
