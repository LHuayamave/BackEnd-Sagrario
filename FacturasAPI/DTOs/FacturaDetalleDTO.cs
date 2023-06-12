namespace FacturasAPI.DTOs
{
    public class FacturaDetalleDTO
    {
        public int Id { get; set; }
        public double PrecioUnitario { get; set; }
        public int Cantidad { get; set; }
        public int ProductoId { get; set; }
        public ProductoDTO ProductoDTO { get; set; }
        public int FacturaCabeceraId { get; set; }
        public FacturaCabeceraDTO FacturaCabeceraDTO { get; set; }
    }
}
