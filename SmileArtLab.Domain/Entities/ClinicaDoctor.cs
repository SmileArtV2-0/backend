namespace  SmileArtLab.Domain.Entities{
    public class ClinicaDoctor
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public Guid ClinicaId { get; set; }
        public Guid DoctorId { get; set; }
        public bool Activo { get; set; }
    }
}