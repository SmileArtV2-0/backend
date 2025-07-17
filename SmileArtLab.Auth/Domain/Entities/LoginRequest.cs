using System.ComponentModel.DataAnnotations;

namespace SmileArtLab.Auth.Domain.Entities
{
    public class LoginRequest
    {
        [Required]
        public Guid IdUser { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public Guid TenantId { get; set; }


        public LoginRequest()
        {
            Username = string.Empty;
            Password = string.Empty;
        }
    }
}
