using System;
using System.Collections.Generic;

namespace Ecommerce.BD.Models;

public partial class ProductoTalla
{
    public int ProductoTallaId { get; set; }

    public int ProductoId { get; set; }

    public int TallaId { get; set; }

    public int CantidadStock { get; set; }

    public virtual Producto Producto { get; set; }

    public virtual Talla Talla { get; set; }
}
