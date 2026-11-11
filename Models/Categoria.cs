using System.ComponentModel.DataAnnotations;

namespace VentasVG.Models
{
    public class Categoria
    {
        //Llave principal (c# lo detecta por el nombre)
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre es obligatorio")]
        [StringLength(50)]
        public string NombreCategoria { get; set; } = string.Empty;

        public ICollection<Producto>? Productos { get; set; }
    }
}
