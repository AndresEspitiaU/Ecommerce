using Ecommerce.BD.Models;
using Ecommerce.BD.Repositorios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.PRC.Servicios
{
    public class GeneroServicio
    {
        private readonly GeneroRepositorio _generoRepositorio;

        public GeneroServicio(GeneroRepositorio generoRepositorio)
        {
            _generoRepositorio = generoRepositorio;
        }

        // Obtener todos los géneros
        public async Task<List<Genero>> ObtenerTodosLosGenerosAsync()
        {
            return await _generoRepositorio.ObtenerTodosLosGenerosAsync();
        }

        // Obtener un género por ID
        public async Task<Genero> ObtenerGeneroPorIdAsync(int id)
        {
            return await _generoRepositorio.ObtenerGeneroPorIdAsync(id);
        }

        // Insertar un nuevo género
        public async Task<int> InsertarGeneroAsync(Genero genero)
        {
            return await _generoRepositorio.InsertarGeneroAsync(genero);
        }

        // Actualizar un género existente
        public async Task<int> ActualizarGeneroAsync(Genero genero)
        {
            return await _generoRepositorio.ActualizarGeneroAsync(genero);
        }

        // Eliminar un género
        public async Task<int> EliminarGeneroAsync(int id)
        {
            return await _generoRepositorio.EliminarGeneroAsync(id);
        }
    }
}
