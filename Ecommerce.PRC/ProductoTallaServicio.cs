using Ecommerce.BD.Models;
using Ecommerce.BD.Repositorios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.PRC.Servicios
{
    public class ProductoTallaServicio
    {
        private readonly ProductoTallaRepositorio _productoTallaRepositorio;

        public ProductoTallaServicio(ProductoTallaRepositorio productoTallaRepositorio)
        {
            _productoTallaRepositorio = productoTallaRepositorio;
        }

        // Obtener todas las relaciones de Producto con Talla
        public async Task<List<ProductoTalla>> ObtenerTodosLosProductoTallasAsync()
        {
            return await _productoTallaRepositorio.ObtenerTodosLosProductoTallasAsync();
        }

        // Obtener ProductoTalla por ID
        public async Task<ProductoTalla> ObtenerProductoTallaPorIdAsync(int id)
        {
            return await _productoTallaRepositorio.ObtenerProductoTallaPorIdAsync(id);
        }

        // Crear un nuevo ProductoTalla
        public async Task<int> CrearProductoTallaAsync(ProductoTalla productoTalla)
        {
            return await _productoTallaRepositorio.CrearProductoTallaAsync(productoTalla);
        }

        // Actualizar un ProductoTalla existente
        public async Task<int> ActualizarProductoTallaAsync(ProductoTalla productoTalla)
        {
            return await _productoTallaRepositorio.ActualizarProductoTallaAsync(productoTalla);
        }

        // Servicio: Eliminar un ProductoTalla
        public async Task<int> EliminarProductoTallaAsync(int id)
        {
            if (id <= 0)
            {
                throw new System.ArgumentException("El ID del ProductoTalla no es válido");
            }

            return await _productoTallaRepositorio.EliminarProductoTallaAsync(id);
        }



    }
}
