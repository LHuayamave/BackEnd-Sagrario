namespace FacturasAPI.Entidad
{
    public class FacturaDetalleProducto
    {
        public int FacturaDetalleId { get; set; }
        public FacturaDetalle FacturaDetalle { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        
    }
}
