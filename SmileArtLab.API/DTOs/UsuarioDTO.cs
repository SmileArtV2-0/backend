
namespace SmileArtLab.Web.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Cedula { get; set; }
        public string UserName { get; set; }
        public string Clave { get; set; }
        public int? id_rol { get; set; }
        public bool? Activo { get; set; }
    }
}
