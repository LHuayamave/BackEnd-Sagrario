using AutoMapper;
using FacturasAPI.DTOs;
using FacturasAPI.Entidad;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FacturasAPI.Controllers
{
    [ApiController]
    [Route("api/facturas/detalle")]
    public class FacturaDetalleController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public FacturaDetalleController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpGet("{id:int}", Name = "obtenerFacturaDetalle")]
        public async Task<ActionResult<FacturaDetalleDTO>> Get(int id)
        {
            var facturaDetalle = context.FacturasDetalle
                .Include(x => x.FacturaDetalleProductos)
                .Include(x => x.FacturaCabecera)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (facturaDetalle == null)
            {
                return NotFound();
            }

            var facturaDetalleDTO = mapper.Map<FacturaDetalleDTO>(facturaDetalle);
            return facturaDetalleDTO;
        }

        [HttpPost]
        public async Task<ActionResult<FacturaDetalleCreacionDTO>> Post(FacturaDetalleCreacionDTO facturaDetalleDTO)
        {
            var facturaDetalle = mapper.Map<FacturaDetalle>(facturaDetalleDTO);
            var producto = context.Productos.FirstOrDefault(p => p.Id == facturaDetalleDTO.ProductoId);
            try
            {
                if (producto == null)
                {
                    return BadRequest("El producto especificado no existe.");
                }

                var facturaCabecera = context.FacturasCabecera.FirstOrDefault(fc => fc.IdFactura == facturaDetalleDTO.FacturaCabeceraId);
                if (facturaCabecera == null)
                {
                    return BadRequest("La factura especificada no existe.");
                }

                facturaDetalle.FacturaCabecera = facturaCabecera;

                context.FacturasDetalle.Add(facturaDetalle);
                await context.SaveChangesAsync();

                var productoDetalle = new FacturaDetalleProducto { Producto = producto, FacturaDetalle = facturaDetalle };

                await context.SaveChangesAsync();


                facturaCabecera.Total = context.FacturasDetalle
                    .Where(fd => fd.Id == facturaDetalleDTO.FacturaCabeceraId)
                    .Sum(fd => fd.PrecioUnitario * fd.Cantidad);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Get), new { id = facturaDetalle.Id }, facturaDetalleDTO);
        }
    }
}
