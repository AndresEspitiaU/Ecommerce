

namespace Ecommerce.BD.Models;

public partial class Log
{
    public int LogId { get; set; }

    public int? UsuarioId { get; set; }

    public string LogsAccion { get; set; }

    public DateTime? LogsFecha { get; set; }

    public string LogsNivel { get; set; }

    public virtual Usuario Usuario { get; set; }
}
