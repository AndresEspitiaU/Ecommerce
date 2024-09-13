using System;
using System.Collections.Generic;

namespace Ecommerce.BD.Models;

public partial class Genero
{
    public int GeneroId { get; set; }

    public string GenNombre { get; set; }

    public string GenDescripcion { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
