using Ecommerce.BD.Repositorios;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.PRC.Servicios
{
    public class UsuarioServicio
    {
        private readonly UsuarioRepositorio _usuarioRepositorio;

        public UsuarioServicio(UsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        // Crear un nuevo usuario
        public async Task<IdentityResult> CrearUsuarioAsync(string email, string password)
        {
            return await _usuarioRepositorio.CrearUsuarioAsync(email, password);
        }

        // Obtener un usuario por ID
        public async Task<IdentityUser> ObtenerUsuarioPorIdAsync(string userId)
        {
            return await _usuarioRepositorio.ObtenerUsuarioPorIdAsync(userId);
        }

        // Obtener un usuario por email
        public async Task<IdentityUser> ObtenerUsuarioPorEmailAsync(string email)
        {
            return await _usuarioRepositorio.ObtenerUsuarioPorEmailAsync(email);
        }

        // Actualizar un usuario
        public async Task<IdentityResult> ActualizarUsuarioAsync(IdentityUser usuario)
        {
            return await _usuarioRepositorio.ActualizarUsuarioAsync(usuario);
        }

        // Eliminar un usuario
        public async Task<IdentityResult> EliminarUsuarioAsync(IdentityUser usuario)
        {
            return await _usuarioRepositorio.EliminarUsuarioAsync(usuario);
        }

        // Listar todos los usuarios
        public async Task<List<IdentityUser>> ListarUsuariosAsync()
        {
            return await _usuarioRepositorio.ListarUsuariosAsync();
        }
    }
}
