using Ecommerce.BD.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.BD.Repositorios
{
    public class ColeccionRepositorio
    {
        private readonly EcommerceContext _contexto;

        public ColeccionRepositorio(EcommerceContext contexto)
        {
            _contexto = contexto;
        }

        // Obtener todas las colecciones
        public async Task<List<Coleccione>> ObtenerTodasLasColeccionesAsync()
        {
            return await _contexto.Colecciones
                .FromSqlRaw("EXEC Coleccion_list") // Ejecuta el procedimiento almacenado
                .ToListAsync();
        }

        // Obtener una colección por su ID
        public async Task<Coleccione> ObtenerColeccionPorIdAsync(int id)
        {
            var parametro = new SqlParameter("@ColeccionId", id);
            var colecciones = await _contexto.Colecciones
                .FromSqlRaw("EXEC Coleccion_listPorId @ColeccionId", parametro) // Ejecuta un procedimiento para obtener por ID (si lo tienes)
                .ToListAsync();
            return colecciones.FirstOrDefault();
        }

        // Insertar una nueva colección
        public async Task<int> InsertarColeccionAsync(Coleccione coleccion)
        {
            var parametros = new[]
            {
                new SqlParameter("@ColNombre", coleccion.ColNombre),
                new SqlParameter("@ColDescripcion", coleccion.ColDescripcion ?? (object)DBNull.Value),
                new SqlParameter("@ColImagenUrl", coleccion.ColImagenUrl ?? (object)DBNull.Value),
                new SqlParameter("@ColActivo", coleccion.ColActivo)
            };

            return await _contexto.Database.ExecuteSqlRawAsync(
                "EXEC Coleccion_insert @ColNombre, @ColDescripcion, @ColImagenUrl, @ColActivo",
                parametros);
        }

        // Actualizar una colección existente
        public async Task<int> ActualizarColeccionAsync(Coleccione coleccion)
        {
            var parametros = new[]
            {
                new SqlParameter("@ColeccionId", coleccion.ColeccionId),
                new SqlParameter("@ColNombre", coleccion.ColNombre),
                new SqlParameter("@ColDescripcion", coleccion.ColDescripcion ?? (object)DBNull.Value),
                new SqlParameter("@ColImagenUrl", coleccion.ColImagenUrl ?? (object)DBNull.Value),
                new SqlParameter("@ColActivo", coleccion.ColActivo)
            };

            return await _contexto.Database.ExecuteSqlRawAsync(
                "EXEC Coleccion_update @ColeccionId, @ColNombre, @ColDescripcion, @ColImagenUrl, @ColActivo",
                parametros);
        }

        // Eliminar una colección
        public async Task<int> EliminarColeccionAsync(int id)
        {
            var parametro = new SqlParameter("@ColeccionId", id);
            return await _contexto.Database.ExecuteSqlRawAsync("EXEC Coleccion_delete @ColeccionId", parametro);
        }
    }
}
