using Ecommerce.BD.Models;
using Ecommerce.PRC.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

public class ProductoTallaController : Controller
{
    private readonly ProductoTallaServicio _productoTallaServicio;
    private readonly ProductoServicio _productoServicio;
    private readonly TallaServicio _tallaServicio;

    public ProductoTallaController(ProductoTallaServicio productoTallaServicio, ProductoServicio productoServicio, TallaServicio tallaServicio)
    {
        _productoTallaServicio = productoTallaServicio;
        _productoServicio = productoServicio;
        _tallaServicio = tallaServicio;
    }

    // Método Index para listar ProductoTalla
    public async Task<IActionResult> Index()
    {
        var productoTallas = await _productoTallaServicio.ObtenerTodosLosProductoTallasAsync();
        return View(productoTallas);
    }

    // Crear ProductoTalla (GET)
    public async Task<IActionResult> Crear()
    {
        var productos = await _productoServicio.ObtenerTodosLosProductosAsync();
        var tallasConCategorias = await _tallaServicio.ObtenerTallasConCategoriasAsync();

        ViewBag.Productos = new SelectList(productos, "ProductoId", "ProNombre");
        ViewBag.Tallas = new SelectList(tallasConCategorias, "Value", "Text");

        // Limpiar TempData para evitar que se muestre la alerta en la vista de creación
        TempData.Remove("SuccessMessage");

        return View();
    }

    // Crear ProductoTalla (POST)
    [HttpPost]
    public async Task<IActionResult> Crear(ProductoTalla productoTalla)
    {
        if (ModelState.IsValid)
        {
            await _productoTallaServicio.CrearProductoTallaAsync(productoTalla);
            TempData["SuccessMessage"] = "Producto Talla creado con éxito";
            return RedirectToAction("Index");
        }

        // Obtener productos y tallas con los nombres completos (producto y talla)
        var productos = await _productoServicio.ObtenerTodosLosProductosAsync();
        var tallasConCategorias = await _tallaServicio.ObtenerTallasConCategoriasAsync();

        ViewBag.Productos = new SelectList(productos, "ProductoId", "ProNombre");
        ViewBag.Tallas = new SelectList(tallasConCategorias, "Value", "Text");

        return View(productoTalla);
    }




    // Editar ProductoTalla (GET)
    public async Task<IActionResult> Editar(int id)
    {
        var productoTalla = await _productoTallaServicio.ObtenerProductoTallaPorIdAsync(id);
        if (productoTalla == null)
        {
            return NotFound();
        }

        var productos = await _productoServicio.ObtenerTodosLosProductosAsync();
        var tallasConProductos = await _tallaServicio.ObtenerTallasConProductosAsync();

        ViewBag.Productos = new SelectList(productos, "ProductoId", "ProNombre", productoTalla.ProductoId);
        ViewBag.Tallas = new SelectList(tallasConProductos, "Value", "Text", productoTalla.TallaId);

        return View(productoTalla);
    }

    // Editar ProductoTalla (POST)
    [HttpPost]
    public async Task<IActionResult> Editar(int id, ProductoTalla productoTalla)
    {
        try
        {
            if (id != productoTalla.ProductoTallaId)
            {
                return Json(new { success = false, message = "El ID del producto-talla no coincide." });
            }

            if (ModelState.IsValid)
            {
                var productoTallaExistente = await _productoTallaServicio.ObtenerProductoTallaPorIdAsync(id);
                if (productoTallaExistente == null)
                {
                    return Json(new { success = false, message = "El producto-talla no existe." });
                }

                await _productoTallaServicio.ActualizarProductoTallaAsync(productoTalla);

                // Devolver JSON para la solicitud AJAX
                if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                {
                    return Json(new { success = true, message = "Producto Talla actualizado con éxito" });
                }

                // Si no es AJAX, redirigir al Index
                return RedirectToAction("Index");
            }

            return Json(new { success = false, message = "Error en la validación de los datos." });
        }
        catch (Exception ex)
        {
            return Json(new { success = false, message = "Ocurrió un error en el servidor: " + ex.Message });
        }
    }


    /// <summary>
    /// Descripcion: Eliminar un Producto Talla
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> Eliminar(int id)
    {
        var productoTalla = await _productoTallaServicio.ObtenerProductoTallaPorIdAsync(id);
        if (productoTalla == null)
        {
            return Json(new { success = false, message = "Producto Talla no encontrado" });
        }

        await _productoTallaServicio.EliminarProductoTallaAsync(id);
        return Json(new { success = true, message = "Producto Talla eliminado con éxito" });
    }



}
