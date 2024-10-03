using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.BD.Models
{
    public partial class ProductoColor
    {
        [Key]
        public int ProductoColorId { get; set; }

        [Required]
        public int ProductoId { get; set; }

        [Required]
        public int ColorId { get; set; }

        // Navegación a Producto
        [ForeignKey("ProductoId")]
        public virtual Producto Producto { get; set; }

        // Navegación a Colore
        [ForeignKey("ColorId")]
        public virtual Color Colores { get; set; }
    }
}
