using FacturasAPI.Entidad;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FacturasAPI.Controllers
{
    [ApiController]
    [Route("api/personas")]
    public class PersonaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PersonaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("listado")]
        public async Task<ActionResult<List<Persona>>> Get()
        {
            /*try
            {*/
                var result = await _context.Personas
                    .Include(x => x.FacturaCabecera)
                    .ThenInclude(x => x.FacturaDetalle)
                    .ToListAsync();
                return result;
            /*}
            catch (Exception ex)
            {
                return BadRequest("Ha ocurrido un error " + ex.Message);
            }*/

        }

        [HttpGet(Name = "obtenerPersona")]
        [Route("obtener/{id:int}")]
        public async Task<ActionResult<Persona>> Get(int id)
        {
            try
            {
                var persona = await _context.Personas
                    .Include(x => x.FacturaCabecera)
                    .FirstOrDefaultAsync(x => x.IdPersona == id);
                if (persona == null)
                {
                    return NotFound();
                }
                return persona;
            }
            catch (Exception ex)
            {
                return BadRequest("Ha ocurrido un error " + ex.Message);
            }

        }

        [HttpPost]
        [Route("crear")]
        public async Task<ActionResult> Post(Persona persona)
        {
            try
            {
                _context.Add(persona);
                await _context.SaveChangesAsync();
                return new CreatedAtRouteResult("obtenerPersona", new { id = persona.IdPersona }, persona);
            }
            catch (Exception ex)
            {
                return BadRequest("Ha ocurrido un error " + ex.Message);
            }

        }

        [HttpPut]
        [Route("actualizar/{id:int}")]
        public async Task<ActionResult> Put(int id, Persona persona)
        {
            try
            {
                if (id != persona.IdPersona)
                {
                    return BadRequest("Los id no coinciden");
                }

                _context.Update(persona);
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
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var persona = await _context.Personas.FirstOrDefaultAsync(x => x.IdPersona == id);
                if (persona == null)
                {
                    return NotFound();
                }

                _context.Remove(persona);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Ha ocurrido un error " + ex.Message);
            }
        }
    }
}
