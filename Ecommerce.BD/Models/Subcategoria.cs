using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.BD.Models
{
    public partial class Subcategoria
    {
        public int SubcategoriaId { get; set; }

        [Required]
        public string SubNombre { get; set; }

        public string SubImagenUrl { get; set; }

        // Relación con la categoría principal
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }

        // Relación con productos
        public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
    }
}
