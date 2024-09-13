using Ecommerce.BD.Models;
using Ecommerce.BD.Repositorios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.PRC.Servicios
{
    public class ProductoDescuentoServicio
    {
        private readonly ProductoDescuentoRepositorio _productoDescuentoRepositorio;

        public ProductoDescuentoServicio(ProductoDescuentoRepositorio productoDescuentoRepositorio)
        {
            _productoDescuentoRepositorio = productoDescuentoRepositorio;
        }

        // Obtener todos los descuentos por producto
        public async Task<List<ProductoDescuento>> ObtenerTodosLosProductoDescuentosAsync()
        {
            return await _productoDescuentoRepositorio.ObtenerTodosLosProductoDescuentosAsync();
        }

        // Obtener un descuento por producto por ID
        public async Task<ProductoDescuento> ObtenerProductoDescuentoPorIdAsync(int id)
        {
            return await _productoDescuentoRepositorio.ObtenerProductoDescuentoPorIdAsync(id);
        }

        // Insertar un nuevo descuento para un producto
        public async Task<int> InsertarProductoDescuentoAsync(ProductoDescuento productoDescuento)
        {
            return await _productoDescuentoRepositorio.InsertarProductoDescuentoAsync(productoDescuento);
        }

        // Actualizar un descuento para un producto
        public async Task<int> ActualizarProductoDescuentoAsync(ProductoDescuento productoDescuento)
        {
            return await _productoDescuentoRepositorio.ActualizarProductoDescuentoAsync(productoDescuento);
        }

        // Eliminar un descuento por producto
        public async Task<int> EliminarProductoDescuentoAsync(int id)
        {
            return await _productoDescuentoRepositorio.EliminarProductoDescuentoAsync(id);
        }
    }
}
