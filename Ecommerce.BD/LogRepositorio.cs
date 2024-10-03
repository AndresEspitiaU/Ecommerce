using Ecommerce.BD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        // Insertar un nuevo registro de log
        public async Task InsertarLogAsync(Log log)
        {
            _contexto.Logs.Add(log);
            await _contexto.SaveChangesAsync();
        }

        // Obtener todos los logs
        public async Task<List<Log>> ObtenerTodosLosLogsAsync()
        {
            return await _contexto.Logs
                .Include(l => l.Usuario)
                .ToListAsync();
        }

        // Obtener log por Id
        public async Task<Log> ObtenerLogPorIdAsync(int id)
        {
            return await _contexto.Logs
                .Include(l => l.Usuario)
                .FirstOrDefaultAsync(l => l.LogId == id);
        }

        
    }
}
