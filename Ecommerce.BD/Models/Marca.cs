using System;
using System.Collections.Generic;

namespace Ecommerce.BD.Models;

public partial class Marca
{
    public int MarcaId { get; set; }

    public string MarNombre { get; set; }

    public int ProductosCount { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
