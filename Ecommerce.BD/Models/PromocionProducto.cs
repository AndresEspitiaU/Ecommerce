using System;
using System.Collections.Generic;

namespace Ecommerce.BD.Models;

public partial class PromocionProducto
{
    public int PromocionProductoId { get; set; }

    public int PromocionId { get; set; }

    public int ProductoId { get; set; }

    public virtual Producto Producto { get; set; }

    public virtual Promocione Promocion { get; set; }
}
