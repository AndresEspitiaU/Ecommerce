using Ecommerce.BD;
using Ecommerce.BD.Models;
using Ecommerce.BD.Repositorios;
using Ecommerce.PRC.Servicios;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// CONEXION A LA BASE DE DATOS
builder.Services.AddDbContext<EcommerceContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// CONFIGURACION DE IDENTIDAD
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    // Configuración de contraseñas y otros parámetros de seguridad
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
})
.AddEntityFrameworkStores<EcommerceContext>()
.AddDefaultTokenProviders();



// SERVICIOS
builder.Services.AddScoped<ColoreRepositorio>();  
builder.Services.AddScoped<ColoreServicio>();  
builder.Services.AddScoped<CuponRepositorio>();
builder.Services.AddScoped<CuponServicio>();
builder.Services.AddScoped<DescuentoRepositorio>();
builder.Services.AddScoped<DescuentoServicio>();
builder.Services.AddScoped<MarcaRepositorio>();
builder.Services.AddScoped<MarcaServicio>();
builder.Services.AddScoped<PromocionRepositorio>();
builder.Services.AddScoped<PromocionServicio>();
builder.Services.AddScoped<TallaRepositorio>();
builder.Services.AddScoped<TallaServicio>();
builder.Services.AddScoped<GeneroRepositorio>();
builder.Services.AddScoped<GeneroServicio>();
builder.Services.AddScoped<CategoriaRepositorio>();
builder.Services.AddScoped<CategoriaServicio>();
builder.Services.AddScoped<SubcategoriaRepositorio>();
builder.Services.AddScoped<SubcategoriaServicio>();
builder.Services.AddScoped<ProductoRepositorio>();
builder.Services.AddScoped<ProductoServicio>();
builder.Services.AddScoped<ColeccionRepositorio>();
builder.Services.AddScoped<ColeccionServicio>();
builder.Services.AddScoped<ProductoDescuentoRepositorio>();
builder.Services.AddScoped<ProductoDescuentoServicio>();
builder.Services.AddScoped<ProductoImagenRepositorio>();
builder.Services.AddScoped<ProductoImagenServicio>();
builder.Services.AddScoped<PromocionProductoRepositorio>();
builder.Services.AddScoped<PromocionProductoServicio>();
builder.Services.AddScoped<UsuarioRepositorio>();
builder.Services.AddScoped<UsuarioServicio>();
builder.Services.AddScoped<BannerRepositorio>();
builder.Services.AddScoped<BannerServicio>();
builder.Services.AddScoped<ProductoPorGeneroRepositorio>();
builder.Services.AddScoped<ProductoPorGeneroServicio>();



var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
