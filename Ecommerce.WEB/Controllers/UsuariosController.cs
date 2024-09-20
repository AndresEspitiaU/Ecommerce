using Ecommerce.PRC.Servicios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Ecommerce.WEB.Models;

namespace Ecommerce.WEB.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class UsuariosController : Controller
    {
        private readonly UsuarioServicio _usuarioServicio;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsuariosController(UsuarioServicio usuarioServicio, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _usuarioServicio = usuarioServicio;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET: Usuarios/Index
        public async Task<IActionResult> Index()
        {
            var usuarios = _userManager.Users.ToList();
            var usuariosConRoles = new List<UsuariosConRolesViewModel>();

            foreach (var usuario in usuarios)
            {
                var roles = await _userManager.GetRolesAsync(usuario);
                usuariosConRoles.Add(new UsuariosConRolesViewModel
                {
                    Usuario = usuario,
                    Roles = roles.ToList()
                });
            }

            return View(usuariosConRoles);
        }

        // GET: Usuarios/Crear
        public async Task<IActionResult> Crear()
        {
            var model = new AdminCreateUserViewModel
            {
                RolesDisponibles = await ObtenerRolesDisponibles()
            };
            return View(model);
        }

        // POST: Usuarios/Crear
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(AdminCreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email, PhoneNumber = model.Telefono };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // Verificar si el rol seleccionado existe y asignarlo
                    if (!await _roleManager.RoleExistsAsync(model.Rol))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(model.Rol));
                    }

                    await _userManager.AddToRoleAsync(user, model.Rol);

                    return RedirectToAction(nameof(Index));
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            model.RolesDisponibles = await ObtenerRolesDisponibles();
            return View(model);
        }

        // GET: Usuarios/Editar/5
        public async Task<IActionResult> Editar(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var usuario = await _userManager.FindByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            var rolesUsuario = await _userManager.GetRolesAsync(usuario);

            var model = new AdminEditUserViewModel
            {
                Email = usuario.Email,
                Telefono = usuario.PhoneNumber,
                RolSeleccionado = rolesUsuario.Count > 0 ? rolesUsuario[0] : null,
                RolesDisponibles = await ObtenerRolesDisponibles()
            };

            return View(model);
        }

        // POST: Usuarios/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(string id, AdminEditUserViewModel model)
        {
            var usuario = await _userManager.FindByIdAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                usuario.Email = model.Email;
                usuario.PhoneNumber = model.Telefono;

                var result = await _userManager.UpdateAsync(usuario);
                if (result.Succeeded)
                {
                    // Actualizar rol
                    var rolesActuales = await _userManager.GetRolesAsync(usuario);
                    if (rolesActuales.Count > 0)
                    {
                        await _userManager.RemoveFromRolesAsync(usuario, rolesActuales);
                    }
                    await _userManager.AddToRoleAsync(usuario, model.RolSeleccionado);

                    return RedirectToAction(nameof(Index));
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            model.RolesDisponibles = await ObtenerRolesDisponibles();
            return View(model);
        }

        // GET: Usuarios/Eliminar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Eliminar(string id)
        {
            var usuario = await _userManager.FindByIdAsync(id);

            if (usuario == null)
            {
                return Json(new { success = false, message = "Usuario no encontrado." });
            }

            var result = await _userManager.DeleteAsync(usuario);

            if (result.Succeeded)
            {
                return Json(new { success = true, message = "Usuario eliminado con éxito." });
            }

            var errorMessages = result.Errors.Select(e => e.Description).ToList();
            return Json(new { success = false, message = string.Join(", ", errorMessages) });
        }





        // Método auxiliar para obtener la lista de roles disponibles
        private async Task<List<string>> ObtenerRolesDisponibles()
        {
            return await Task.FromResult(_roleManager.Roles.Select(r => r.Name).ToList());
        }
    }
}
