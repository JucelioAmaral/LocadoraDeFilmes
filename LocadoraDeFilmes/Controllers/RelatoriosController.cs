using Dapper;
using LocadoraDeFilmes.Data;
using LocadoraDeFilmes.Entities;
using LocadoraDeFilmes.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace LocadoraDeFilmes.Controllers
{

    [Route("api/relatorios")]
    [ApiController]
    public class RelatoriosController : ControllerBase
    {
        private readonly ILogger<RelatoriosController> _logger;
        private readonly IRelatoriosRepository _relatoriosRepository;

        public RelatoriosController(ILogger<RelatoriosController> logger, IRelatoriosRepository relatoriosRepository)
        {
            _logger = logger;
            _relatoriosRepository = relatoriosRepository;
        }


        [HttpGet]
        [Route("GetClienteComAtraso")]
        public async Task<List<Cliente>> GetClienteComAtraso([FromServices] DataContext context)
        {
            int idClienteComAtraso = 0;
            bool foraDoPrazo = false;
            var listLocacaoes = context.tblLocacao.ToList();
            var clientes = new List<Cliente>();

            foreach (var locacao in listLocacaoes)
            {
                var filme = context.tblFilme.FirstOrDefault(f => f.Id == locacao.IdFilme);
                if (filme.Lancamento == 1)
                {
                    if ((locacao.DataLocaccao.AddDays(2) > DateTime.Now || locacao.DataDevolucao == null))
                    {
                        idClienteComAtraso = locacao.IdCliente;
                    }
                }
                else
                {
                    if ((locacao.DataLocaccao.AddDays(3) > DateTime.Now || locacao.DataDevolucao == null))
                    {
                        idClienteComAtraso = locacao.IdCliente;
                    }
                }
            }

            //return context.tblCliente.ToList();
            clientes = context.tblCliente.ToList();
            clientes.FirstOrDefault(c => c.Id == idClienteComAtraso);
            return clientes;            
        }


        [HttpGet]
        [Route("GetFilmesNuncaAlugados")]
        public async Task<List<Filme>> GetFilmesNuncaAlugados([FromServices] DataContext context)
        {
            var listFilmes = context.tblFilme.ToList();
            var FilmesNuncaAlugados = new List<Filme>();
            var locacoes = context.tblLocacao.ToList();


            foreach (var filme in listFilmes)
            {
                foreach (var locacao in locacoes)
                {
                    if (filme.Id != locacao.IdFilme)
                    {
                        FilmesNuncaAlugados.Add(filme);
                    }
                }
            }

            return FilmesNuncaAlugados;
        }


        [HttpGet]
        [Route("GetTop5FilmesAlugados")]
        public IActionResult GetTop5FilmesAlugados([FromServices] DataContext context)
        {

            var data = _relatoriosRepository.GetTop5FilmesAlugados();
            return Ok(data);
        }

        [HttpGet]
        [Route("GetTop3FilmesMenosAlugados")]
        public IActionResult GetTop3FilmesMenosAlugados([FromServices] DataContext context)
        {

            var data = _relatoriosRepository.GetTop3FilmesMenosAlugados();
            return Ok(data);
        }

        [HttpGet]
        [Route("GetSegundoClienteMaisAlugou")]
        public IActionResult GetSegundoClienteMaisAlugou([FromServices] DataContext context)
        {

            var data = _relatoriosRepository.GetSegundoClienteMaisAlugou();
            return Ok(data.Skip(1));
        }
    }
}
