using Ecommerce.BD.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.BD.Repositorios
{
    public class BannerRepositorio
    {
        private readonly EcommerceContext _contexto;

        public BannerRepositorio(EcommerceContext contexto)
        {
            _contexto = contexto;
        }

        // Listar todos los banners
        public async Task<List<Banner>> ObtenerTodosLosBannersAsync()
        {
            return await _contexto.Banners.FromSqlRaw("EXEC Banner_List").ToListAsync();
        }

        public async Task<List<Banner>> ObtenerBannersActivosAsync()
        {
            return await _contexto.Banners.Where(b => b.Activo).ToListAsync();
        }


        // Obtener un banner por ID
        public async Task<Banner> ObtenerBannerPorIdAsync(int bannerId)
        {
            var parametro = new SqlParameter("@BannerId", bannerId);
            var banners = await _contexto.Banners.FromSqlRaw("EXEC Banner_GetById @BannerId", parametro).ToListAsync();
            return banners.FirstOrDefault();
        }

        // Insertar un nuevo banner
        public async Task<int> InsertarBannerAsync(Banner banner)
        {
            var parametros = new[]
            {
                new SqlParameter("@Nombre", banner.Nombre),
                new SqlParameter("@Imagen", banner.Imagen),
                new SqlParameter("@Activo", banner.Activo)
            };

            return await _contexto.Database.ExecuteSqlRawAsync("EXEC Banner_Insert @Nombre, @Imagen, @Activo", parametros);
        }

        // Actualizar un banner existente
        public async Task<int> ActualizarBannerAsync(Banner banner)
        {
            var parametros = new[]
            {
                new SqlParameter("@BannerId", banner.BannerId),
                new SqlParameter("@Nombre", banner.Nombre),
                new SqlParameter("@Imagen", banner.Imagen),
                new SqlParameter("@Activo", banner.Activo)
            };

            return await _contexto.Database.ExecuteSqlRawAsync("EXEC Banner_Update @BannerId, @Nombre, @Imagen, @Activo", parametros);
        }

        // Eliminar un banner
        public async Task<int> EliminarBannerAsync(int bannerId)
        {
            var parametro = new SqlParameter("@BannerId", bannerId);
            return await _contexto.Database.ExecuteSqlRawAsync("EXEC Banner_Delete @BannerId", parametro);
        }


    }
}
