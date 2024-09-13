using Ecommerce.BD.Models;
using Ecommerce.BD.Repositorios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.PRC.Servicios
{
    public class MarcaServicio
    {
        private readonly MarcaRepositorio _marcaRepositorio;

        public MarcaServicio(MarcaRepositorio marcaRepositorio)
        {
            _marcaRepositorio = marcaRepositorio;
        }

        public async Task<List<Marca>> ObtenerTodasLasMarcasAsync()
        {
            return await _marcaRepositorio.ObtenerTodasLasMarcasAsync();
        }

        public async Task<Marca> ObtenerMarcaPorIdAsync(int id)
        {
            return await _marcaRepositorio.ObtenerMarcaPorIdAsync(id);
        }

        public async Task<int> CrearMarcaAsync(Marca marca)
        {
            return await _marcaRepositorio.InsertarMarcaAsync(marca);
        }

        public async Task<int> ActualizarMarcaAsync(Marca marca)
        {
            return await _marcaRepositorio.ActualizarMarcaAsync(marca);
        }

        public async Task<int> EliminarMarcaAsync(int id)
        {
            return await _marcaRepositorio.EliminarMarcaAsync(id);
        }
    }
}
