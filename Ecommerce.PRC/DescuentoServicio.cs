using Ecommerce.BD.Models;
using Ecommerce.BD.Repositorios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.PRC.Servicios
{
    public class DescuentoServicio
    {
        private readonly DescuentoRepositorio _descuentoRepositorio;

        public DescuentoServicio(DescuentoRepositorio descuentoRepositorio)
        {
            _descuentoRepositorio = descuentoRepositorio;
        }

        public async Task<List<Descuento>> ObtenerTodosLosDescuentosAsync()
        {
            return await _descuentoRepositorio.ObtenerTodosLosDescuentosAsync();
        }

        public async Task<Descuento> ObtenerDescuentoPorIdAsync(int id)
        {
            return await _descuentoRepositorio.ObtenerDescuentoPorIdAsync(id);
        }

        public async Task<int> CrearDescuentoAsync(Descuento descuento)
        {
            return await _descuentoRepositorio.InsertarDescuentoAsync(descuento);
        }

        public async Task<int> ActualizarDescuentoAsync(Descuento descuento)
        {
            return await _descuentoRepositorio.ActualizarDescuentoAsync(descuento);
        }

        public async Task<int> EliminarDescuentoAsync(int id)
        {
            return await _descuentoRepositorio.EliminarDescuentoAsync(id);
        }
    }
}
