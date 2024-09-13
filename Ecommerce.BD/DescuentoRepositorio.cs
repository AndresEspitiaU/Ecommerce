using Ecommerce.BD.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Ecommerce.BD.Repositorios
{
    public class DescuentoRepositorio
    {
        private readonly EcommerceContext _contexto;

        public DescuentoRepositorio(EcommerceContext contexto)
        {
            _contexto = contexto;
        }

        // Obtener todos los descuentos
        public async Task<List<Descuento>> ObtenerTodosLosDescuentosAsync()
        {
            return await _contexto.Descuentos.FromSqlRaw("EXEC Descuento_list").ToListAsync();
        }

        // Obtener un descuento por ID
        public async Task<Descuento> ObtenerDescuentoPorIdAsync(int id)
        {
            var parametro = new SqlParameter("@DescuentoId", id);
            var descuentos = await _contexto.Descuentos.FromSqlRaw("EXEC Descuento_listPorId @DescuentoId", parametro).ToListAsync();
            return descuentos.FirstOrDefault();
        }

        // Insertar un nuevo descuento
        public async Task<int> InsertarDescuentoAsync(Descuento descuento)
        {
            var parametros = new[]
            {
                new SqlParameter("@DesNombre", descuento.DesNombre),
                new SqlParameter("@DesDescripcion", descuento.DesDescripcion ?? (object)DBNull.Value),
                new SqlParameter("@DesPorcentaje", descuento.DesPorcentaje),
                new SqlParameter("@DesActivo", descuento.DesActivo)
            };

            return await _contexto.Database.ExecuteSqlRawAsync("EXEC Descuento_insert @DesNombre, @DesDescripcion, @DesPorcentaje, @DesActivo", parametros);
        }

        // Actualizar un descuento existente
        public async Task<int> ActualizarDescuentoAsync(Descuento descuento)
        {
            var parametros = new[]
            {
                new SqlParameter("@DescuentoId", descuento.DescuentoId),
                new SqlParameter("@DesNombre", descuento.DesNombre),
                new SqlParameter("@DesDescripcion", descuento.DesDescripcion ?? (object)DBNull.Value),
                new SqlParameter("@DesPorcentaje", descuento.DesPorcentaje),
                new SqlParameter("@DesActivo", descuento.DesActivo)
            };

            return await _contexto.Database.ExecuteSqlRawAsync("EXEC Descuento_update @DescuentoId, @DesNombre, @DesDescripcion, @DesPorcentaje, @DesActivo", parametros);
        }

        // Eliminar un descuento
        public async Task<int> EliminarDescuentoAsync(int id)
        {
            var parametro = new SqlParameter("@DescuentoId", id);
            return await _contexto.Database.ExecuteSqlRawAsync("EXEC Descuento_delete @DescuentoId", parametro);
        }
    }
}
