using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.BD.Models;

public partial class Coleccione
{
    
    public int ColeccionId { get; set; }

    public string ColNombre { get; set; }

    public string ColDescripcion { get; set; }

    public string ColImagenUrl { get; set; }

    public bool ColActivo { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
