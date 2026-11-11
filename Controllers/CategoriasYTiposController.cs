using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VentasVG.Data;
using VentasVG.Models;
using VentasVG.Models.ViewModels;

namespace VentasVG.Controllers
{
    public class CategoriasYTiposController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriasYTiposController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            //consultamos todas las Categorias de la tabla
            var vm = new CategoriaYTipoViewModel
            {
                Categorias = await _context.Categorias.ToListAsync(),
                UnidadVentas = await _context.UnidadVentas.ToListAsync()
            };
            //pasamos a la vista
            return View(vm);
        }
    //===CREAR===      
        //Procesar datos para insert de Categoria
        //Accion mostrar Formulario vacio
        public IActionResult CreateCategoria()
        {
            return View();
        }

        //2, Procesar los cambios (POST) CREAR
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategoria(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoria); //Prepara el objeto en memoria
                await _context.SaveChangesAsync(); //Guarda en SQL Server
                TempData["Success"] = "La categoria se creo correctamente.";
                return RedirectToAction(nameof(Index));
            }

            return View(categoria); //Si hay un error devuelve el formulario con los datos
        }
     //Procesar datos para insert de Unidad de Venta
        //Accion mostrar Formulario vacio
        public IActionResult CreateUnidadVenta()
        {
            return View();
        }

        //2, Procesar los cambios (POST) CREAR
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUnidadVenta(UnidadVenta unidadVenta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unidadVenta); //Prepara el objeto en memoria
                await _context.SaveChangesAsync(); //Guarda en SQL Server
                TempData["Success"] = "La Unidad de Venta se creo correctamente.";
                return RedirectToAction(nameof(Index));
            }

            return View(unidadVenta); //Si hay un error devuelve el formulario con los datos
        }

     //===EDITAR=== 
        //Mostra formulario con datos actuales Categoria
        public async Task<IActionResult> EditCategoria(int? id)
        {
            if (id == null) return NotFound();

            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null) return NotFound();

            return View(categoria);
        }
        //2, Procesar los cambios (POST) Editar Categoria
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategoria(int id, Categoria categoria)
        {
            if (id != categoria.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoria); //Prepara el objeto en memoria
                    await _context.SaveChangesAsync(); //Guarda en SQL Server
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Categorias.Any(e => e.Id == categoria.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index)); //redirige a index
            }
            TempData["Success"] = "La categoria se Edito correctamente.";
            return View(categoria); //Si hay un error devuelve el formulario con los datos
        }
       
        //Mostra formulario con datos actuales Unidad Venta
        public async Task<IActionResult> EditUnidadVenta(int? id)
        {
            if (id == null) return NotFound();

            var unidadVentas = await _context.UnidadVentas.FindAsync(id);

            if (unidadVentas == null) return NotFound();

            return View(unidadVentas);
        }
        //2, Procesar los cambios (POST) Editar Categoria
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUnidadVenta(int id, UnidadVenta unidadVenta)
        {
            if (id != unidadVenta.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unidadVenta); //Prepara el objeto en memoria
                    await _context.SaveChangesAsync(); //Guarda en SQL Server
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.UnidadVentas.Any(e => e.Id == unidadVenta.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index)); //redirige a index
            }
            TempData["Success"] = "La unidad se Edito correctamente.";
            return View(unidadVenta); //Si hay un error devuelve el formulario con los datos
        }
    //==ELIMINAR==
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            if (id == null)
                return NotFound();

            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null)
                return NotFound();

            return View(categoria);
        }
        [HttpPost, ActionName("DeleteCategoria")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCategoriaConfirmado(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            // Validación de negocio
            bool tieneProductos = await _context.Productos
                .AnyAsync(p => p.CategoriaId == id);

            if (tieneProductos)
            {
                TempData["Error"] = "No se puede eliminar porque tiene productos asociados.";
                return RedirectToAction(nameof(Index));
            }

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Categoría eliminada correctamente.";

            return RedirectToAction(nameof(Index));
        }

        //ELIMINAR UNIDAD
        public async Task<IActionResult> DeleteUnidad(int id)
        {
            if (id == null)
                return NotFound();

            var unidad = await _context.UnidadVentas.FindAsync(id);

            if (unidad == null)
                return NotFound();

            return View(unidad);
        }
        [HttpPost, ActionName("DeleteUnidad")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUnidadConfirmado(int id)
        {
            var unidad = await _context.UnidadVentas.FindAsync(id);

            if (unidad == null)
            {
                return NotFound();
            }

            // Validación de negocio
            bool tieneProductos = await _context.Productos
                .AnyAsync(p => p.UnidadVentaId == id);

            if (tieneProductos)
            {
                TempData["Error"] = "No se puede eliminar porque tiene productos asociados.";
                return RedirectToAction(nameof(Index));
            }

            _context.UnidadVentas.Remove(unidad);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Unidad de Venta eliminada correctamente.";

            return RedirectToAction(nameof(Index));
        }
    }
}
