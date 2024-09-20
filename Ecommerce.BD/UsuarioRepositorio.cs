using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.BD.Repositorios
{
    public class UsuarioRepositorio
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UsuarioRepositorio(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        // Crear un nuevo usuario
        public async Task<IdentityResult> CrearUsuarioAsync(string email, string password)
        {
            var usuario = new IdentityUser
            {
                UserName = email,
                Email = email
            };

            return await _userManager.CreateAsync(usuario, password);
        }

        // Obtener un usuario por ID
        public async Task<IdentityUser> ObtenerUsuarioPorIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        // Obtener un usuario por email
        public async Task<IdentityUser> ObtenerUsuarioPorEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        // Actualizar un usuario
        public async Task<IdentityResult> ActualizarUsuarioAsync(IdentityUser usuario)
        {
            return await _userManager.UpdateAsync(usuario);
        }

        // Eliminar un usuario
        public async Task<IdentityResult> EliminarUsuarioAsync(IdentityUser usuario)
        {
            return await _userManager.DeleteAsync(usuario);
        }

        // Listar todos los usuarios
        public async Task<List<IdentityUser>> ListarUsuariosAsync()
        {
            return await Task.FromResult(new List<IdentityUser>(_userManager.Users));
        }
    }
}
