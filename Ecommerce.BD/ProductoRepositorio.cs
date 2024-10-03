using Ecommerce.BD.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.BD.Repositorios
{
    public class ProductoRepositorio
    {
        private readonly EcommerceContext _contexto;

        public ProductoRepositorio(EcommerceContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<int> ContarProductosPorCategoriaAsync(int categoriaId)
        {
            // Cuenta cuántos productos pertenecen a una categoría específica
            return await _contexto.Productos.CountAsync(p => p.ProCategoriaId == categoriaId);
        }


        // Obtener todos los productos (sin importar si están activos o no)
        public async Task<List<Producto>> ObtenerTodosLosProductosAsync(int? categoriaId = null, int? subcategoriaId = null)
        {
            var parametros = new List<SqlParameter>
            {
                 new SqlParameter("@ProCategoriaId", categoriaId ?? (object)DBNull.Value),
                 new SqlParameter("@SubcategoriaId", subcategoriaId ?? (object)DBNull.Value)
            };

            return await _contexto.Productos
                .FromSqlRaw("EXEC Producto_list @ProCategoriaId, @SubcategoriaId", parametros.ToArray())
                .ToListAsync();
        }

        // Obtener solo productos activos
        // Obtener solo productos activos
        public async Task<List<Producto>> ObtenerProductosActivosAsync(int? categoriaId = null, int? subcategoriaId = null)
        {
            var parametros = new List<SqlParameter>
    {
        new SqlParameter("@ProCategoriaId", categoriaId ?? (object)DBNull.Value),
        new SqlParameter("@SubcategoriaId", subcategoriaId ?? (object)DBNull.Value)
    };

            return _contexto.Productos
                .FromSqlRaw("EXEC Producto_list @ProCategoriaId, @SubcategoriaId", parametros.ToArray())
                .AsEnumerable()  
                .Where(p => p.ProActivo)  
                .ToList(); 
        }




        // Obtener una imagen por su ID
        public async Task<ProductoImagene> ObtenerImagenPorIdAsync(int imagenId)
        {
            var parametro = new SqlParameter("@ImagenId", imagenId);
            var imagen = await _contexto.ProductoImagenes
                .FromSqlRaw("EXEC ProductoImagen_listPorId @ImagenId", parametro)  
                .FirstOrDefaultAsync();

            return imagen;
        }


        // Obtener producto por ID
        public async Task<Producto> ObtenerProductoPorIdAsync(int id)
        {
            var parametro = new SqlParameter("@ProductoId", id);

            // Obtenemos el producto con el procedimiento almacenado
            var productos = await _contexto.Productos
                .FromSqlRaw("EXEC Producto_listPorId @ProductoId", parametro)
                .ToListAsync();

            var producto = productos.FirstOrDefault();

            if (producto != null)
            {
                // Cargar las referencias relacionadas como las imágenes
                await _contexto.Entry(producto).Collection(p => p.ProductoImagenes).LoadAsync();  // Cargar las imágenes
                await _contexto.Entry(producto).Reference(p => p.ProCategoria).LoadAsync();
                await _contexto.Entry(producto).Reference(p => p.Subcategoria).LoadAsync();
                await _contexto.Entry(producto).Reference(p => p.ProMarca).LoadAsync();
                await _contexto.Entry(producto).Reference(p => p.ProColeccion).LoadAsync();
                await _contexto.Entry(producto).Reference(p => p.ProGenero).LoadAsync();
            }

            return producto;
        }



        //ObtenerProductosFiltradosAsync
        public async Task<List<Producto>> ObtenerProductosFiltradosAsync(List<int> categoriaIds, List<int> marcaIds, decimal? precioMin, decimal? precioMax)
        {
            var productosQuery = _contexto.Productos.AsQueryable();

            // Filtro por categorías
            if (categoriaIds != null && categoriaIds.Any())
            {
                productosQuery = productosQuery.Where(p => categoriaIds.Contains(p.ProCategoriaId ?? 0));
            }

            // Filtro por marcas
            if (marcaIds != null && marcaIds.Any())
            {
                productosQuery = productosQuery.Where(p => marcaIds.Contains(p.ProMarcaId ?? 0));
            }

            // Filtro por rango de precios
            if (precioMin.HasValue)
            {
                productosQuery = productosQuery.Where(p => p.ProPrecio >= precioMin.Value);
            }

            if (precioMax.HasValue)
            {
                productosQuery = productosQuery.Where(p => p.ProPrecio <= precioMax.Value);
            }

            // Solo productos activos
            productosQuery = productosQuery.Where(p => p.ProActivo);

            // Ejecutar la consulta y devolver los resultados
            return await productosQuery.ToListAsync();
        }



        // Insertar un nuevo producto
        public async Task<int> InsertarProductoAsync(Producto producto)
        {
            var parametros = new[]
            {
                new SqlParameter("@ProCodigo", producto.ProCodigo),
                new SqlParameter("@ProNombre", producto.ProNombre),
                new SqlParameter("@ProDescripcionCorta", producto.ProDescripcionCorta ?? (object)DBNull.Value),
                new SqlParameter("@ProDescripcion", producto.ProDescripción ?? (object)DBNull.Value),
                new SqlParameter("@ProPrecio", producto.ProPrecio),
                new SqlParameter("@ProStock", producto.ProStock),
                new SqlParameter("@ProPeso", producto.ProPeso ?? (object)DBNull.Value),
                new SqlParameter("@ProImagenUrl", producto.ProImagenUrl ?? (object)DBNull.Value),
                new SqlParameter("@ProActivo", producto.ProActivo),  
                new SqlParameter("@ProCategoriaId", producto.ProCategoriaId ?? (object)DBNull.Value),
                new SqlParameter("@ProMarcaId", producto.ProMarcaId ?? (object)DBNull.Value),
                new SqlParameter("@ProColeccionId", producto.ProColeccionId ?? (object)DBNull.Value),
                new SqlParameter("@ProGeneroId", producto.ProGeneroId ?? (object)DBNull.Value),
                new SqlParameter("@SubcategoriaId", producto.SubcategoriaId ?? (object)DBNull.Value)
            };

            return await _contexto.Database.ExecuteSqlRawAsync("EXEC Producto_insert @ProCodigo, @ProNombre, @ProDescripcionCorta, @ProDescripcion, @ProPrecio, @ProStock, @ProPeso, @ProImagenUrl, @ProActivo, @ProCategoriaId, @ProMarcaId, @ProColeccionId, @ProGeneroId, @SubcategoriaId", parametros);
        }

        // Actualizar un producto existente
        public async Task<int> ActualizarProductoAsync(Producto producto)
        {
            var parametros = new[]
            {
                new SqlParameter("@ProductoId", producto.ProductoId),
                new SqlParameter("@ProCodigo", producto.ProCodigo),
                new SqlParameter("@ProNombre", producto.ProNombre),
                new SqlParameter("@ProDescripcionCorta", producto.ProDescripcionCorta ?? (object)DBNull.Value),
                new SqlParameter("@ProDescripcion", producto.ProDescripción ?? (object)DBNull.Value),
                new SqlParameter("@ProPrecio", producto.ProPrecio),
                new SqlParameter("@ProStock", producto.ProStock),
                new SqlParameter("@ProPeso", producto.ProPeso ?? (object)DBNull.Value),
                new SqlParameter("@ProImagenUrl", producto.ProImagenUrl ?? (object)DBNull.Value),
                new SqlParameter("@ProActivo", producto.ProActivo),  // ProActivo ya no es nullable
                new SqlParameter("@ProCategoriaId", producto.ProCategoriaId ?? (object)DBNull.Value),
                new SqlParameter("@ProMarcaId", producto.ProMarcaId ?? (object)DBNull.Value),
                new SqlParameter("@ProColeccionId", producto.ProColeccionId ?? (object)DBNull.Value),
                new SqlParameter("@ProGeneroId", producto.ProGeneroId ?? (object)DBNull.Value),
                new SqlParameter("@SubcategoriaId", producto.SubcategoriaId ?? (object)DBNull.Value)
            };

            return await _contexto.Database.ExecuteSqlRawAsync("EXEC Producto_update @ProductoId, @ProCodigo, @ProNombre, @ProDescripcionCorta, @ProDescripcion, @ProPrecio, @ProStock, @ProPeso, @ProImagenUrl, @ProActivo, @ProCategoriaId, @ProMarcaId, @ProColeccionId, @ProGeneroId, @SubcategoriaId", parametros);
        }

        // Eliminar un producto
        public async Task<int> EliminarProductoAsync(int id)
        {
            var parametro = new SqlParameter("@ProductoId", id);
            return await _contexto.Database.ExecuteSqlRawAsync("EXEC Producto_delete @ProductoId", parametro);
        }

        // Obtener las tallas asociadas a un producto
        public async Task<List<Talla>> ObtenerTallasPorProductoIdAsync(int productoId)
        {
            return await _contexto.ProductoTallas
                .Where(pt => pt.ProductoId == productoId)
                .Include(pt => pt.Talla)
                .Select(pt => pt.Talla)
                .ToListAsync();
        }

    }
}
