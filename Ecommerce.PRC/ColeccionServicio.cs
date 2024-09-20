using Ecommerce.BD.Models;
using Ecommerce.BD.Repositorios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.PRC.Servicios
{
    public class ColeccionServicio
    {
        private readonly ColeccionRepositorio _coleccionRepositorio;

        public ColeccionServicio(ColeccionRepositorio coleccionRepositorio)
        {
            _coleccionRepositorio = coleccionRepositorio;
        }

        // Obtener todas las colecciones
        public async Task<List<Coleccione>> ObtenerTodasLasColeccionesAsync()
        {
            return await _coleccionRepositorio.ObtenerTodasLasColeccionesAsync();
        }

        // Obtener solo las colecciones activas
        public async Task<List<Coleccione>> ObtenerColeccionesActivasAsync()
        {
            return await _coleccionRepositorio.ObtenerColeccionesActivasAsync();
        }

        // Obtener una colección por su ID
        public async Task<Coleccione> ObtenerColeccionPorIdAsync(int id)
        {
            return await _coleccionRepositorio.ObtenerColeccionPorIdAsync(id);
        }

        // Crear una nueva colección
        public async Task<int> CrearColeccionAsync(Coleccione coleccion)
        {
            return await _coleccionRepositorio.InsertarColeccionAsync(coleccion);
        }

        // Actualizar una colección existente
        public async Task<int> ActualizarColeccionAsync(Coleccione coleccion)
        {
            return await _coleccionRepositorio.ActualizarColeccionAsync(coleccion);
        }

        // Eliminar una colección
        public async Task<int> EliminarColeccionAsync(int id)
        {
            return await _coleccionRepositorio.EliminarColeccionAsync(id);
        }
    }
}
