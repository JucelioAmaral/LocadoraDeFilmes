using LocadoraDeFilmes.Data;
using LocadoraDeFilmes.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraDeFilmes.Controller

{
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        [Route("GetClient")]

        public async Task<List<Cliente>> GetCliente([FromServices] DataContext context)
        {
            return context.tblCliente.ToList();
        }

        [HttpPost]
        [Route("AddCliente")]
        public async Task<ActionResult<Cliente>> AddCliente([FromServices] DataContext context, [FromBody] Cliente modelCliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.tblCliente.Add(modelCliente);
                    await context.SaveChangesAsync();
                    return modelCliente;
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch(Exception e)
            {
                return null;
            }
        }
        [HttpDelete]
        [Route("RemoveCLiente/{Id}")]
        public async Task RemoveCLiente([FromServices] DataContext context, [FromRoute] int Id)
        {
            try
            {
                var filme = context.tblCliente.FirstOrDefault(e => e.Id == Id);
                context.tblCliente.Remove(filme);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {

            }
        }
        [HttpPut]
        [Route("UpdateCliente/{Id}")]
        public async Task UpdateCliente([FromServices] DataContext context, [FromRoute] int Id, [FromBody] Cliente modelCliente)
        {
            try
            {
                var cliente = context.tblCliente.FirstOrDefault(e => e.Id == Id);
                cliente.Nome = modelCliente.Nome;
                cliente.CPF = modelCliente.CPF;
                cliente.DataDeNasc = modelCliente.DataDeNasc;

                context.tblCliente.Update(cliente);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {

            }

        }
    }
}
