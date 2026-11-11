namespace VentasVG.Models.ViewModels
{
    public class NuevoProductoViewModel
    {
        public Producto Producto { get; set; } = new();
        public List<Categoria> Categorias { get; set; } = new();
        public List<UnidadVenta> UnidadVentas { get; set; } = new();
    }
}
