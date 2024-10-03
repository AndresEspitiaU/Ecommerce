using Ecommerce.BD.Models;
using Ecommerce.BD.Repositorios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.PRC.Servicios
{
    public class ProductoServicio
    {
        private readonly ProductoRepositorio _productoRepositorio;

        public ProductoServicio(ProductoRepositorio productoRepositorio)
        {
            _productoRepositorio = productoRepositorio;
        }

        public async Task<int> ContarProductosPorCategoriaAsync(int categoriaId)
        {
            return await _productoRepositorio.ContarProductosPorCategoriaAsync(categoriaId);
        }

        
        /// <summary>
        /// Devuelve una lista de todos los productos
        /// </summary>
        /// <param name="categoriaId"></param>
        /// <param name="subcategoriaId"></param>
        /// <returns></returns>
        public async Task<List<Producto>> ObtenerTodosLosProductosAsync(int? categoriaId = null, int? subcategoriaId = null)
        {
            return await _productoRepositorio.ObtenerTodosLosProductosAsync(categoriaId, subcategoriaId);
        }

        /// <summary>
        /// Devuelve una lista de productos activos
        /// </summary>
        /// <param name="categoriaId"></param>
        /// <param name="subcategoriaId"></param>
        /// <returns></returns>
        public async Task<List<Producto>> ObtenerProductosActivosAsync(int? categoriaId = null, int? subcategoriaId = null)
        {
            return await _productoRepositorio.ObtenerProductosActivosAsync(categoriaId, subcategoriaId);
        }

       

        public async Task<List<Producto>> ObtenerProductosFiltradosAsync(List<int> categoriaIds, List<int> marcaIds, decimal? precioMin, decimal? precioMax)
        {
            return await _productoRepositorio.ObtenerProductosFiltradosAsync(categoriaIds, marcaIds, precioMin, precioMax);
        }

        // Obtener producto por ID
        public async Task<Producto> ObtenerProductoPorIdAsync(int id)
        {
            return await _productoRepositorio.ObtenerProductoPorIdAsync(id);
        }

        // Insertar un nuevo producto
        public async Task<int> CrearProductoAsync(Producto producto)
        {
            return await _productoRepositorio.InsertarProductoAsync(producto);
        }

        // Actualizar un producto existente
        public async Task<int> ActualizarProductoAsync(Producto producto)
        {
            return await _productoRepositorio.ActualizarProductoAsync(producto);
        }

        // Eliminar un producto
        public async Task<int> EliminarProductoAsync(int id)
        {
            return await _productoRepositorio.EliminarProductoAsync(id);
        }

        public async Task<List<Talla>> ObtenerTallasPorProductoIdAsync(int productoId)
        {
            return await _productoRepositorio.ObtenerTallasPorProductoIdAsync(productoId);
        }

    }
}
