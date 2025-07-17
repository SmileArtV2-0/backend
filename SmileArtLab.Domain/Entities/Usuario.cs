namespace SmileArtLab.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public string Nombres { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Cedula { get; set; }
        public string UserName { get; set; }
        public Guid Id_rol { get; set; }
        public bool Activo { get; set; }

        public Usuario()
        {
            Nombres = string.Empty;
            Telefono = string.Empty;
            Email = string.Empty;
            Cedula = string.Empty;
            UserName = string.Empty;
        }
    }
}
