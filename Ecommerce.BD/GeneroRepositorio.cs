using Ecommerce.BD.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.BD.Repositorios
{
    public class GeneroRepositorio
    {
        private readonly EcommerceContext _contexto;

        public GeneroRepositorio(EcommerceContext contexto)
        {
            _contexto = contexto;
        }

        // Obtener todos los géneros
        public async Task<List<Genero>> ObtenerTodosLosGenerosAsync()
        {
            return await _contexto.Generos.ToListAsync();
        }

        // Obtener un género por ID
        public async Task<Genero> ObtenerGeneroPorIdAsync(int id)
        {
            return await _contexto.Generos.FirstOrDefaultAsync(g => g.GeneroId == id);
        }

        // Insertar un nuevo género
        public async Task<int> InsertarGeneroAsync(Genero genero)
        {
            _contexto.Generos.Add(genero);
            return await _contexto.SaveChangesAsync();
        }

        // Actualizar un género existente
        public async Task<int> ActualizarGeneroAsync(Genero genero)
        {
            _contexto.Generos.Update(genero);
            return await _contexto.SaveChangesAsync();
        }

        // Eliminar un género
        public async Task<int> EliminarGeneroAsync(int id)
        {
            var parametro = new SqlParameter("@GeneroId", id);
            try
            {
                return await _contexto.Database.ExecuteSqlRawAsync("EXEC Genero_delete @GeneroId", parametro);
            }
            catch (Exception ex)
            {
                // Capturar cualquier excepción y devolver un error para que lo manejes
                Console.WriteLine(ex.Message);
                return 0; // Retornar 0 en caso de fallo
            }
        }


    }
}
