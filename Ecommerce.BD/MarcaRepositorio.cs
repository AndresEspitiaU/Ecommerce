using Ecommerce.BD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.BD.Repositorios
{
    public class MarcaRepositorio
    {
        private readonly EcommerceContext _contexto;

        public MarcaRepositorio(EcommerceContext contexto)
        {
            _contexto = contexto;
        }

        // Obtener todas las marcas con el conteo de productos asociados
        public async Task<List<Marca>> ObtenerTodasLasMarcasAsync()
        {
            return await _contexto.Marcas
                .FromSqlRaw("EXEC Marca_list")
                .ToListAsync();
        }

        // Obtener una marca por ID con el conteo de productos asociados
        public async Task<Marca> ObtenerMarcaPorIdAsync(int id)
        {
            var parametro = new SqlParameter("@MarcaId", id);
            var marcas = await _contexto.Marcas
                .FromSqlRaw("EXEC Marca_listPorId @MarcaId", parametro)
                .ToListAsync();
            return marcas.FirstOrDefault();
        }

        // Insertar una nueva marca
        public async Task<int> InsertarMarcaAsync(Marca marca)
        {
            var parametros = new[]
            {
                new SqlParameter("@MarNombre", marca.MarNombre)
            };

            return await _contexto.Database.ExecuteSqlRawAsync("EXEC Marca_insert @MarNombre", parametros);
        }

        // Actualizar una marca existente
        public async Task<int> ActualizarMarcaAsync(Marca marca)
        {
            var parametros = new[]
            {
                new SqlParameter("@MarcaId", marca.MarcaId),
                new SqlParameter("@MarNombre", marca.MarNombre)
            };

            return await _contexto.Database.ExecuteSqlRawAsync("EXEC Marca_update @MarcaId, @MarNombre", parametros);
        }

        // Eliminar una marca
        public async Task<int> EliminarMarcaAsync(int id)
        {
            var parametro = new SqlParameter("@MarcaId", id);
            return await _contexto.Database.ExecuteSqlRawAsync("EXEC Marca_delete @MarcaId", parametro);
        }
    }
}
