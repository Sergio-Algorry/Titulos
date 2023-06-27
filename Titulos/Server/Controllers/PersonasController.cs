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

        [HttpPost]
        public async Task<ActionResult<int>> Post(Persona persona)
        {
            context.Add(persona);
            await context.SaveChangesAsync();
            return persona.Id;
        }
    }
}
