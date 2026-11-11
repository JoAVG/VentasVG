using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VentasVG.Data;
using VentasVG.Models;
using VentasVG.Models.ViewModels;

namespace VentasVG.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
        { 
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var listaProductos = await _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.UnidadVenta)
                .ToListAsync();

            return View(listaProductos);
        }

        //Accion mostrar Formulario vacio
        public async Task<IActionResult> Create()
        {
            //consultamos todas las Categorias de la tabla
            var vm = new NuevoProductoViewModel
            {
                Producto = new(),
                Categorias = await _context.Categorias.ToListAsync(),
                UnidadVentas = await _context.UnidadVentas.ToListAsync()
            }; 
            return View(vm);
        }

        //2, Procesar los cambios (POST) CREAR
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NuevoProductoViewModel vm)
        {
            
            if (ModelState.IsValid)
            {
                _context.Add(vm.Producto);
                await _context.SaveChangesAsync();
                TempData["Success"] = "El producto se creo correctamente.";
                return RedirectToAction(nameof(Index));
            }

            vm.Categorias = await _context.Categorias.ToListAsync();
            vm.UnidadVentas = await _context.UnidadVentas.ToListAsync();
            TempData["Error"] = "Los datos Ingresados no son Validos.";
            return View(vm);
        }

        //Mostra formulario con datos actuales
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            //consultamos todas las Categorias de la tabla
            var vm = new NuevoProductoViewModel
            {
                Producto = await _context.Productos.FindAsync(id),
                Categorias = await _context.Categorias.ToListAsync(),
                UnidadVentas = await _context.UnidadVentas.ToListAsync()
            };
            
            return View(vm);
        }
        //2, Procesar los cambios (POST) Editar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Producto producto)
        {
            if(id != producto.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto); //Prepara el objeto en memoria
                    await _context.SaveChangesAsync(); //Guarda en SQL Server
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Productos.Any(e => e.Id == producto.Id)) return NotFound();
                    else throw;
                }
                TempData["Success"] = "El producto se Guardo con EXITO.";
                return RedirectToAction(nameof(Index)); //redirige a index
            }
            var vm = new NuevoProductoViewModel
            {
                Producto = producto,
                Categorias = await _context.Categorias.ToListAsync(),
                UnidadVentas = await _context.UnidadVentas.ToListAsync()
            };
            TempData["Error"] = "Los datos ingresados no son validos.";
            return View(vm); //Si hay un error devuelve el formulario con los datos
        }

        //ELIMINAR PRODUCTO
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            //// Validación de negocio ===ADAPTARLO Y MODIFICAR TABLA VENTADETALLES O PRODUCTOS===
            //bool tieneProductos = await _context.Productos
            //    .AnyAsync(p => p.UnidadVentaId == id);

            //if (tieneProductos)
            //{
            //    TempData["Error"] = "No se puede eliminar porque tiene productos asociados.";
            //    return RedirectToAction(nameof(Index));
            //}

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Producto eliminado correctamente.";

            return RedirectToAction(nameof(Index));
        }
    }
}
