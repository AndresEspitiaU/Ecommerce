using Ecommerce.BD.Models;
using Ecommerce.BD.Repositorios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.PRC.Servicios
{
    public class PromocionServicio
    {
        private readonly PromocionRepositorio _promocionRepositorio;

        public PromocionServicio(PromocionRepositorio promocionRepositorio)
        {
            _promocionRepositorio = promocionRepositorio;
        }

        // Obtener todas las promociones
        public async Task<List<Promocione>> ObtenerTodasLasPromocionesAsync()
        {
            return await _promocionRepositorio.ObtenerTodasLasPromocionesAsync();
        }

        // Obtener una promoción por ID
        public async Task<Promocione> ObtenerPromocionPorIdAsync(int id)
        {
            return await _promocionRepositorio.ObtenerPromocionPorIdAsync(id);
        }

        // Insertar una nueva promoción
        public async Task<int> InsertarPromocionAsync(Promocione promocion)
        {
            // Validaciones o reglas de negocio, si es necesario
            if (string.IsNullOrEmpty(promocion.PromNombre))
            {
                throw new System.ArgumentException("El nombre de la promoción es obligatorio");
            }

            return await _promocionRepositorio.InsertarPromocionAsync(promocion);
        }

        // Actualizar una promoción existente
        public async Task<int> ActualizarPromocionAsync(Promocione promocion)
        {
            // Validaciones o reglas de negocio
            if (promocion.PromocionId <= 0)
            {
                throw new System.ArgumentException("El ID de la promoción no es válido");
            }

            return await _promocionRepositorio.ActualizarPromocionAsync(promocion);
        }

        // Eliminar una promoción por ID
        public async Task<int> EliminarPromocionAsync(int id)
        {
            // Regla de negocio: Asegurarse de que el ID sea válido
            if (id <= 0)
            {
                throw new System.ArgumentException("El ID de la promoción no es válido");
            }

            return await _promocionRepositorio.EliminarPromocionAsync(id);
        }
    }
}
