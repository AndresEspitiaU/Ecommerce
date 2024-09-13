using System;
using System.Collections.Generic;

namespace Ecommerce.BD.Models;

public partial class ListaDeseo
{
    public int ListaDeseoId { get; set; }

    public int UsuarioId { get; set; }

    public string ListaDeseoNombre { get; set; }

    public DateTime? ListaDeseoFechaCreacion { get; set; }

    public virtual ICollection<ListaDeseoItem> ListaDeseoItems { get; set; } = new List<ListaDeseoItem>();

    public virtual Usuario Usuario { get; set; }
}
