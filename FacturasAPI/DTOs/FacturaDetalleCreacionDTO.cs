namespace FacturasAPI.DTOs
{
    public class FacturaDetalleCreacionDTO
    {
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public int ProductoId { get; set; }
        public int FacturaCabeceraId { get; set; }
    }
}
