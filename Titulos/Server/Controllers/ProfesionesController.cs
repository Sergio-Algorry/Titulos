﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Profesion>> Get(int id)
        {
            var existe = await context.Profesiones.AnyAsync(x => x.Id == id);
            if (!existe)
            {
               return NotFound($"La profesión de id={id} no existe");
            }
           return  await context.Profesiones.FirstOrDefaultAsync(prof => prof.Id == id);
        }

        [HttpGet("{cod}")] // api/profesiones/arq
        public async Task<ActionResult<Profesion>> Get(string cod)
        {
            var existe = await context.Profesiones.AnyAsync(x => x.CodProfesion == cod);
            if (!existe)
            {
                return NotFound($"La profesión de id={cod} no existe");
            }
            return await context.Profesiones.FirstOrDefaultAsync(prof => prof.CodProfesion == cod);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post(Profesion profesion)
        {
            context.Add(profesion);
            await context.SaveChangesAsync();
            return profesion.Id;
        }

        [HttpPut("{id:int}")] // api/profesiones/2
        public async Task<ActionResult> Put(Profesion profesion, int id )
        {
            if (id != profesion.Id)
            {
                return BadRequest("El id de la profesion no corresponde.");
            }

            var existe = await context.Profesiones.AnyAsync(x => x.Id == id);
            if(!existe)
            {
                return NotFound($"La profesión de id={id} no existe");
            }

            context.Update(profesion);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Profesiones.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound($"La profesión de id={id} no existe");
            }

            context.Remove(new Profesion() { Id=id });
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
