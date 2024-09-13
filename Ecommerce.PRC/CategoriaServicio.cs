using Ecommerce.BD.Models;
using Ecommerce.BD.Repositorios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.PRC.Servicios
{
    public class CategoriaServicio
    {
        private readonly CategoriaRepositorio _categoriaRepositorio;

        public CategoriaServicio(CategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        public async Task<List<Categoria>> ObtenerTodasLasCategoriasAsync()
        {
            return await _categoriaRepositorio.ObtenerTodasLasCategoriasAsync();
        }

        public async Task<Categoria> ObtenerCategoriaPorIdAsync(int id)
        {
            return await _categoriaRepositorio.ObtenerCategoriaPorIdAsync(id);
        }

        public async Task<int> CrearCategoriaAsync(Categoria categoria)
        {
            return await _categoriaRepositorio.InsertarCategoriaAsync(categoria);
        }

        public async Task<int> ActualizarCategoriaAsync(Categoria categoria)
        {
            return await _categoriaRepositorio.ActualizarCategoriaAsync(categoria);
        }

        public async Task<int> EliminarCategoriaAsync(int id)
        {
            return await _categoriaRepositorio.EliminarCategoriaAsync(id);
        }
    }
}
