using Ecommerce.BD.Models;
using Ecommerce.BD.Repositorios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.PRC.Servicios
{
    public class ProductoPorGeneroServicio
    {
        private readonly ProductoPorGeneroRepositorio _productoPorGeneroRepositorio;

        public ProductoPorGeneroServicio(ProductoPorGeneroRepositorio productoPorGeneroRepositorio)
        {
            _productoPorGeneroRepositorio = productoPorGeneroRepositorio;
        }

        // Obtener productos para un género específico
        public async Task<List<Producto>> ObtenerProductosPorGeneroAsync(string nombreGenero)
        {
            return await _productoPorGeneroRepositorio.ObtenerProductosPorGeneroAsync(nombreGenero);
        }
    }
}
