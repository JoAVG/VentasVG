using Microsoft.EntityFrameworkCore;

namespace VentasVG.Models
{
    public class VentaDetalle
    {
        //Llave principal (c# lo detecta por el nombre)
        public int Id { get; set; }

        // Llave foránea de Venta
        public int VentaId { get; set; }

        // Propiedad de navegación
        public Venta Venta { get; set; } = null!;

        // Llave foránea de Producto
        public int ProductoId { get; set; }

        // Propiedad de navegación
        public Producto Producto { get; set; } = null!;

        public int Cantidad { get; set; }

        [Precision(18, 2)]
        public decimal PrecioUnitario { get; set; }

        // No se guarda como columna porque solamente tiene get
        public decimal Subtotal => Cantidad * PrecioUnitario;
    }
}
