namespace FacturasAPI.DTOs
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double PrecioUnitario { get; set; }
        public List<FacturaDetalleDTO> FacturaDetalle { get; set; }
    }
}
