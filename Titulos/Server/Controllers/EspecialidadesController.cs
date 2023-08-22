using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Titulos.BData.Data;
using Titulos.BData.Data.Entity;
using Titulos.Shared.DTO;

namespace Titulos.Server.Controllers
{
    [ApiController]
    [Route("api/Especialidades")]
    public class EspecialidadesController : ControllerBase
    {
        private readonly Context context;

        public EspecialidadesController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Especialidad>>> Get()
        {
            var pepe = await context.Especialidades.ToListAsync();
            if (pepe == null || pepe.Count == 0)
            {
                return BadRequest("No existen especialidades");
            }
            return pepe;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Especialidad>> Get(int id)
        {
            var existe = await context.Especialidades.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"La Especialidad {id} no existe");
            }
            return await context.Especialidades.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(EspecialidadDTO entidad)
        {
            try
            {
                //var prof = await context.Profesiones.FirstOrDefaultAsync(prof => 
                //                                    prof.Id == entidad.ProfesionId);

                //if (prof == null)
                //{
                //    return BadRequest($"La profesion elegida {entidad.ProfesionId} no existe");
                //}

                var existe = await context.Profesiones.AnyAsync(x => x.Id == entidad.ProfesionId);
                if (!existe)
                {
                    return NotFound($"La profesión de id={entidad.ProfesionId} no existe");
                }

                Especialidad pepe = new Especialidad();

                pepe.ProfesionId = entidad.ProfesionId;
                pepe.CodEspecialidad = entidad.CodEspecialidad;
                pepe.DescEspecialidad = entidad.DescEspecialidad;

                await context.AddAsync(pepe);
                await context.SaveChangesAsync();
                return pepe.Id;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id:int}")] 
        public async Task<ActionResult> Put(Especialidad entidad, int id)
        {
            if (id != entidad.Id)
            {
                return BadRequest("El id de la Especialidad no corresponde.");
            }

            var existe = await context.Especialidades.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"La Especialidad de id={id} no existe");
            }

            context.Update(entidad);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Especialidades.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"La Especialidad de id={id} no existe");
            }
            Especialidad pepe = new Especialidad();
            pepe.Id = id;

            context.Remove(pepe);

            await context.SaveChangesAsync();

            return Ok();
        }

    }
}
