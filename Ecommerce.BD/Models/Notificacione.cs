using System;
using System.Collections.Generic;

namespace Ecommerce.BD.Models;

public partial class Notificacione
{
    public int NotificacionId { get; set; }

    public int UsuarioId { get; set; }

    public string NotTitulo { get; set; }

    public string NotMensaje { get; set; }

    public string NotTipo { get; set; }

    public DateTime? NotFechaEnvio { get; set; }

    public bool? NotLeido { get; set; }

    public virtual Usuario Usuario { get; set; }
}
