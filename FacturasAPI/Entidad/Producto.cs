using FacturasAPI.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace FacturasAPI.Entidad
{
    public class Producto
    {
        public int Id { get; set; }
        [Required]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }
        [Required]
        public double PrecioUnitario { get; set; }
        public List<FacturaDetalleProducto> FacturaDetalleProductos { get; set; }
    }
}
