using Ecommerce.BD.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.BD.Repositorios
{
    public class SubcategoriaRepositorio
    {
        private readonly EcommerceContext _contexto;

        public SubcategoriaRepositorio(EcommerceContext contexto)
        {
            _contexto = contexto;
        }

        // Obtener todas las subcategorías (incluyendo la categoría principal)
        public async Task<List<Subcategoria>> ObtenerTodasLasSubcategoriasAsync()
        {
            return await _contexto.Subcategorias
                .Include(s => s.Categoria) // Incluir la categoría principal
                .ToListAsync(); // No se necesita FromSqlRaw aquí, ya que estamos usando una consulta LINQ.
        }

        // Obtener una subcategoría por ID (incluyendo la categoría principal)
        public async Task<Subcategoria> ObtenerSubcategoriaPorIdAsync(int id)
        {
            return await _contexto.Subcategorias
                .Include(s => s.Categoria) // Incluir la categoría principal
                .FirstOrDefaultAsync(s => s.SubcategoriaId == id); // Se utiliza FirstOrDefaultAsync en lugar de FromSqlRaw.
        }

        // Insertar una nueva subcategoría
        public async Task<int> InsertarSubcategoriaAsync(Subcategoria subcategoria)
        {
            await _contexto.Subcategorias.AddAsync(subcategoria);
            return await _contexto.SaveChangesAsync();
        }

        // Actualizar una subcategoría existente
        public async Task<int> ActualizarSubcategoriaAsync(Subcategoria subcategoria)
        {
            _contexto.Subcategorias.Update(subcategoria);
            return await _contexto.SaveChangesAsync();
        }

        // Eliminar una subcategoría
        public async Task<int> EliminarSubcategoriaAsync(int id)
        {
            var parametro = new SqlParameter("@SubcategoriaId", id);
            return await _contexto.Database.ExecuteSqlRawAsync("EXEC Subcategoria_delete @SubcategoriaId", parametro);
        }

    }
}
