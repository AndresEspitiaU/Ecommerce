using Ecommerce.BD.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.BD.Repositorios
{
    public class CategoriaRepositorio
    {
        private readonly EcommerceContext _contexto;

        public CategoriaRepositorio(EcommerceContext contexto)
        {
            _contexto = contexto;
        }




        // Obtener todas las categorías
        public async Task<List<Categoria>> ObtenerTodasLasCategoriasAsync()
        {
            return await _contexto.Categorias.ToListAsync();  
        }

        // Obtener una categoría por ID
        public async Task<Categoria> ObtenerCategoriaPorIdAsync(int id)
        {
            var parametro = new SqlParameter("@CategoriaId", id);
            var categorias = await _contexto.Categorias.FromSqlRaw("EXEC Categoria_listPorId @CategoriaId", parametro).ToListAsync();
            return categorias.FirstOrDefault();
        }

        // Insertar una nueva categoría
        public async Task<int> InsertarCategoriaAsync(Categoria categoria)
        {
            var parametros = new[]
            {
                new SqlParameter("@CatNombre", categoria.CatNombre),
                new SqlParameter("@CatImagenUrl", categoria.CatImagenUrl ?? (object)DBNull.Value)
            };

            return await _contexto.Database.ExecuteSqlRawAsync("EXEC Categoria_insert @CatNombre, @CatImagenUrl", parametros);
        }

        // Actualizar una categoría existente
        public async Task<int> ActualizarCategoriaAsync(Categoria categoria)
        {
            var parametros = new[]
            {
                new SqlParameter("@CategoriaId", categoria.CategoriaId),
                new SqlParameter("@CatNombre", categoria.CatNombre),
                new SqlParameter("@CatImagenUrl", categoria.CatImagenUrl ?? (object)DBNull.Value)
            };

            return await _contexto.Database.ExecuteSqlRawAsync("EXEC Categoria_update @CategoriaId, @CatNombre, @CatImagenUrl", parametros);
        }

        // Eliminar una categoría
        public async Task<int> EliminarCategoriaAsync(int id)
        {
            var parametro = new SqlParameter("@CategoriaId", id);
            return await _contexto.Database.ExecuteSqlRawAsync("EXEC Categoria_delete @CategoriaId", parametro);
        }

    }
}
