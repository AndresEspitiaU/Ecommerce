using Ecommerce.BD.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.BD.Repositorios
{
    public class ProductoTallaRepositorio
    {
        private readonly EcommerceContext _contexto;

        public ProductoTallaRepositorio(EcommerceContext contexto)
        {
            _contexto = contexto;
        }

        // Obtener todas las relaciones de Producto con Talla
        public async Task<List<ProductoTalla>> ObtenerTodosLosProductoTallasAsync()
        {
            return await _contexto.ProductoTallas
                .Include(pt => pt.Producto)
                .Include(pt => pt.Talla)
                .ToListAsync();
        }

        // Obtener ProductoTalla por ID
        public async Task<ProductoTalla> ObtenerProductoTallaPorIdAsync(int id)
        {
            return await _contexto.ProductoTallas
                .AsNoTracking()
                .Include(pt => pt.Producto)
                .Include(pt => pt.Talla)
                .FirstOrDefaultAsync(pt => pt.ProductoTallaId == id);
        }

        // Crear un nuevo ProductoTalla
        public async Task<int> CrearProductoTallaAsync(ProductoTalla productoTalla)
        {
            _contexto.ProductoTallas.Add(productoTalla);
            return await _contexto.SaveChangesAsync();
        }

        // Actualizar un ProductoTalla existente
        public async Task<int> ActualizarProductoTallaAsync(ProductoTalla productoTalla)
        {
            _contexto.ProductoTallas.Update(productoTalla);
            return await _contexto.SaveChangesAsync();
        }

        // Repositorio: Eliminar un ProductoTalla usando un procedimiento almacenado
        public async Task<int> EliminarProductoTallaAsync(int id)
        {
            var parametro = new SqlParameter("@ProductoTallaId", id);
            return await _contexto.Database.ExecuteSqlRawAsync("EXEC ProductoTalla_delete @ProductoTallaId", parametro);
        }



    }
}
