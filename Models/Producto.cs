using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace VentasVG.Models
{
    public class Producto
    {
        //Llave principal (c# lo detecta por el nombre)
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre es obligatorio")]
        [StringLength(100)]
        public string NombreProducto { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Precio es obligatorio")]
        [Precision(18, 2)]
        public decimal Precio { get; set; }

        //Relaciones FK
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; } 

        public int UnidadVentaId { get; set; }
        public UnidadVenta? UnidadVenta { get; set; } 

        //Navegacion
        public ICollection<VentaDetalle> VentaDetalles { get; set; }
        = new List<VentaDetalle>();
    }
}
