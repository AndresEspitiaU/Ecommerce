using Ecommerce.BD.Models;
using Ecommerce.BD.Repositorios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.PRC.Servicios
{
    public class ProductoImagenServicio
    {
        private readonly ProductoImagenRepositorio _repositorio;

        public ProductoImagenServicio(ProductoImagenRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        // Obtener todas las imágenes de un producto
        public async Task<List<ProductoImagene>> ObtenerImagenesPorProductoIdAsync(int productoId)
        {
            return await _repositorio.ObtenerImagenesPorProductoIdAsync(productoId);
        }

        // Obtener una imagen por su ID
        public async Task<ProductoImagene> ObtenerImagenPorIdAsync(int imagenId)
        {
            return await _repositorio.ObtenerImagenPorIdAsync(imagenId);
        }


        // Insertar una nueva imagen de producto
        public async Task<int> InsertarImagenAsync(ProductoImagene imagen)
        {
            return await _repositorio.InsertarImagenAsync(imagen);
        }

        // Actualizar una imagen existente
        public async Task<int> ActualizarImagenAsync(ProductoImagene imagen)
        {
            return await _repositorio.ActualizarImagenAsync(imagen);
        }

        // Eliminar una imagen
        public async Task<int> EliminarImagenAsync(int imagenId)
        {
            return await _repositorio.EliminarImagenAsync(imagenId);
        }
    }
}
