using System;
using System.Collections.Generic;

namespace Ecommerce.BD.Models;

public partial class Talla
{
    public int TallaId { get; set; }

    public string TalNombre { get; set; }  // Nombre de la talla (S, M, L, 32, 40, etc.)

    public string TalCategoria { get; set; }  // Categoría de la talla (Ej: Camisa, Pantalón, Zapatos)

    public string TalDescripcion { get; set; }  // Descripción opcional (Ej: "Talla mediana para camisetas de hombre")

    public int TalOrdenVisualizacion { get; set; }  // Orden de visualización para ordenar las tallas en la vista del usuario

    // Propiedades específicas para prendas superiores (camisetas, camisas, chaquetas)
    public int? TalPecho { get; set; }  // Medida del pecho en cm
    public int? TalCuello { get; set; }  // Medida del cuello en cm
    public int? TalLongitudManga { get; set; }  // Longitud de la manga en cm

    // Propiedades específicas para pantalones
    public int? TalCintura { get; set; }  // Medida de la cintura en cm
    public int? TalCadera { get; set; }  // Medida de la cadera en cm
    public int? TalLargo { get; set; }  // Largo de la pierna en cm

    // Propiedades específicas para calzado
    public int? TalColombia { get; set; }  // Talla en Colombia
    public int? TalUS { get; set; }  // Talla en US
    public int? TalEU { get; set; }  // Talla en EU

    public virtual ICollection<ProductoTalla> ProductoTallas { get; set; } = new List<ProductoTalla>();
}
