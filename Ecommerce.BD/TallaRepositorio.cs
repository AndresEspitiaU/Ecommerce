using Ecommerce.BD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.BD.Repositorios
{
    public class TallaRepositorio
    {
        private readonly EcommerceContext _contexto;

        public TallaRepositorio(EcommerceContext contexto)
        {
            _contexto = contexto;
        }

        // Obtener todas las tallas
        public async Task<List<Talla>> ObtenerTodasLasTallasAsync()
        {
            return await _contexto.Tallas.FromSqlRaw("EXEC Talla_list").ToListAsync();
        }

        // Obtener una talla por ID
        public async Task<Talla> ObtenerTallaPorIdAsync(int id)
        {
            var parametro = new SqlParameter("@TallaId", id);
            var tallas = await _contexto.Tallas.FromSqlRaw("EXEC Talla_listPorId @TallaId", parametro).ToListAsync();
            return tallas.FirstOrDefault();
        }

        // Insertar una nueva talla
        public async Task<int> InsertarTallaAsync(Talla talla)
        {
            var parametros = new[]
            {
                new SqlParameter("@Tal_Nombre", talla.TalNombre),
                new SqlParameter("@Tal_OrdenVisualizacion", talla.TalOrdenVisualizacion),
                new SqlParameter("@Tal_Cadera", talla.TalCadera ?? (object)DBNull.Value),
                new SqlParameter("@Tal_Categoria", talla.TalCategoria ?? (object)DBNull.Value),
                new SqlParameter("@Tal_Cintura", talla.TalCintura ?? (object)DBNull.Value),
                new SqlParameter("@Tal_Colombia", talla.TalColombia ?? (object)DBNull.Value),
                new SqlParameter("@Tal_Cuello", talla.TalCuello ?? (object)DBNull.Value),
                new SqlParameter("@Tal_Descripcion", talla.TalDescripcion ?? (object)DBNull.Value),
                new SqlParameter("@Tal_EU", talla.TalEU ?? (object)DBNull.Value),
                new SqlParameter("@Tal_Largo", talla.TalLargo ?? (object)DBNull.Value),
                new SqlParameter("@Tal_LongitudManga", talla.TalLongitudManga ?? (object)DBNull.Value),
                new SqlParameter("@Tal_Pecho", talla.TalPecho ?? (object)DBNull.Value),
                new SqlParameter("@Tal_US", talla.TalUS ?? (object)DBNull.Value)
            };

            return await _contexto.Database.ExecuteSqlRawAsync("EXEC Talla_insert @Tal_Nombre, @Tal_OrdenVisualizacion, @Tal_Cadera, @Tal_Categoria, @Tal_Cintura, @Tal_Colombia, @Tal_Cuello, @Tal_Descripcion, @Tal_EU, @Tal_Largo, @Tal_LongitudManga, @Tal_Pecho, @Tal_US", parametros);
        }

        // Actualizar una talla existente
        public async Task<int> ActualizarTallaAsync(Talla talla)
        {
            var parametros = new[]
            {
                new SqlParameter("@TallaId", talla.TallaId),
                new SqlParameter("@Tal_Nombre", talla.TalNombre),
                new SqlParameter("@Tal_OrdenVisualizacion", talla.TalOrdenVisualizacion),
                new SqlParameter("@Tal_Cadera", talla.TalCadera ?? (object)DBNull.Value),
                new SqlParameter("@Tal_Categoria", talla.TalCategoria ?? (object)DBNull.Value),
                new SqlParameter("@Tal_Cintura", talla.TalCintura ?? (object)DBNull.Value),
                new SqlParameter("@Tal_Colombia", talla.TalColombia ?? (object)DBNull.Value),
                new SqlParameter("@Tal_Cuello", talla.TalCuello ?? (object)DBNull.Value),
                new SqlParameter("@Tal_Descripcion", talla.TalDescripcion ?? (object)DBNull.Value),
                new SqlParameter("@Tal_EU", talla.TalEU ?? (object)DBNull.Value),
                new SqlParameter("@Tal_Largo", talla.TalLargo ?? (object)DBNull.Value),
                new SqlParameter("@Tal_LongitudManga", talla.TalLongitudManga ?? (object)DBNull.Value),
                new SqlParameter("@Tal_Pecho", talla.TalPecho ?? (object)DBNull.Value),
                new SqlParameter("@Tal_US", talla.TalUS ?? (object)DBNull.Value)
            };

            return await _contexto.Database.ExecuteSqlRawAsync("EXEC Talla_update @TallaId, @Tal_Nombre, @Tal_OrdenVisualizacion, @Tal_Cadera, @Tal_Categoria, @Tal_Cintura, @Tal_Colombia, @Tal_Cuello, @Tal_Descripcion, @Tal_EU, @Tal_Largo, @Tal_LongitudManga, @Tal_Pecho, @Tal_US", parametros);
        }

        // Eliminar una talla
        public async Task<int> EliminarTallaAsync(int id)
        {
            var parametro = new SqlParameter("@TallaId", id);
            return await _contexto.Database.ExecuteSqlRawAsync("EXEC Talla_delete @TallaId", parametro);
        }
    }
}
