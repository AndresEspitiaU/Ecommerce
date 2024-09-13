using Ecommerce.BD.Models;
using Ecommerce.BD.Repositorios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.PRC.Servicios
{
    public class PromocionProductoServicio
    {
        private readonly PromocionProductoRepositorio _repositorio;

        public PromocionProductoServicio(PromocionProductoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        // Obtener todos los productos asociados a una promoción
        public async Task<List<PromocionProducto>> ObtenerProductosPorPromocionIdAsync(int promocionId)
        {
            return await _repositorio.ObtenerProductosPorPromocionIdAsync(promocionId);
        }

        // Obtener una relación Promoción-Producto por su ID
        public async Task<PromocionProducto> ObtenerPromocionProductoPorIdAsync(int promocionProductoId)
        {
            return await _repositorio.ObtenerPromocionProductoPorIdAsync(promocionProductoId);
        }

        // Insertar una nueva relación Promoción-Producto
        public async Task<int> InsertarPromocionProductoAsync(PromocionProducto promocionProducto)
        {
            return await _repositorio.InsertarPromocionProductoAsync(promocionProducto);
        }

        // Actualizar una relación Promoción-Producto existente
        public async Task<int> ActualizarPromocionProductoAsync(PromocionProducto promocionProducto)
        {
            return await _repositorio.ActualizarPromocionProductoAsync(promocionProducto);
        }

        // Eliminar una relación Promoción-Producto
        public async Task<int> EliminarPromocionProductoAsync(int promocionProductoId)
        {
            return await _repositorio.EliminarPromocionProductoAsync(promocionProductoId);
        }
    }
}
