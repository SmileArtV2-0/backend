

namespace SmileArtLab.Application.Services
{
    public class OrdenLaboratorioService : IOrdenLaboratorioService
    {
        private readonly IOrdenLaboratorioRepository repository;

        public OrdenLaboratorioService(IOrdenLaboratorioRepository repository)
        {
            this.repository = repository;
        }
        public async Task CreateOrden(OrdenLaboratorio orden)
        {
            await repository.CreateOrden(orden);
        }

        public async Task<OrdenLaboratorio> ObtenerOrden(Guid idOrden)
        {
            return await repository.ObtenerOrden(idOrden);
        }

        public async Task<IEnumerable<OrdenLaboratorio>> ObtenerOrdenes()
        {
            return await repository.ObtenerOrdenes();
        }

        public async Task<IEnumerable<OrdenLaboratorioDetalle>> obtenerDetalle(Guid idOrden)
        {
            return await repository.obtenerDetalle(idOrden);
        }

        public async Task AgregarFechaPrueba(Guid idOrden, DateTime fecha)
        {
           await repository.AgregarFechaPrueba(idOrden, fecha);
        }

        public async Task AgregarFechaFactura(Guid idOrden, DateTime fecha, int numeroFactura){
            await repository.AgregarFechaFactura(idOrden, fecha, numeroFactura);
        }

        public async Task UpdateOrdenDetalle(Guid ordenId, IEnumerable<OrdenLaboratorioDetalle> detalles)
        {
            await repository.UpdateOrdenDetalle(ordenId, detalles);
        }

        public async Task CambiarEstadoOrden(Guid idOrden, string nuevoEstado){
            await repository.CambiarEstadoOrden(idOrden, nuevoEstado);
        }

        public async Task<int> ObtenerNumeroOrdenTrabajo()
        {
            return await repository.ObtenerNumeroOrdenTrabajo();
        }
    }
}
