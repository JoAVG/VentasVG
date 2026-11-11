using System.ComponentModel.DataAnnotations;

namespace VentasVG.Models
{
    public class UnidadVenta
    {

        //Llave principal (c# lo detecta por el nombre)
        public int Id { get; set; }

        [Required(ErrorMessage = "El Tipo de Unidad es obligatorio")]
        [StringLength(50)]
        public string TipoUnidad { get; set; } = string.Empty;

        public ICollection<Producto>? Productos { get; set; }
    }
}
