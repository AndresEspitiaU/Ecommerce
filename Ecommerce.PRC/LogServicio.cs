using Ecommerce.BD.Models;
using Ecommerce.BD.Repositorios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.PRC.Servicios
{
    public class LogServicio
    {
        private readonly LogRepositorio _logRepositorio;
        private readonly UsuarioRepositorio _usuarioRepositorio; // Agregamos el repositorio de usuarios

        public LogServicio(LogRepositorio logRepositorio, UsuarioRepositorio usuarioRepositorio)
        {
            _logRepositorio = logRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
        }

        // Registrar un nuevo log con validación de usuario
        public async Task RegistrarLogAsync(int? usuarioId, string accion, string nivel)
        {
            if (usuarioId.HasValue)
            {
                var usuario = await _usuarioRepositorio.ObtenerUsuarioPorUsuarioIdAsync(usuarioId.Value);
                if (usuario == null)
                {
                    throw new Exception("El UsuarioId no existe en la base de datos.");
                }
            }

            var log = new Log
            {
                UsuarioId = usuarioId,  // Puede ser nulo si el log no está asociado a ningún usuario
                LogsAccion = accion,
                LogsNivel = nivel,
                LogsFecha = DateTime.Now
            };

            await _logRepositorio.InsertarLogAsync(log);
        }

        // Obtener todos los logs
        public async Task<List<Log>> ObtenerTodosLosLogsAsync()
        {
            return await _logRepositorio.ObtenerTodosLosLogsAsync();
        }

        // Obtener log por Id
        public async Task<Log> ObtenerLogPorIdAsync(int id)
        {
            return await _logRepositorio.ObtenerLogPorIdAsync(id);
        }
    }
}
