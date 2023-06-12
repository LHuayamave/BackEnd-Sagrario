using AutoMapper;
using FacturasAPI.DTOs;
using FacturasAPI.Entidad;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FacturasAPI.Controllers
{
    [ApiController]
    [Route("api/facturas/cabecera")]
    public class FacturaCabeceraController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public FacturaCabeceraController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet("{id:int}", Name = "obtenerFacturaCabecera")]
        public async Task<ActionResult<FacturaCabeceraDTO>> Get(int id)
        {
            var facturaCabecera = await context.FacturasCabecera
                .Include(x => x.FacturaDetalle)
                .FirstOrDefaultAsync(x => x.IdFactura == id);
            if (facturaCabecera == null)
            {
                return NotFound();
            }
         
            var facturaCabeceraDTO = mapper.Map<FacturaCabeceraDTO>(facturaCabecera);   
            return facturaCabeceraDTO;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] FacturaCabeceraCreacionDTO facturaCabeceraCreacion)
        {
            var facturaCabecera = mapper.Map<FacturaCabecera>(facturaCabeceraCreacion);
            try
            {
                context.FacturasCabecera.Add(facturaCabecera);
                await context.SaveChangesAsync();
            } 
            catch (Exception ex)
            {
                return BadRequest();
            }
            var facturaCabeceraDTO = mapper.Map<FacturaCabeceraDTO>(facturaCabecera);
            return new CreatedAtRouteResult("obtenerFacturaCabecera", new { id = facturaCabecera.IdFactura }, facturaCabeceraDTO);
        }
    }
}
