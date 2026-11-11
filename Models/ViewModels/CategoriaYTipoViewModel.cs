using VentasVG.Models;

namespace VentasVG.Models.ViewModels
{
    public class CategoriaYTipoViewModel
    {
        public List<Categoria> Categorias { get; set; } = new();
        public List<UnidadVenta> UnidadVentas { get; set; } = new();
    }
}
