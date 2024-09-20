using System.ComponentModel.DataAnnotations;

namespace Ecommerce.WEB.Models
{
    public class AdminCreateUserViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmPassword { get; set; }

        public string Telefono { get; set; }

        [Required]
        public string Rol { get; set; }

        public List<string> RolesDisponibles { get; set; }
    }
}
