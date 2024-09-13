using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.BD.Models;

public partial class Favorito
{

    public int FavoritoId { get; set; }

    public int UsuarioId { get; set; }

    public int ProductoId { get; set; }

    public DateTime? FechaAgregado { get; set; }

    public virtual Producto Producto { get; set; }

    public virtual Usuario Usuario { get; set; }
}
