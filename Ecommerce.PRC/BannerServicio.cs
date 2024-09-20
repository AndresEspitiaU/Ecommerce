using Ecommerce.BD.Models;
using Ecommerce.BD.Repositorios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.PRC.Servicios
{
    public class BannerServicio
    {
        private readonly BannerRepositorio _bannerRepositorio;

        public BannerServicio(BannerRepositorio bannerRepositorio)
        {
            _bannerRepositorio = bannerRepositorio;
        }
        public async Task<List<Banner>> ObtenerBannersActivosAsync()
        {
            return await _bannerRepositorio.ObtenerBannersActivosAsync();
        }

        // Listar todos los banners
        public async Task<List<Banner>> ObtenerTodosLosBannersAsync()
        {
            return await _bannerRepositorio.ObtenerTodosLosBannersAsync();
        }

        // Obtener un banner por ID
        public async Task<Banner> ObtenerBannerPorIdAsync(int bannerId)
        {
            return await _bannerRepositorio.ObtenerBannerPorIdAsync(bannerId);
        }

        // Insertar un nuevo banner
        public async Task<int> InsertarBannerAsync(Banner banner)
        {
            return await _bannerRepositorio.InsertarBannerAsync(banner);
        }

        // Actualizar un banner existente
        public async Task<int> ActualizarBannerAsync(Banner banner)
        {
            return await _bannerRepositorio.ActualizarBannerAsync(banner);
        }

        // Eliminar un banner
        public async Task<int> EliminarBannerAsync(int bannerId)
        {
            return await _bannerRepositorio.EliminarBannerAsync(bannerId);
        }
    }
}
