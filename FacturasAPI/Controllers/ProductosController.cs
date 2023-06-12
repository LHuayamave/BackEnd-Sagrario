using FacturasAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using FacturasAPI.Entidad;

namespace FacturasAPI.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ProductosController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductoDTO>>> Get()
        {
            var productos = await context.Productos.ToListAsync();
            return mapper.Map<List<ProductoDTO>>(productos);
        }

        [HttpGet("{id:int}", Name = "obtenerProducto")]
        public async Task<ActionResult<ProductoDTO>> Get(int id)
        {
            var producto = await context.Productos.FirstOrDefaultAsync(x => x.Id == id);
            if (producto == null)
            {
                return NotFound();
            }
            return mapper.Map<ProductoDTO>(producto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductoCreacionDTO productoCreacion)
        {
            var existeProductoConElMismoNombre = await context.Productos.AnyAsync(x => x.Nombre == productoCreacion.Nombre);
            if (existeProductoConElMismoNombre)
            {
                return BadRequest($"Ya existe un producto con el nombre{productoCreacion.Nombre}");
            }

            var producto = mapper.Map<Producto>(productoCreacion);
            try
            {
                context.Add(producto);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            var productoDTO = mapper.Map<ProductoDTO>(producto);
            return CreatedAtRoute("obtenerProducto", new { id = producto.Id }, productoDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductoCreacionDTO productoActualizacion)
        {
            var existeProducto = await context.Productos.AnyAsync(x => x.Id == id);
            if (!existeProducto)
            {
                return NotFound();
            }
            var producto = mapper.Map<Producto>(productoActualizacion);
            producto.Id = id;
            try
            {
                context.Update(producto);
                await context.SaveChangesAsync();
            }catch (Exception ex)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existeProducto = await context.Productos.AnyAsync(x => x.Id == id);
            if (!existeProducto)
            {
                return NotFound();
            }
            try
            {
                context.Remove(new Producto() { Id = id });
                await context.SaveChangesAsync();
            }catch(Exception ex)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
