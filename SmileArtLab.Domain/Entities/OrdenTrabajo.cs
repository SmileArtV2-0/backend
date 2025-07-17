namespace SmileArtLab.Domain.Entities
{
    public class OrdenTrabajo
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public Guid IdOrdenLab { get; set; }
        public string Numero { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public DateTime Fecha { get; set; }
        public string Observacion { get; set; } = string.Empty ;
        public bool Estado { get; set; }

    }
}
