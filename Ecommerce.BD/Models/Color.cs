using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.BD.Models;

public partial class Color
{
    public int ColorId { get; set; }

    [Required(ErrorMessage = "El nombre del color es obligatorio.")]
    [StringLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres.")]
    public string Col_Nombre { get; set; }

    [Required(ErrorMessage = "El código hexadecimal es obligatorio.")]
    [RegularExpression("^#([A-Fa-f0-9]{6})$", ErrorMessage = "El código hexadecimal no es válido.")]
    public string Col_Hexadecimal { get; set; }

    public virtual ICollection<ProductoColor> ProductoColores { get; set; } = new List<ProductoColor>();

}
