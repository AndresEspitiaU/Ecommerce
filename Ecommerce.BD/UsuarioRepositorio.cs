using Ecommerce.BD.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.BD.Repositorios
{
    public class UsuarioRepositorio
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly EcommerceContext _contexto;

        public UsuarioRepositorio(UserManager<IdentityUser> userManager, EcommerceContext contexto)
        {
            _userManager = userManager;
            _contexto = contexto;
        }




        // Método para obtener el UsuarioId por el IdentityUserId
        public async Task<int?> ObtenerUsuarioIdPorIdentityIdAsync(string identityUserId)
        {
            var usuario = await _contexto.Usuarios.FirstOrDefaultAsync(u => u.IdentityUserId == identityUserId);
            return usuario?.UsuarioId; // Devuelve el UsuarioId, o null si no se encuentra
        }

        // Buscar usuario por IdentityUserId
        public async Task<IdentityUser> ObtenerUsuarioPorIdentityUserIdAsync(string identityUserId)
        {
            return await _userManager.FindByIdAsync(identityUserId);
        }

        // Obtener un usuario personalizado por UsuarioId (de la tabla Usuarios)
        public async Task<Usuario> ObtenerUsuarioPorUsuarioIdAsync(int usuarioId)
        {
            return await _contexto.Usuarios
                                  .FirstOrDefaultAsync(u => u.UsuarioId == usuarioId);
        }

        // Obtener un usuario por ID (de AspNetUsers)
        public async Task<IdentityUser> ObtenerUsuarioPorIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);  // Asegúrate de que este ID proviene de AspNetUsers
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

        public async Task<Usuario> ObtenerUsuarioPorIdentityIdAsync(string identityUserId)
        {
            return await _contexto.Usuarios
                                  .Include(u => u.IdentityUser) // Asegúrate de incluir la relación con IdentityUser
                                  .FirstOrDefaultAsync(u => u.IdentityUserId == identityUserId);
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
