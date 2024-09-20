using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BD.Models
{
    public class Banner
    {
        [Key]
        public int BannerId { get; set; } 
        public string Nombre { get; set; }
        public string Imagen { get; set; } 
        public bool Activo { get; set; } 
        public DateTime FechaCreacion { get; set; } 
        public DateTime FechaActualizacion { get; set; } 
    }
}
