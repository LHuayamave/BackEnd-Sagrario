using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FacturasAPI.Entidad;

namespace FacturasAPI.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("listado")]
        public async Task<ActionResult<List<Producto>>> Get()
        {
            try
            {
                return await _context.Productos
                    .Include(x => x.FacturaDetalle)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                return BadRequest("Ha ocurrido un error " + ex.Message);
            }
        }

        [HttpGet(Name = "obtenerProducto")]
        [Route("obtener/{id:int}")]
        public async Task<ActionResult<Producto>> Get(int id)
        {
            try
            {
                var producto = await _context.Productos
                    .Include(x => x.FacturaDetalle)
                    .FirstOrDefaultAsync(x => x.IdProducto == id);
                if (producto == null)
                {
                    return NotFound();
                }
                return producto;
            }
            catch (Exception ex)
            {
                return BadRequest("Ha ocurrido un error " + ex.Message);
            }
        }


        [HttpPost]
        [Route("crear")]
        public async Task<ActionResult> Post(Producto producto)
        {
            try
            {
                var existeProducto = await _context.Productos.AnyAsync(x => x.IdProducto == producto.IdProducto);

                if (existeProducto)
                {
                    return BadRequest("El producto ya existe");
                }

                _context.Add(producto);
                await _context.SaveChangesAsync();
                return new CreatedAtRouteResult("obtenerProducto", new { id = producto.IdProducto }, producto);
            }
            catch (Exception ex)
            {
                return BadRequest("Ha ocurrido un error " + ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Producto producto, int id)
        {
            try
            {
                var existeProducto = await _context.Productos.AnyAsync(x => x.IdProducto == id);
                if (!existeProducto)
                {
                    return NotFound();
                }

                if (id != producto.IdProducto)
                {
                    return BadRequest("Los IDs no coinciden");
                }

                _context.Update(producto);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Ha ocurrido un error " + ex.Message);
            }
        }

        [HttpDelete]
        [Route("eliminar/{id:int}")]
        public async Task<ActionResult> Delete (int id)
        {
            try
            {
                var producto = await _context.Productos.FirstOrDefaultAsync(x => x.IdProducto == id);
                if (producto == null)
                {
                    return NotFound();
                }
                _context.Productos.Remove(producto);
                await _context.SaveChangesAsync();
                return Ok();

            } catch (Exception ex)
            {
                return BadRequest("Ha ocurrido un error " + ex.Message);
            }
        }
    }
}
