using Ecommerce.BD.Models;
using Ecommerce.BD.Repositorios;

namespace Ecommerce.PRC.Servicios
{
    public class LogServicio
    {
        private readonly LogRepositorio _logRepositorio;

        public LogServicio(LogRepositorio logRepositorio)
        {
            _logRepositorio = logRepositorio;
        }

        // Obtener todos los logs
        public async Task<List<Log>> ObtenerTodosLosLogsAsync()
        {
            return await _logRepositorio.ObtenerTodosLosLogsAsync();
        }

        // Crear un nuevo log
        public async Task CrearLogAsync(string accion, int? usuarioId, string nivel)
        {
            var log = new Log
            {
                LogsAccion = accion,
                UsuarioId = usuarioId,
                LogsFecha = DateTime.Now,
                LogsNivel = nivel
            };

            await _logRepositorio.CrearLogAsync(log);
        }

        // Método para registrar un log
        public async Task RegistrarLogAsync(int? usuarioId, string logsAccion, string logsNivel)
        {
            var log = new Log
            {
                UsuarioId = usuarioId,
                LogsAccion = logsAccion,
                LogsFecha = DateTime.UtcNow,
                LogsNivel = logsNivel
            };

            await _logRepositorio.InsertarLogAsync(log);
        }


        // Eliminar un log por ID
        public async Task EliminarLogAsync(int logId)
        {
            await _logRepositorio.EliminarLogAsync(logId);
        }

        // Obtener un log por ID
        public async Task<Log> ObtenerLogPorIdAsync(int logId)
        {
            return await _logRepositorio.ObtenerLogPorIdAsync(logId);
        }

        // Obtener logs por usuario
        public async Task<List<Log>> ObtenerLogsPorUsuarioIdAsync(int usuarioId)
        {
            return await _logRepositorio.ObtenerLogsPorUsuarioIdAsync(usuarioId);
        }
    }
}
