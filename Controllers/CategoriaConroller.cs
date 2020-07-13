using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SponteBackEnd.Data;
using SponteBackEnd.Models;

namespace SponteBackEnd.Controllers
{
    [ApiController]
    [Route("v1/categorias")]
    [Authorize]
    public class CategoriaController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Categoria>>> Get([FromServices] DataContext context)
        {
            var categorias = await context.Categorias.ToListAsync();
            return categorias;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Categoria>> Post(
            [FromServices] DataContext context,
            [FromBody] Categoria model)
        {
            if (ModelState.IsValid)
            {
                context.Categorias.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("")]
        [HttpPut]
        public Categoria Put(
            [FromServices] DataContext context,
            [FromBody] Categoria model)
        {
             context.Entry<Categoria>(model).State = EntityState.Modified;
             context.SaveChanges();

             return model;
        }

        [Route("")]
        [HttpDelete]
        public Categoria Delete(
            [FromServices] DataContext context,
            [FromBody] Categoria model)
        {
             context.Categorias.Remove(model);
             context.SaveChanges();

             return model;
        }
    }
}