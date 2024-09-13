using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.BD.Models;

public partial class Devolucione
{

    public int DevolucionId { get; set; }

    public int PedidoId { get; set; }

    public int ProductoId { get; set; }

    public int Cantidad { get; set; }

    public string DevMotivo { get; set; }

    public DateTime? DevFechaDevolucion { get; set; }

    public string DevEstado { get; set; }

    public virtual Pedido Pedido { get; set; }

    public virtual Producto Producto { get; set; }
}
