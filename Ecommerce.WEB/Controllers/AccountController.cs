using Ecommerce.WEB.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.WEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<IdentityUser> userManager,
                                 SignInManager<IdentityUser> signInManager,
                                 RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        // Registro de nuevos usuarios (Clientes)
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // Asignar el rol de "Cliente" por defecto si es un usuario regular
                    if (!await _roleManager.RoleExistsAsync("Cliente"))
                    {
                        await _roleManager.CreateAsync(new IdentityRole("Cliente"));
                    }

                    // Opcional: Verifica si el rol "Administrador" existe y lo crea si no
                    if (!await _roleManager.RoleExistsAsync("Administrador"))
                    {
                        await _roleManager.CreateAsync(new IdentityRole("Administrador"));
                    }

                    // Asignar el rol de "Cliente" por defecto
                    await _userManager.AddToRoleAsync(user, "Cliente");

                    // Iniciar sesión automáticamente después del registro
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    // Verificar si el usuario tiene el rol de "Administrador"
                    if (await _userManager.IsInRoleAsync(user, "Administrador"))
                    {
                        // Si es administrador, redirigirlo a una vista específica
                        return RedirectToAction("Dashboard", "Admin");
                    }
                    else
                    {
                        // Si es cliente, redirigirlo al Home
                        return RedirectToAction("Index", "Home");
                    }
                }

                // Manejo de errores de registro
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }



        // Iniciar sesión
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    // Obtener el usuario autenticado
                    var user = await _userManager.FindByEmailAsync(model.Email);

                    // Redirigir según el rol
                    var roles = await _userManager.GetRolesAsync(user);
                    if (roles.Contains("Administrador"))
                    {
                        return RedirectToAction("Index", "Dashboard");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }

                ModelState.AddModelError(string.Empty, "Inicio de sesión inválido.");
            }

            return View(model);
        }


        // Cerrar sesión
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        // Vista de acceso denegado
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
