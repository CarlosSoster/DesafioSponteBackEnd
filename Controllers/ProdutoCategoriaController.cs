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
    [Route("v1/produtocategoria")]
    [Authorize]
    public class ProdutoCategoriaController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<ProdutoCategoria>>> Get([FromServices] DataContext context)
        {
            var produtoCategorias = await context.ProdutoCategorias.ToListAsync();
            return produtoCategorias;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<ProdutoCategoria>> Post(
            [FromServices] DataContext context,
            [FromBody] ProdutoCategoria model)
        {
            if (ModelState.IsValid)
            {
                context.ProdutoCategorias.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [Route("")]
        [HttpDelete]
        public ProdutoCategoria Delete(
            [FromServices] DataContext context,
            [FromBody] ProdutoCategoria model)
        {
             context.ProdutoCategorias.Remove(model);
             context.SaveChanges();

             return model;
        }
    }
}