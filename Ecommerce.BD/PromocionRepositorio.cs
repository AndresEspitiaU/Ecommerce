using Ecommerce.BD.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace Ecommerce.BD.Repositorios
{
    public class PromocionRepositorio
    {
        private readonly EcommerceContext _contexto;

        public PromocionRepositorio(EcommerceContext contexto)
        {
            _contexto = contexto;
        }

        // Obtener todas las promociones
        public async Task<List<Promocione>> ObtenerTodasLasPromocionesAsync()
        {
            return await _contexto.Promociones.FromSqlRaw("EXEC Promocion_list").ToListAsync();
        }

        // Obtener una promoción por ID
        public async Task<Promocione> ObtenerPromocionPorIdAsync(int id)
        {
            var parametro = new SqlParameter("@PromocionId", id);
            var promociones = await _contexto.Promociones.FromSqlRaw("EXEC Promocion_listPorId @PromocionId", parametro).ToListAsync();
            return promociones.FirstOrDefault();
        }

        // Insertar una nueva promoción
        public async Task<int> InsertarPromocionAsync(Promocione promocion)
        {
            var parametros = new[]
            {
                new SqlParameter("@Prom_Nombre", promocion.PromNombre),
                new SqlParameter("@Prom_Descripcion", promocion.PromDescripcion ?? (object)DBNull.Value),
                new SqlParameter("@Prom_FechaInicio", promocion.PromFechaInicio),
                new SqlParameter("@Prom_FechaFin", promocion.PromFechaFin),
                new SqlParameter("@Prom_DescuentoPorcentaje", promocion.PromDescuentoPorcentaje ?? (object)DBNull.Value),
                new SqlParameter("@Prom_DescuentoMonto", promocion.PromDescuentoMonto ?? (object)DBNull.Value),
                new SqlParameter("@Prom_Activo", promocion.PromActivo)
            };

            return await _contexto.Database.ExecuteSqlRawAsync("EXEC Promocion_insert @Prom_Nombre, @Prom_Descripcion, @Prom_FechaInicio, @Prom_FechaFin, @Prom_DescuentoPorcentaje, @Prom_DescuentoMonto, @Prom_Activo", parametros);
        }

        // Actualizar una promoción existente
        public async Task<int> ActualizarPromocionAsync(Promocione promocion)
        {
            var parametros = new[]
            {
                new SqlParameter("@PromocionId", promocion.PromocionId),
                new SqlParameter("@Prom_Nombre", promocion.PromNombre),
                new SqlParameter("@Prom_Descripcion", promocion.PromDescripcion ?? (object)DBNull.Value),
                new SqlParameter("@Prom_FechaInicio", promocion.PromFechaInicio),
                new SqlParameter("@Prom_FechaFin", promocion.PromFechaFin),
                new SqlParameter("@Prom_DescuentoPorcentaje", promocion.PromDescuentoPorcentaje ?? (object)DBNull.Value),
                new SqlParameter("@Prom_DescuentoMonto", promocion.PromDescuentoMonto ?? (object)DBNull.Value),
                new SqlParameter("@Prom_Activo", promocion.PromActivo)
            };

            return await _contexto.Database.ExecuteSqlRawAsync("EXEC Promocion_update @PromocionId, @Prom_Nombre, @Prom_Descripcion, @Prom_FechaInicio, @Prom_FechaFin, @Prom_DescuentoPorcentaje, @Prom_DescuentoMonto, @Prom_Activo", parametros);
        }

        // Eliminar una promoción
        public async Task<int> EliminarPromocionAsync(int id)
        {
            var parametro = new SqlParameter("@PromocionId", id);
            return await _contexto.Database.ExecuteSqlRawAsync("EXEC Promocion_delete @PromocionId", parametro);
        }
    }
}
