
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VentasVG.Models;

namespace VentasVG.Data
{
    public class ApplicationDbContext : DbContext
    {
        //Importara muchas funciones de EntityCore
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<VentaDetalle> VentaDetalles { get; set; } 
        public DbSet<Categoria> Categorias { get; set; } 
        public DbSet<UnidadVenta> UnidadVentas { get; set; } 
    }
}

