using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.BD.Models;

public partial class Coleccione
{
    
    public int ColeccionId { get; set; }

    [Column("Col_Nombre")]
    public string ColNombre { get; set; }

    [Column("Col_Descripcion")]
    public string ColDescripcion { get; set; }

    [Column("Col_ImagenUrl")]
    public string ColImagenUrl { get; set; }

    [Column("Col_Activo")]
    public bool ColActivo { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
