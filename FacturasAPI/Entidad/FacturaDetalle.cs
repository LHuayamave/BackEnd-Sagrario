using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FacturasAPI.Entidad
{
    public partial class FacturaDetalle
    {
        [Key]
        public int IdFacturaDetalle { get; set; }
        public int IdFacturaCabecera { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public double SubtotalProducto { get; set; }
        [JsonIgnore]
        public virtual FacturaCabecera FacturaCabecera { get; set; }
        [JsonIgnore]
        public virtual Producto Producto { get; set; }
    }
}
