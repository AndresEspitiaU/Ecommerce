using Ecommerce.BD.Models;
using Ecommerce.BD.Repositorios;
using Ecommerce.PRC.Servicios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CONFIGURACION DE LA BASE DE DATOS
builder.Services.AddDbContext<EcommerceContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// CONFIGURACION DE LOS REPOSITORIOS
builder.Services.AddScoped<ColoreRepositorio>();
builder.Services.AddScoped<ColoreServicio>();
builder.Services.AddScoped<CuponRepositorio>();
builder.Services.AddScoped<CuponServicio>();
builder.Services.AddScoped<DescuentoRepositorio>();
builder.Services.AddScoped<DescuentoServicio>();

builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
