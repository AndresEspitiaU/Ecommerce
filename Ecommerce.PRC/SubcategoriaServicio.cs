using Ecommerce.BD.Models;
using Ecommerce.BD.Repositorios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.PRC.Servicios
{
    public class SubcategoriaServicio
    {
        private readonly SubcategoriaRepositorio _subcategoriaRepositorio;

        public SubcategoriaServicio(SubcategoriaRepositorio subcategoriaRepositorio)
        {
            _subcategoriaRepositorio = subcategoriaRepositorio;
        }

        public async Task<List<Subcategoria>> ObtenerTodasLasSubcategoriasAsync()
        {
            return await _subcategoriaRepositorio.ObtenerTodasLasSubcategoriasAsync();
        }

        public async Task<Subcategoria> ObtenerSubcategoriaPorIdAsync(int id)
        {
            return await _subcategoriaRepositorio.ObtenerSubcategoriaPorIdAsync(id);
        }

        public async Task<int> CrearSubcategoriaAsync(Subcategoria subcategoria)
        {
            return await _subcategoriaRepositorio.InsertarSubcategoriaAsync(subcategoria);
        }

        public async Task<int> ActualizarSubcategoriaAsync(Subcategoria subcategoria)
        {
            return await _subcategoriaRepositorio.ActualizarSubcategoriaAsync(subcategoria);
        }

        public async Task<int> EliminarSubcategoriaAsync(int id)
        {
            return await _subcategoriaRepositorio.EliminarSubcategoriaAsync(id);
        }
    }
}
