using LocadoraDeFilmes.Data;
using LocadoraDeFilmes.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraDeFilmes.Controllers
{
    public class LocacaoController : ControllerBase
    {
        [HttpGet]
        [Route("GetLocacao")]
        public async Task<List<Locacao>> GetLocacao([FromServices] DataContext context)
        {
            return context.tblLocacao.ToList();
        }

        [HttpPost]
        [Route("AddLocacao")]
        public async Task<ActionResult<Locacao>> AddLocacao([FromServices] DataContext context, [FromBody] Locacao model)
        {
            DateTime dataDevolucao;

            if (ModelState.IsValid)
            {
                context.tblLocacao.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("RemoveLocacao/{id}")]
        public async Task RemoveLocacao([FromServices] DataContext context, [FromRoute] int Id)
        {
            try
            {
                var filme = context.tblLocacao.FirstOrDefault(e => e.Id == Id);
                context.tblLocacao.Remove(filme);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {

            }
        }


        [HttpPut]
        [Route("UpdateLocacao/{id}")]
        public async Task UpdateLocacao([FromServices] DataContext context, [FromRoute] int Id, [FromBody] Locacao model)
        {
            try
            {
                var locacao = context.tblLocacao.FirstOrDefault(e => e.Id == Id);
                locacao.IdCliente = model.IdCliente;
                locacao.IdFilme = model.IdFilme;
                locacao.DataLocaccao = model.DataLocaccao;

                context.tblLocacao.Update(locacao);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {

            }
        }
    }
}
