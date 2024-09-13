using System;
using System.Collections.Generic;

namespace Ecommerce.BD.Models;

public partial class Transaccione
{
    public int TransaccionId { get; set; }

    public int UsuarioId { get; set; }

    public int PedidoId { get; set; }

    public decimal TraMonto { get; set; }

    public string TraMetodoPago { get; set; }

    public string TraEstado { get; set; }

    public DateTime? TraFechaTransaccion { get; set; }

    public virtual Pedido Pedido { get; set; }

    public virtual Usuario Usuario { get; set; }
}
