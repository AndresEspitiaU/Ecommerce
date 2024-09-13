using System;
using System.Collections.Generic;

namespace Ecommerce.BD.Models;

public partial class Pedido
{
    public int PedidoId { get; set; }

    public int UsuarioId { get; set; }

    public DateTime? PedFechaPedido { get; set; }

    public decimal PedTotal { get; set; }

    public string PedEstado { get; set; }

    public int? DireccionId { get; set; }

    public virtual ICollection<Devolucione> Devoluciones { get; set; } = new List<Devolucione>();

    public virtual Direccione Direccion { get; set; }

    public virtual ICollection<PedidoItem> PedidoItems { get; set; } = new List<PedidoItem>();

    public virtual ICollection<Transaccione> Transacciones { get; set; } = new List<Transaccione>();

    public virtual Usuario Usuario { get; set; }
}
