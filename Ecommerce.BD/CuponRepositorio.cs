using Ecommerce.BD.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Ecommerce.BD.Repositorios
{
    public class CuponRepositorio
    {
        private readonly EcommerceContext _contexto;

        public CuponRepositorio(EcommerceContext contexto)
        {
            _contexto = contexto;
        }

        // Obtener todos los cupones
        public async Task<List<Cupone>> ObtenerTodosLosCuponesAsync()
        {
            return await _contexto.Cupones.FromSqlRaw("EXEC Cupon_list").ToListAsync();
        }

        // Obtener un cupon por ID
        public async Task<Cupone> ObtenerCuponPorIdAsync(int id)
        {
            var parametro = new SqlParameter("@CuponId", id);
            var cupones = await _contexto.Cupones.FromSqlRaw("EXEC Cupon_listPorId @CuponId", parametro).ToListAsync();
            return cupones.FirstOrDefault();
        }

        // Insertar un nuevo cupon
        public async Task<int> InsertarCuponAsync(Cupone cupon)
        {
            var parametros = new[]
            {
                new SqlParameter("@CupCodigo", cupon.CupCodigo),
                new SqlParameter("@CupDescripcion", cupon.CupDescripcion ?? (object)DBNull.Value),
                new SqlParameter("@CupPorcentajeDescuento", cupon.CupPorcentajeDescuento ?? (object)DBNull.Value),
                new SqlParameter("@CupMontoDescuento", cupon.CupMontoDescuento ?? (object)DBNull.Value),
                new SqlParameter("@CupFechaInicio", cupon.CupFechaInicio ?? (object)DBNull.Value),
                new SqlParameter("@CupFechaExpiracion", cupon.CupFechaExpiracion ?? (object)DBNull.Value),
                new SqlParameter("@CupActivo", cupon.CupActivo)
            };

            return await _contexto.Database.ExecuteSqlRawAsync("EXEC Cupon_insert @CupCodigo, @CupDescripcion, @CupPorcentajeDescuento, @CupMontoDescuento, @CupFechaInicio, @CupFechaExpiracion, @CupActivo", parametros);
        }

        // Actualizar un cupon existente
        public async Task<int> ActualizarCuponAsync(Cupone cupon)
        {
            var parametros = new[]
            {
                new SqlParameter("@CuponId", cupon.CuponId),
                new SqlParameter("@CupCodigo", cupon.CupCodigo),
                new SqlParameter("@CupDescripcion", cupon.CupDescripcion ?? (object)DBNull.Value),
                new SqlParameter("@CupPorcentajeDescuento", cupon.CupPorcentajeDescuento ?? (object)DBNull.Value),
                new SqlParameter("@CupMontoDescuento", cupon.CupMontoDescuento ?? (object)DBNull.Value),
                new SqlParameter("@CupFechaInicio", cupon.CupFechaInicio ?? (object)DBNull.Value),
                new SqlParameter("@CupFechaExpiracion", cupon.CupFechaExpiracion ?? (object)DBNull.Value),
                new SqlParameter("@CupActivo", cupon.CupActivo)
            };

            return await _contexto.Database.ExecuteSqlRawAsync("EXEC Cupon_update @CuponId, @CupCodigo, @CupDescripcion, @CupPorcentajeDescuento, @CupMontoDescuento, @CupFechaInicio, @CupFechaExpiracion, @CupActivo", parametros);
        }

        // Eliminar un cupon
        public async Task<int> EliminarCuponAsync(int id)
        {
            var parametro = new SqlParameter("@CuponId", id);
            return await _contexto.Database.ExecuteSqlRawAsync("EXEC Cupon_delete @CuponId", parametro);
        }
    }
}
