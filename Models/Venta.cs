using Microsoft.EntityFrameworkCore;

namespace VentasVG.Models
{
    public class Venta
    {
        //Llave principal (c# lo detecta por el nombre)
        public int Id { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        [Precision(18, 2)]
        public decimal Total { get; set; }

        public ICollection<VentaDetalle> Detalles { get; set; }
        = new List<VentaDetalle>();

    }
}
