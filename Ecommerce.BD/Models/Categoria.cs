using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.BD.Models
{
    public partial class Categoria
    {
        public int CategoriaId { get; set; }

        [Required]
        public string CatNombre { get; set; }

        public string CatImagenUrl { get; set; }

        // Relación con las subcategorías
        public virtual ICollection<Subcategoria> Subcategorias { get; set; } = new List<Subcategoria>();

        // Relación con productos (si aplicable a categorías principales)
        public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
    }
}
