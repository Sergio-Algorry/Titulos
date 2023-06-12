using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Titulos.BData.Data;
using Titulos.BData.Data.Entity;

namespace Titulos.Server.Controllers
{
    [ApiController]
    [Route("api/Profesiones")]
    public class ProfesionesController : ControllerBase
    {
        private readonly Context context;

        public ProfesionesController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Profesion>>> Get()
        {
            return await context.Profesiones.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Profesion profesion)
        {
            context.Add(profesion);
            await context.SaveChangesAsync();
            return profesion.Id;
        }
    }
}
