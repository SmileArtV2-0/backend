namespace SmileArtLab.Domain.Entities
{
    public class Rol
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public string Nombre { get; set; }
        public bool? Activo { get; set; }


        public Rol()
        {
            Nombre = string.Empty;
        }
    }
}