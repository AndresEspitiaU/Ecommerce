using System;
using System.Collections.Generic;

namespace Ecommerce.BD.Models;

public partial class ListaDeseoItem
{
    public int ListaDeseoItemId { get; set; }

    public int ListaDeseoId { get; set; }

    public int ProductoId { get; set; }

    public DateTime? FechaAgregado { get; set; }

    public virtual ListaDeseo ListaDeseo { get; set; }

    public virtual Producto Producto { get; set; }
}
