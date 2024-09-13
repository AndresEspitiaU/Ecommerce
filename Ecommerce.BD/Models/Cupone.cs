using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.BD.Models;

public partial class Cupone
{
 
    public int CuponId { get; set; }

    public string CupCodigo { get; set; }

    public string CupDescripcion { get; set; }

    public decimal? CupPorcentajeDescuento { get; set; }

    public decimal? CupMontoDescuento { get; set; }

    public DateTime? CupFechaInicio { get; set; }

    public DateTime? CupFechaExpiracion { get; set; }

    public bool CupActivo { get; set; }
}
