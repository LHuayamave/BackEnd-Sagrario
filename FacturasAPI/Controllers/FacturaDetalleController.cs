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

        [HttpGet]
        [Route("obtener/{id:int}", Name = "obtenerFacturaDetalle")]
        public async Task<ActionResult<FacturaDetalle>> Get(int id)
        {
            try
            {
                var facturaDetalle = await _context.FacturasDetalle.FirstOrDefaultAsync(x => x.IdFacturaDetalle == id);
                if (facturaDetalle == null)
                {
                    return NotFound();
                }
                return facturaDetalle;
            }
            catch (Exception ex)
            {
                return BadRequest("Ha ocurrido un error " + ex.Message);
            }
        }

        [HttpPost]
        [Route("insertar")]
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
