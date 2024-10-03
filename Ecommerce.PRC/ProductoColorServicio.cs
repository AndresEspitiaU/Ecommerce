using Ecommerce.BD.Models;
using Ecommerce.BD.Repositorios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.PRC.Servicios
{
    public class ProductoColorServicio
    {
        private readonly ProductoColorRepositorio _productoColorRepositorio;

        public ProductoColorServicio(ProductoColorRepositorio productoColorRepositorio)
        {
            _productoColorRepositorio = productoColorRepositorio;
        }

        // Insertar un nuevo color para un producto
        public async Task InsertarProductoColorAsync(int productoId, int colorId)
        {
            if (productoId <= 0 || colorId <= 0)
                throw new ArgumentException("ID del producto o color inválido.");

            await _productoColorRepositorio.InsertarProductoColorAsync(productoId, colorId);
        }


        public async Task<List<Producto>> ObtenerTodosLosProductosConColoresAsync()
            {
                try
                {
                    Console.WriteLine("Servicio: Obteniendo todos los productos con colores");
                    var productos = await _productoColorRepositorio.ObtenerTodosLosProductosConColoresAsync();
                    Console.WriteLine($"Servicio: Se obtuvieron {productos.Count} productos con sus colores asociados");
                    return productos;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error en el servicio al obtener productos con colores: {ex.Message}");
                    return new List<Producto>();
                }
            }



        // Actualizar los colores asociados a un producto  
        public async Task ActualizarProductoColoresAsync(int productoId, List<int> colorIds)
        {
            if (productoId <= 0 || colorIds == null || colorIds.Count == 0)
                throw new ArgumentException("ID del producto o lista de colores inválidos.");

            // Convertir la lista de IDs en un string CSV (ej: "1,2,3")
            string colorIdsCsv = string.Join(",", colorIds);
            await _productoColorRepositorio.ActualizarProductoColoresAsync(productoId, colorIdsCsv);
        }

       

        // Obtener los colores asociados a un producto
        public async Task<List<Color>> ObtenerColoresPorProductoAsync(int productoId)
        {
            if (productoId <= 0)
                throw new ArgumentException("ID del producto inválido.");

            Console.WriteLine($"Servicio: Obteniendo colores para el producto ID: {productoId}");
            var colores = await _productoColorRepositorio.ObtenerColoresPorProductoAsync(productoId);
            Console.WriteLine($"Servicio: Se obtuvieron {colores.Count} colores para el producto ID: {productoId}");
            return colores;
        }



        // Eliminar todos los colores asociados a un producto
        public async Task EliminarProductoColorAsync(int productoId, int colorId)
        {
            if (productoId <= 0 || colorId <= 0)
                throw new ArgumentException("ID del producto o color inválido.");

            await _productoColorRepositorio.EliminarProductoColorAsync(productoId, colorId);
        }

    }
}
