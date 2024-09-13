using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.BD.Models;

public partial class Descuento
{
   
    public int DescuentoId { get; set; }

    public string DesNombre { get; set; }

    public string DesDescripcion { get; set; }

    public decimal DesPorcentaje { get; set; }

    public bool DesActivo { get; set; }

    public virtual ICollection<ProductoDescuento> ProductoDescuentos { get; set; } = new List<ProductoDescuento>();
}
