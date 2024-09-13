using Ecommerce.BD.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.BD.Repositorios
{
    public class ProductoImagenRepositorio
    {
        private readonly EcommerceContext _contexto;

        public ProductoImagenRepositorio(EcommerceContext contexto)
        {
            _contexto = contexto;
        }

        // Obtener todas las imágenes de un producto
        public async Task<List<ProductoImagene>> ObtenerImagenesPorProductoIdAsync(int productoId)
        {
            var parametro = new SqlParameter("@ProductoId", productoId);
            return await _contexto.ProductoImagenes
                .FromSqlRaw("EXEC ProductoImagen_listPorProductoId @ProductoId", parametro)
                .ToListAsync();
        }

        // Insertar una nueva imagen de producto
        public async Task<int> InsertarImagenAsync(ProductoImagene imagen)
        {
            var parametros = new[]
            {
                new SqlParameter("@ProductoId", imagen.ProductoId),
                new SqlParameter("@ImagenUrl", imagen.ImagenUrl ?? (object)DBNull.Value),
                new SqlParameter("@EsPrincipal", imagen.EsPrincipal),
            };

            return await _contexto.Database.ExecuteSqlRawAsync("EXEC ProductoImagen_insert @ProductoId, @ImagenUrl, @EsPrincipal", parametros);
        }

        // Obtener una imagen por su ID
        public async Task<ProductoImagene> ObtenerImagenPorIdAsync(int imagenId)
        {
            var parametro = new SqlParameter("@ImagenId", imagenId);
            var imagenes = await _contexto.ProductoImagenes
                .FromSqlRaw("EXEC ProductoImagen_listPorId @ImagenId", parametro)
                .ToListAsync();

            return imagenes.FirstOrDefault(); // Retorna la primera imagen o null si no existe
        }


        // Actualizar una imagen existente
        public async Task<int> ActualizarImagenAsync(ProductoImagene imagen)
        {
            var parametros = new[]
            {
                new SqlParameter("@ImagenId", imagen.ImagenId),
                new SqlParameter("@ImagenUrl", imagen.ImagenUrl ?? (object)DBNull.Value),
                new SqlParameter("@EsPrincipal", imagen.EsPrincipal)
            };

            return await _contexto.Database.ExecuteSqlRawAsync("EXEC ProductoImagen_update @ImagenId, @ImagenUrl, @EsPrincipal", parametros);
        }

        // Eliminar una imagen
        public async Task<int> EliminarImagenAsync(int imagenId)
        {
            var parametro = new SqlParameter("@ImagenId", imagenId);
            return await _contexto.Database.ExecuteSqlRawAsync("EXEC ProductoImagen_delete @ImagenId", parametro);
        }
    }
}
