namespace SmileArtLab.Domain.Entities
{
    public class OrdenLaboratorioDetalle
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public Guid IdOrden { get; set; }
        public Guid IdTrabajo { get; set; }
        public int Cantidad { get; set; }
        public decimal Itbms { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Descuento { get; set; }
        public int Porcentaje { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
