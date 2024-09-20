using Ecommerce.BD.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.BD.Repositorios
{
    public class ProductoPorGeneroRepositorio
    {
        private readonly EcommerceContext _contexto;

        public ProductoPorGeneroRepositorio(EcommerceContext contexto)
        {
            _contexto = contexto;
        }

        // Obtener productos por género (ej. mujeres)
        public async Task<List<Producto>> ObtenerProductosPorGeneroAsync(string nombreGenero)
        {
            return await _contexto.Productos
                                  .Include(p => p.ProGenero)  
                                  .Where(p => p.ProGenero.GenNombre.ToLower() == nombreGenero.ToLower() && p.ProActivo)
                                  .ToListAsync();
        }


    }
}
