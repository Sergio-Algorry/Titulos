using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Titulos.BData.Data;
using Titulos.BData.Data.Entity;

namespace Titulos.Server.Controllers
{
    [ApiController]
    [Route("api/personas")]
    public class PersonasController : ControllerBase
    {
        private readonly Context context;

        public PersonasController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Persona>>> Get()
        {
            return await context.Personas.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Persona>> Get(int id)
        {
            var existe = await context.Personas.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"La persona {id} no existe");
            }
            return await context.Personas.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Persona persona)
        {
            context.Add(persona);
            await context.SaveChangesAsync();
            return persona.Id;
        }

        [HttpPut("{id:int}")] 
        public async Task<ActionResult> Put(Persona entidad, int id)
        {
            if (id != entidad.Id)
            {
                return BadRequest("El id de la Persona no corresponde.");
            }

            var existe = await context.Personas.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"La Personas de id={id} no existe");
            }

            context.Update(entidad);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Personas.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"La Persona de id={id} no existe");
            }
            Persona pepe = new Persona();
            pepe.Id = id;

            context.Remove(pepe);

            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
