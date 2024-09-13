using Microsoft.AspNetCore.Identity;

namespace Ecommerce.BD.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string IdentityUserId { get; set; }

    public string UsuNombre { get; set; }

    public string UsuApellido { get; set; }

    public DateTime? UsuFechaRegistro { get; set; }

    public string UsuTelefono { get; set; }

    public bool? UsuActivo { get; set; }

    public virtual IdentityUser IdentityUser { get; set; }

    public virtual ICollection<Carrito> Carritos { get; set; } = new List<Carrito>();

    public virtual ICollection<Direccione> Direcciones { get; set; } = new List<Direccione>();

    public virtual ICollection<Favorito> Favoritos { get; set; } = new List<Favorito>();

    public virtual ICollection<ListaDeseo> ListaDeseos { get; set; } = new List<ListaDeseo>();

    public virtual ICollection<Log> Logs { get; set; } = new List<Log>();

    public virtual ICollection<Notificacione> Notificaciones { get; set; } = new List<Notificacione>();

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    public virtual ICollection<Reseña> Reseñas { get; set; } = new List<Reseña>();

    public virtual ICollection<Transaccione> Transacciones { get; set; } = new List<Transaccione>();
}
