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

        // Obtener todos los productos (opcionalmente filtrado por categoría o subcategoría)
        public async Task<List<Producto>> ObtenerTodosLosProductosAsync(int? categoriaId = null, int? subcategoriaId = null)
        {
            var parametros = new List<SqlParameter>();

            // Parámetro para categoría
            var parametroCategoria = new SqlParameter("@ProCategoriaId", categoriaId ?? (object)DBNull.Value);
            parametros.Add(parametroCategoria);

            // Parámetro para subcategoría
            var parametroSubcategoria = new SqlParameter("@SubcategoriaId", subcategoriaId ?? (object)DBNull.Value);
            parametros.Add(parametroSubcategoria);

            return await _contexto.Productos
                .FromSqlRaw("EXEC Producto_list @ProCategoriaId, @SubcategoriaId", parametros.ToArray())
                .ToListAsync();
        }

        // Obtener una imagen por su ID
        public async Task<ProductoImagene> ObtenerImagenPorIdAsync(int imagenId)
        {
            var parametro = new SqlParameter("@ImagenId", imagenId);
            var imagen = await _contexto.ProductoImagenes
                .FromSqlRaw("EXEC ProductoImagen_listPorId @ImagenId", parametro)  // Procedimiento almacenado para obtener una imagen por su ID
                .FirstOrDefaultAsync();

            return imagen;
        }


        // Obtener producto por ID
        public async Task<Producto> ObtenerProductoPorIdAsync(int id)
        {
            var parametro = new SqlParameter("@ProductoId", id);

            var productos = await _contexto.Productos
                .FromSqlRaw("EXEC Producto_listPorId @ProductoId", parametro)
                .ToListAsync();

            var producto = productos.FirstOrDefault();

            if (producto != null)
            {
                // Cargar las referencias (opcional, si ya están incluidas no es necesario)
                await _contexto.Entry(producto).Reference(p => p.ProCategoria).LoadAsync();
                await _contexto.Entry(producto).Reference(p => p.Subcategoria).LoadAsync();
                await _contexto.Entry(producto).Reference(p => p.ProMarca).LoadAsync();
                await _contexto.Entry(producto).Reference(p => p.ProColeccion).LoadAsync();
                await _contexto.Entry(producto).Reference(p => p.ProGenero).LoadAsync();
            }

            return producto;
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
    }
}
