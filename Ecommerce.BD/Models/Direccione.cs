using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.BD.Models;

public partial class Direccione
{

    public int DireccionId { get; set; }

    public int UsuarioId { get; set; }

    public string DirDireccion { get; set; }

    public string DirCiudad { get; set; }

    public string DirDepartamento { get; set; }

    public string DirCodigoPostal { get; set; }

    public string DirPais { get; set; }

    public string DirTelefono { get; set; }

    public bool? DirEsDireccionPrincipal { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    public virtual Usuario Usuario { get; set; }
}
