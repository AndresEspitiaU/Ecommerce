using Ecommerce.BD.Models;
using Ecommerce.BD.Repositorios;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Ecommerce.PRC.Servicios
{
    public class CuponServicio
    {
        private readonly CuponRepositorio _cuponRepositorio;

        public CuponServicio(CuponRepositorio cuponRepositorio)
        {
            _cuponRepositorio = cuponRepositorio;
        }

        public async Task<List<Cupone>> ObtenerTodosLosCuponesAsync()
        {
            return await _cuponRepositorio.ObtenerTodosLosCuponesAsync();
        }

        public async Task<Cupone> ObtenerCuponPorIdAsync(int id)
        {
            return await _cuponRepositorio.ObtenerCuponPorIdAsync(id);
        }

        public async Task<int> CrearCuponAsync(Cupone cupon)
        {
            return await _cuponRepositorio.InsertarCuponAsync(cupon);
        }

        public async Task<int> ActualizarCuponAsync(Cupone cupon)
        {
            return await _cuponRepositorio.ActualizarCuponAsync(cupon);
        }

        public async Task<int> EliminarCuponAsync(int id)
        {
            return await _cuponRepositorio.EliminarCuponAsync(id);
        }
    }
}
