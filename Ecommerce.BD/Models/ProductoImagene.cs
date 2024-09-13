using System;
using System.Collections.Generic;

namespace Ecommerce.BD.Models;

public partial class ProductoImagene
{
    public int ImagenId { get; set; }

    public int ProductoId { get; set; }

    public string ImagenUrl { get; set; }

    public bool EsPrincipal { get; set; }

    public virtual Producto Producto { get; set; }
}
