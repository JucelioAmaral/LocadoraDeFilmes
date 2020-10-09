using LocadoraDeFilmes.Data;
using LocadoraDeFilmes.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraDeFilmes.Controllers
{
    public class FilmeController : ControllerBase
    {
        [HttpGet]
        [Route("GetFilme")]                

        public async Task<List<Filme>> GetFilme([FromServices] DataContext context)
        {
            return context.tblFilme.ToList();
        }

        [HttpPost]
        [Route("AddFilme")]
        public async Task<ActionResult<Filme>> AddFilme([FromServices] DataContext context, [FromBody] Filme model)
        {
            if (ModelState.IsValid)
            {
                context.tblFilme.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("RemoveFilme/{id}")]
        public async Task RemoveFilme([FromServices] DataContext context, [FromRoute] int Id)
        {
            try
            {
                var filme = context.tblFilme.FirstOrDefault(e => e.Id == Id);
                context.tblFilme.Remove(filme);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {

            }
        }

        [HttpPut]
        [Route("UpdateFilme/{id}")]
        public async Task UpdateFilme([FromServices] DataContext context, [FromRoute] int Id, [FromBody] Filme model)
        {
            try
            {
                var filme = context.tblFilme.FirstOrDefault(e => e.Id == Id);
                filme.Titulo = model.Titulo;
                filme.ClassificacaoIndicativa = model.ClassificacaoIndicativa;
                filme.Lancamento = model.Lancamento;

                context.tblFilme.Update(filme);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {

            }
        }
    }
}
