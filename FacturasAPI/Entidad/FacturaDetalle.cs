using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FacturasAPI.Entidad
{
    public class FacturaDetalle
    {
        [Key]
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public FacturaCabecera FacturaCabecera { get; set; }
        public List<FacturaDetalleProducto> FacturaDetalleProductos { get; set; }
        public List<Producto> Producto { get; set; }
    }
}
