using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.BD.Models;

public partial class Carrito
{
   
    public int CarritoId { get; set; }

    public int UsuarioId { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<CarritoItem> CarritoItems { get; set; } = new List<CarritoItem>();

    public virtual Usuario Usuario { get; set; }
}
