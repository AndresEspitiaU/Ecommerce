using Ecommerce.BD.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.BD.Repositorios
{
    public class PromocionProductoRepositorio
    {
        private readonly EcommerceContext _contexto;

        public PromocionProductoRepositorio(EcommerceContext contexto)
        {
            _contexto = contexto;
        }

        // Obtener todos los productos asociados a una promoción
        public async Task<List<PromocionProducto>> ObtenerProductosPorPromocionIdAsync(int promocionId)
        {
            var parametro = new SqlParameter("@PromocionId", promocionId);
            var promocionProductos = await _contexto.PromocionProductos
                .FromSqlRaw("EXEC PromocionProducto_listPorPromocionId @PromocionId", parametro)
                .ToListAsync();

            // Cargar manualmente las relaciones del Producto
            foreach (var pp in promocionProductos)
            {
                await _contexto.Entry(pp).Reference(p => p.Producto).LoadAsync();
            }

            return promocionProductos;
        }

        // Obtener una relación Promoción-Producto por su ID
        public async Task<PromocionProducto> ObtenerPromocionProductoPorIdAsync(int promocionProductoId)
        {
            var parametro = new SqlParameter("@PromocionProductoId", promocionProductoId);
            var promocionProductos = await _contexto.PromocionProductos
                .FromSqlRaw("EXEC PromocionProducto_listPorId @PromocionProductoId", parametro)
                .ToListAsync();

            var promocionProducto = promocionProductos.FirstOrDefault();

            // Cargar manualmente las relaciones del Producto
            if (promocionProducto != null)
            {
                await _contexto.Entry(promocionProducto).Reference(p => p.Producto).LoadAsync();
            }

            return promocionProducto;
        }

        // Insertar una nueva relación Promoción-Producto
        public async Task<int> InsertarPromocionProductoAsync(PromocionProducto promocionProducto)
        {
            var parametros = new[]
            {
                new SqlParameter("@PromocionId", promocionProducto.PromocionId),
                new SqlParameter("@ProductoId", promocionProducto.ProductoId),
            };

            return await _contexto.Database.ExecuteSqlRawAsync("EXEC PromocionProducto_insert @PromocionId, @ProductoId", parametros);
        }

        // Actualizar una relación Promoción-Producto existente
        public async Task<int> ActualizarPromocionProductoAsync(PromocionProducto promocionProducto)
        {
            var parametros = new[]
            {
                new SqlParameter("@PromocionProductoId", promocionProducto.PromocionProductoId),
                new SqlParameter("@PromocionId", promocionProducto.PromocionId),
                new SqlParameter("@ProductoId", promocionProducto.ProductoId),
            };

            return await _contexto.Database.ExecuteSqlRawAsync("EXEC PromocionProducto_update @PromocionProductoId, @PromocionId, @ProductoId", parametros);
        }

        // Eliminar una relación Promoción-Producto
        public async Task<int> EliminarPromocionProductoAsync(int promocionProductoId)
        {
            var parametro = new SqlParameter("@PromocionProductoId", promocionProductoId);
            return await _contexto.Database.ExecuteSqlRawAsync("EXEC PromocionProducto_delete @PromocionProductoId", parametro);
        }
    }
}
