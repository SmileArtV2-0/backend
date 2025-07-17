namespace SmileArtLab.Domain.Entities
{
    public class Clinica
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public bool Activo { get; set; }

        public Clinica()
        {
            Nombre = String.Empty;
            Direccion = String.Empty;
            Telefono = String.Empty;
        }
    }
}
