using Microsoft.AspNetCore.Identity;

namespace Ecommerce.WEB.Models
{
    public class UsuariosConRolesViewModel
    {
        public IdentityUser Usuario { get; set; }
        public List<string> Roles { get; set; }
    }
}
