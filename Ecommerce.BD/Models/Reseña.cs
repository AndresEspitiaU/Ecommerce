using System;
using System.Collections.Generic;

namespace Ecommerce.BD.Models;

public partial class Reseña
{
    public int ReseñaId { get; set; }

    public int ProductoId { get; set; }

    public int UsuarioId { get; set; }

    public int? ResPuntuacion { get; set; }

    public string ResComentario { get; set; }

    public DateTime? ResFechaReseña { get; set; }

    public virtual Producto Producto { get; set; }

    public virtual Usuario Usuario { get; set; }
}
