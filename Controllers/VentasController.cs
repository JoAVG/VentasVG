using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VentasVG.Data;

namespace VentasVG.Controllers
{
    public class VentasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VentasController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            //consultamos todas las Ventas de la tabla
            var listaVentas = await _context.Ventas.ToListAsync();

            //pasamos la lista a la vista
            return View(listaVentas);
        }

        //Mostra formulario con datos actuales
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var detalles = await _context.VentaDetalles
                .Include(vd => vd.Producto)
                .Where(vd => vd.VentaId == id)
                .ToListAsync();

            if (!detalles.Any()) return NotFound();

            return View(detalles);
        }
    }
}
