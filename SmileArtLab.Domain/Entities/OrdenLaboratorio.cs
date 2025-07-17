namespace SmileArtLab.Domain.Entities
{
    public class OrdenLaboratorio
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public Guid IdDoctor { get; set; }
        public Guid IdClinica { get; set; }
        public string Paciente { get; set; } = string.Empty;
        public DateTime FechaEntrada { get; set; }
        public DateTime? FechaFactura { get; set; }
        public DateTime? FechaPrueba1 { get; set; }
        public DateTime? FechaPrueba2 { get; set; }
        public DateTime? FechaFinalizacion { get; set; }
        public string Estado { get; set; } = string.Empty;
        public string NumeroOrden { get; set;} = string.Empty;
        public string NumeroCaja { get; set;} = string.Empty;
        public string numeroOrdenTrabajo { get; set;} = string.Empty;
        public decimal Total { get; set; }
        public string Observacion { get; set; } = string.Empty ;
        public List<OrdenLaboratorioDetalle> DetalleOrden { get; set; } = new List<OrdenLaboratorioDetalle>();

    }
}
