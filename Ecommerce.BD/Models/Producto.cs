using System;
using System.Collections.Generic;

namespace Ecommerce.BD.Models;

public partial class Producto
{
    public int ProductoId { get; set; }

    public string ProCodigo { get; set; }

    public string ProNombre { get; set; }

    public string ProDescripcionCorta { get; set; }

    public string ProDescripción { get; set; }

    public decimal ProPrecio { get; set; }

    public int ProStock { get; set; }

    public decimal? ProPeso { get; set; }

    public string ProImagenUrl { get; set; }

    public bool ProActivo { get; set; }

    public DateTime? ProFechaCreacion { get; set; }

    public DateTime? ProFechaActualizacion { get; set; }

    public int? ProCategoriaId { get; set; }

    public int? ProMarcaId { get; set; }

    public int? ProColeccionId { get; set; }

    public int? ProGeneroId { get; set; }

    public int? SubcategoriaId { get; set; }

    public virtual ICollection<CarritoItem> CarritoItems { get; set; } = new List<CarritoItem>();

    public virtual ICollection<Devolucione> Devoluciones { get; set; } = new List<Devolucione>();

    public virtual ICollection<Favorito> Favoritos { get; set; } = new List<Favorito>();

    public virtual ICollection<ListaDeseoItem> ListaDeseoItems { get; set; } = new List<ListaDeseoItem>();

    public virtual ICollection<PedidoItem> PedidoItems { get; set; } = new List<PedidoItem>();

    public virtual Categoria ProCategoria { get; set; }

    public virtual Coleccione ProColeccion { get; set; }

    public virtual Genero ProGenero { get; set; }

    public virtual Marca ProMarca { get; set; }

    public virtual Subcategoria Subcategoria { get; set; }

    public virtual ICollection<ProductoDescuento> ProductoDescuentos { get; set; } = new List<ProductoDescuento>();

    public virtual ICollection<ProductoImagene> ProductoImagenes { get; set; } = new List<ProductoImagene>();

    public virtual ICollection<ProductoTalla> ProductoTallas { get; set; } = new List<ProductoTalla>();

    public virtual ICollection<PromocionProducto> PromocionProductos { get; set; } = new List<PromocionProducto>();

    public virtual ICollection<Reseña> Reseñas { get; set; } = new List<Reseña>();

    public virtual ICollection<ProductoColor> ProductoColores { get; set; } = new List<ProductoColor>();

}
