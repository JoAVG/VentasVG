using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VentasVG.Data;
using VentasVG.Models;
using VentasVG.Models.ViewModels;

namespace VentasVG.Controllers
{
    public class RealizarVentasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RealizarVentasController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var vm = new ProductoViewModel
            {
                //consultamos todas los prudctos de la tabla
                Productos = await _context.Productos.ToListAsync(),
                Categorias = await _context.Categorias.ToListAsync(),
                UnidadVentas = await _context.UnidadVentas.ToListAsync()
            };
            

            //pasamos la lista a la vista
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RealizarVenta(RealizarVentaViewModel ventaDetalles)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var venta = new Venta();

            foreach (var ventadetalle in ventaDetalles.Detalles)
            {
                venta.Detalles.Add(new VentaDetalle
                {
                    ProductoId = ventadetalle.ProductoId,
                    Cantidad = ventadetalle.Cantidad,
                    PrecioUnitario = ventadetalle.PrecioUnitario
                });
            }

            venta.Total = venta.Detalles.Sum(dv => dv.Subtotal);

            _context.Ventas.Add(venta);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}
