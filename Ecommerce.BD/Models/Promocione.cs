

namespace Ecommerce.BD.Models;

public partial class Promocione
{
    public int PromocionId { get; set; }

    public string PromNombre { get; set; }

    public string PromDescripcion { get; set; }

    public DateTime PromFechaInicio { get; set; }

    public DateTime PromFechaFin { get; set; }

    public decimal? PromDescuentoPorcentaje { get; set; }

    public decimal? PromDescuentoMonto { get; set; }

    public bool PromActivo { get; set; }

    public virtual ICollection<PromocionProducto> PromocionProductos { get; set; } = new List<PromocionProducto>();
}
