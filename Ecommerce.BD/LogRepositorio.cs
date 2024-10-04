using Ecommerce.BD.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.BD.Repositorios
{
    public class LogRepositorio
    {
        private readonly EcommerceContext _contexto;

        public LogRepositorio(EcommerceContext contexto)
        {
            _contexto = contexto;
        }

        // Método para insertar un log en la base de datos
        public async Task InsertarLogAsync(Log log)
        {
            await _contexto.Logs.AddAsync(log);
            await _contexto.SaveChangesAsync(); // Guarda los cambios en la base de datos
        }

        // Obtener todos los logs
        public async Task<List<Log>> ObtenerTodosLosLogsAsync()
        {
            return await _contexto.Logs
                                  .Include(log => log.Usuario) // Incluir la relación con el usuario
                                  .ToListAsync();
        }

        // Crear un nuevo log
        public async Task CrearLogAsync(Log log)
        {
            _contexto.Logs.Add(log);
            await _contexto.SaveChangesAsync();
        }

        // Eliminar un log por ID
        public async Task EliminarLogAsync(int logId)
        {
            var log = await _contexto.Logs.FindAsync(logId);
            if (log != null)
            {
                _contexto.Logs.Remove(log);
                await _contexto.SaveChangesAsync();
            }
        }

        // Obtener un log por ID
        public async Task<Log> ObtenerLogPorIdAsync(int logId)
        {
            return await _contexto.Logs
                                  .Include(log => log.Usuario) // Incluir la relación con el usuario
                                  .FirstOrDefaultAsync(log => log.LogId == logId);
        }

        // Obtener logs por usuario
        public async Task<List<Log>> ObtenerLogsPorUsuarioIdAsync(int usuarioId)
        {
            return await _contexto.Logs
                                  .Where(log => log.UsuarioId == usuarioId)
                                  .Include(log => log.Usuario) // Incluir la relación con el usuario
                                  .ToListAsync();
        }
    }
}
