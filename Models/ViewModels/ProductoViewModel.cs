namespace VentasVG.Models.ViewModels
{
    public class ProductoViewModel
    {
        public List<Producto> Productos { get; set; } = new();
        public List<Categoria> Categorias { get; set; } = new();
        public List<UnidadVenta> UnidadVentas { get; set; } = new();
    }
}
