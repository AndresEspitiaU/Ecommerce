using System.Collections.Generic;
using System.Threading.Tasks;
using Ecommerce.BD.Repositorios;
using Ecommerce.BD.Models;

namespace Ecommerce.PRC.Servicios
{
    public class ColoreServicio
    {
        private readonly ColoreRepositorio _coloreRepositorio;

        public ColoreServicio(ColoreRepositorio coloreRepositorio)
        {
            _coloreRepositorio = coloreRepositorio;
        }

        public async Task<int> CrearColorAsync(string nombre, string hexadecimal)
        {
            // Validaciones de negocio, si son necesarias
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre del color es obligatorio.");
            }

            if (!hexadecimal.StartsWith("#") || hexadecimal.Length != 7)
            {
                throw new ArgumentException("El código hexadecimal es inválido.");
            }

            return await _coloreRepositorio.InsertarColorAsync(nombre, hexadecimal);
        }

        public async Task<int> ActualizarColorAsync(int id, string nombre, string hexadecimal)
        {
            // Lógica de validación o negocio si es necesario
            return await _coloreRepositorio.ActualizarColorAsync(id, nombre, hexadecimal);
        }

        public async Task<int> EliminarColorAsync(int id)
        {
            // Lógica de validación o negocio si es necesario
            return await _coloreRepositorio.EliminarColorAsync(id);
        }

        public async Task<List<Color>> ObtenerTodosLosColoresAsync()
        {
            return await _coloreRepositorio.ObtenerTodosLosColoresAsync();
        }

        public async Task<Color> ObtenerColorPorIdAsync(int id)
        {
            return await _coloreRepositorio.ObtenerColorPorIdAsync(id);
        }

    }
}
