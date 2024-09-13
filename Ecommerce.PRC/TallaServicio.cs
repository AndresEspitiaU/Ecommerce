﻿using Ecommerce.BD.Models;
using Ecommerce.BD.Repositorios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.PRC.Servicios
{
    public class TallaServicio
    {
        private readonly TallaRepositorio _tallaRepositorio;

        public TallaServicio(TallaRepositorio tallaRepositorio)
        {
            _tallaRepositorio = tallaRepositorio;
        }

        // Obtener todas las tallas
        public async Task<List<Talla>> ObtenerTodasLasTallasAsync()
        {
            return await _tallaRepositorio.ObtenerTodasLasTallasAsync();
        }

        // Obtener una talla por ID
        public async Task<Talla> ObtenerTallaPorIdAsync(int id)
        {
            return await _tallaRepositorio.ObtenerTallaPorIdAsync(id);
        }

        // Insertar una nueva talla
        public async Task<int> InsertarTallaAsync(Talla talla)
        {
            // Puedes agregar validaciones de negocio aquí
            if (string.IsNullOrEmpty(talla.TalNombre))
            {
                throw new System.ArgumentException("El nombre de la talla es obligatorio");
            }

            return await _tallaRepositorio.InsertarTallaAsync(talla);
        }

        // Actualizar una talla existente
        public async Task<int> ActualizarTallaAsync(Talla talla)
        {
            if (talla.TallaId <= 0)
            {
                throw new System.ArgumentException("El ID de la talla no es válido");
            }

            return await _tallaRepositorio.ActualizarTallaAsync(talla);
        }

        // Eliminar una talla
        public async Task<int> EliminarTallaAsync(int id)
        {
            if (id <= 0)
            {
                throw new System.ArgumentException("El ID de la talla no es válido");
            }

            return await _tallaRepositorio.EliminarTallaAsync(id);
        }
    }
}
