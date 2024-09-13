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

        // Obtener todos los productos (opcionalmente filtrado por categoría o subcategoría)
        public async Task<List<Producto>> ObtenerTodosLosProductosAsync(int? categoriaId = null, int? subcategoriaId = null)
        {
            return await _productoRepositorio.ObtenerTodosLosProductosAsync(categoriaId, subcategoriaId);
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
    }
}
