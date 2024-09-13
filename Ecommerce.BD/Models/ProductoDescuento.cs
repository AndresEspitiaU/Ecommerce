using System;
using System.Collections.Generic;

namespace Ecommerce.BD.Models;

public partial class ProductoDescuento
{
    public int ProductoDescuentoId { get; set; }

    public int ProductoId { get; set; }

    public int DescuentoId { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaFin { get; set; }

    public virtual Descuento Descuento { get; set; }

    public virtual Producto Producto { get; set; }
}
