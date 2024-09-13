using Ecommerce.BD.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Ecommerce.BD.Repositorios
{
    public class ProductoDescuentoRepositorio
    {
        private readonly EcommerceContext _contexto;

        public ProductoDescuentoRepositorio(EcommerceContext contexto)
        {
            _contexto = contexto;
        }

        // Obtener todos los descuentos por producto
        public async Task<List<ProductoDescuento>> ObtenerTodosLosProductoDescuentosAsync()
        {
            return await _contexto.ProductoDescuentos
                .Include(pd => pd.Producto)    // Incluir relación con Producto
                .Include(pd => pd.Descuento)   // Incluir relación con Descuento
                .ToListAsync();
        }

        // Obtener un descuento por producto por ID
        public async Task<ProductoDescuento> ObtenerProductoDescuentoPorIdAsync(int id)
        {
            return await _contexto.ProductoDescuentos
                .Include(pd => pd.Producto)    // Incluir relación con Producto
                .Include(pd => pd.Descuento)   // Incluir relación con Descuento
                .FirstOrDefaultAsync(pd => pd.ProductoDescuentoId == id);
        }

        // Insertar un nuevo descuento para un producto
        public async Task<int> InsertarProductoDescuentoAsync(ProductoDescuento productoDescuento)
        {
            var parametros = new[]
            {
                new SqlParameter("@ProductoId", productoDescuento.ProductoId),
                new SqlParameter("@DescuentoId", productoDescuento.DescuentoId),
                new SqlParameter("@FechaInicio", productoDescuento.FechaInicio),
                new SqlParameter("@FechaFin", productoDescuento.FechaFin)
            };

            return await _contexto.Database.ExecuteSqlRawAsync("EXEC ProductoDescuento_insert @ProductoId, @DescuentoId, @FechaInicio, @FechaFin", parametros);
        }

        // Actualizar un descuento para un producto
        public async Task<int> ActualizarProductoDescuentoAsync(ProductoDescuento productoDescuento)
        {
            var parametros = new[]
            {
                new SqlParameter("@ProductoDescuentoId", productoDescuento.ProductoDescuentoId),
                new SqlParameter("@ProductoId", productoDescuento.ProductoId),
                new SqlParameter("@DescuentoId", productoDescuento.DescuentoId),
                new SqlParameter("@FechaInicio", productoDescuento.FechaInicio),
                new SqlParameter("@FechaFin", productoDescuento.FechaFin)
            };

            return await _contexto.Database.ExecuteSqlRawAsync("EXEC ProductoDescuento_update @ProductoDescuentoId, @ProductoId, @DescuentoId, @FechaInicio, @FechaFin", parametros);
        }

        // Eliminar un descuento por producto
        public async Task<int> EliminarProductoDescuentoAsync(int id)
        {
            var parametro = new SqlParameter("@ProductoDescuentoId", id);
            return await _contexto.Database.ExecuteSqlRawAsync("EXEC ProductoDescuento_delete @ProductoDescuentoId", parametro);
        }
    }
}
