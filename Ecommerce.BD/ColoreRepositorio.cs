using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ecommerce.BD.Models;
using Microsoft.Data.SqlClient;

namespace Ecommerce.BD.Repositorios
{
    public class ColoreRepositorio
    {
        private readonly EcommerceContext _contexto;
        public ColoreRepositorio(EcommerceContext contexto)
        {
            _contexto = contexto;
        }

        // Insertar un nuevo color
        public async Task<int> InsertarColorAsync(string nombre, string hexadecimal)
        {
            var parametros = new[]
            {
                new SqlParameter("@Col_Nombre", nombre),
                new SqlParameter("@Col_Hexadecimal", hexadecimal)
            };

            return await _contexto.Database.ExecuteSqlRawAsync("EXEC Color_insert @Col_Nombre, @Col_Hexadecimal", parametros);
        }



        // Actualizar un color existente
        public async Task<int> ActualizarColorAsync(int id, string nombre, string hexadecimal)
        {
            var parametros = new[]
            {
                new SqlParameter("@ColorId", id),
                new SqlParameter("@Col_Nombre", nombre),
                new SqlParameter("@Col_Hexadecimal", hexadecimal)
            };

            return await _contexto.Database.ExecuteSqlRawAsync("EXEC Color_update @ColorId, @Col_Nombre, @Col_Hexadecimal", parametros);
        }

        // Eliminar un color
        public async Task<int> EliminarColorAsync(int id)
        {
            var parametro = new SqlParameter("@ColorId", id);
            return await _contexto.Database.ExecuteSqlRawAsync("EXEC Color_delete @ColorId", parametro);
        }

        // Listar todos los colores
        public async Task<List<Colore>> ObtenerTodosLosColoresAsync()
        {
            return await _contexto.Colores.FromSqlRaw("EXEC Color_list").ToListAsync();
        }

        // Obtener un color por ID
        public async Task<Colore> ObtenerColorPorIdAsync(int id)
        {
            var parametro = new SqlParameter("@ColorId", id);

            // Ejecuta el procedimiento almacenado y luego realiza el filtrado en el cliente
            var color = await _contexto.Colores
                .FromSqlRaw("EXEC Color_listPorId @ColorId", parametro)
                .ToListAsync();  

            return color.FirstOrDefault(); 
        }
    }
}
