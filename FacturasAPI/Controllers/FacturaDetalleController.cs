using FacturasAPI.Entidad;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FacturasAPI.Controllers
{
    [ApiController]
    [Route("api/facturas/detalle")]
    public class FacturaDetalleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FacturaDetalleController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("listado")]
        public async Task<ActionResult<List<FacturaDetalle>>> Get()
        {
            try
            {
                return await _context.FacturasDetalle.ToListAsync();
            }
            catch (Exception ex)
            {
                return BadRequest("Ha ocurrido un error " + ex.Message);
            }
        }

        [HttpPost]
        [Route("crear")]
        public async Task<ActionResult> Post(FacturaDetalle facturaDetalle)
        {
            try
            {
                var existeFacturaDetalle = await _context.FacturasDetalle.AnyAsync(x => x.IdFacturaDetalle == facturaDetalle.IdFacturaDetalle);

                if (existeFacturaDetalle)
                {
                    return BadRequest("Ya existe una factura con el mismo id");
                }

                _context.FacturasDetalle.Add(facturaDetalle);

                facturaDetalle.SubtotalProducto = facturaDetalle.Cantidad * facturaDetalle.PrecioUnitario;

                var facturaCabecera = await _context.FacturasCabecera.FindAsync(facturaDetalle.IdFacturaCabecera);
                if (facturaCabecera != null)
                {
                    facturaCabecera.Subtotal += facturaDetalle.SubtotalProducto;

                    facturaCabecera.Iva = 0.12m;

                    facturaCabecera.TotalFactura = facturaCabecera.Subtotal + (facturaCabecera.Subtotal * facturaCabecera.Iva);
                }

                await _context.SaveChangesAsync();

                return new CreatedAtRouteResult("obtenerFacturaDetalle", new { id = facturaDetalle.IdFacturaDetalle }, facturaDetalle);
            }
            catch (Exception ex)
            {
                return BadRequest("Ha ocurrido un error " + ex.Message);
            }
        }


    }
}
