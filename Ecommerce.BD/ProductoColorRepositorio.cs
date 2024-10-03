using Ecommerce.BD.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.BD.Repositorios
{
    public class ProductoColorRepositorio
    {
        private readonly EcommerceContext _contexto;

        public ProductoColorRepositorio(EcommerceContext contexto)
        {
            _contexto = contexto;
        }


        public async Task<List<Producto>> ObtenerTodosLosProductosConColoresAsync()
        {
            try
            {
                return await _contexto.Productos
                    .Include(p => p.ProductoColores) // Cargar la relación ProductoColor
                        .ThenInclude(pc => pc.Colores) // Cargar la entidad Colore relacionada
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener productos con colores: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Excepción interna: {ex.InnerException.Message}");
                }
                return new List<Producto>();
            }
        }



        // Insertar un color asociado a un producto
        public async Task InsertarProductoColorAsync(int productoId, int colorId)
        {
            var productoIdParam = new SqlParameter("@ProductoId", productoId);
            var colorIdParam = new SqlParameter("@ColorId", colorId);

            await _contexto.Database.ExecuteSqlRawAsync("EXEC ProductoColor_Insert @ProductoId, @ColorId", productoIdParam, colorIdParam);
        }

        // Actualizar los colores asociados a un producto (recibe un CSV con los IDs de colores)
        public async Task ActualizarProductoColoresAsync(int productoId, string colorIdsCsv)
        {
            var productoIdParam = new SqlParameter("@ProductoId", productoId);
            var colorIdsParam = new SqlParameter("@ColorIds", colorIdsCsv);

            await _contexto.Database.ExecuteSqlRawAsync("EXEC ProductoColor_Update @ProductoId, @ColorIds", productoIdParam, colorIdsParam);
        }

       

        // Listar todos los colores asociados a un producto
      public async Task<List<Color>> ObtenerColoresPorProductoAsync(int productoId)
        {
            try
            {
                return await _contexto.ProductoColores
                    .Where(pc => pc.ProductoId == productoId)
                    .Select(pc => pc.Colores)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener colores por producto: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Excepción interna: {ex.InnerException.Message}");
                }
                return new List<Color>();
            }
        }


        // Eliminar todos los colores asociados a un producto
        public async Task EliminarProductoColorAsync(int productoId, int colorId)
        {
            var productoIdParam = new SqlParameter("@ProductoId", productoId);
            var colorIdParam = new SqlParameter("@ColorId", colorId);

            // Ejecuta el procedimiento almacenado
            await _contexto.Database.ExecuteSqlRawAsync("EXEC ProductoColor_Delete @ProductoId, @ColorId", productoIdParam, colorIdParam);
        }


    }
}
