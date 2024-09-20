using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.WEB.Models
{
    public class AdminEditUserViewModel
    {
        public string UsuarioId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Telefono { get; set; }

        [Required]
        public string RolSeleccionado { get; set; }

        public List<string> RolesDisponibles { get; set; }
    }
}
