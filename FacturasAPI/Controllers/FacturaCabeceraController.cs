using FacturasAPI.Entidad;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FacturasAPI.Controllers
{
    [ApiController]
    [Route("api/facturas/cabecera")]
    public class FacturaCabeceraController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FacturaCabeceraController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("listado")]
        public async Task<ActionResult<List<FacturaCabecera>>> Get()
        {
            try
            {
                return await _context.FacturasCabecera
                    .Include(x => x.FacturaDetalle)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                return BadRequest("Ha ocurrido un error " + ex.Message);
            }
        }

        [HttpGet]
        [Route("obtener/{id:int}", Name = "obtenerFacturaCabecera")]
        public async Task<ActionResult<FacturaCabecera>> Get(int id)
        {
            try
            {
                var facturaCabecera = await _context.FacturasCabecera
                    .Include(x => x.FacturaDetalle)
                    .FirstOrDefaultAsync(x => x.IdFacturaCabecera == id);
                if (facturaCabecera == null)
                {
                    return NotFound();
                }
                return facturaCabecera;
            }
            catch (Exception ex)
            {
                return BadRequest("Ha ocurrido un error " + ex.Message);
            }
        }

        [HttpPost]
        [Route("crear")]
        public async Task<ActionResult> Post(FacturaCabecera facturaCabecera)
        {
            try
            {
                var existeFacturaCabecera = await _context.FacturasCabecera.AnyAsync(x => x.IdFacturaCabecera == facturaCabecera.IdFacturaCabecera);

                if (existeFacturaCabecera)
                {
                    return BadRequest("Ya existe una factura con el mismo id");
                }

                _context.FacturasCabecera.Add(facturaCabecera);
                await _context.SaveChangesAsync();

                return new CreatedAtRouteResult("obtenerFacturaCabecera", new { id = facturaCabecera.IdFacturaCabecera }, facturaCabecera);
            }
            catch (Exception ex)
            {
                return BadRequest("Ha ocurrido un error " + ex.Message);
            }
        }


    }
}
