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
            int idClienteComAtraso;
            bool foraDoPrazo = false;
            var locacaoes = context.tblLocacao.ToList();
            var clientes = new List<Cliente>();

            foreach (var locacao in locacaoes)
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

            //clientes = context.Clientes.FirstOrDefault(c => c.Id == idClienteComAtraso);

            return context.tblCliente.ToList();
        }


        [HttpGet]
        [Route("GetFilmesNaoAlugados")]
        public async Task<List<Filme>> GetFilmesNaoAlugados([FromServices] DataContext context)
        {
            var filmes = context.tblFilme.ToList();
            var FilmesNaoAlugados = new List<Filme>();
            var locacoes = context.tblLocacao.ToList();


            foreach (var filme in filmes)
            {
                foreach (var locacao in locacoes)
                {
                    if (filme.Id != locacao.IdFilme)
                    {
                        FilmesNaoAlugados.Add(filme);
                    }
                }
            }

            return FilmesNaoAlugados;
        }


        [HttpGet]
        [Route("GetTopFilmesAlugados")]
        public IActionResult GetTopFilmesAlugados([FromServices] DataContext context)
        {

            var data = _relatoriosRepository.GetTopFilmesAlugados();
            return Ok(data);
        }

        [HttpGet]
        [Route("GetTopFilmesMenosAlugados")]
        public IActionResult GetTopFilmesMenosAlugados([FromServices] DataContext context)
        {

            var data = _relatoriosRepository.GetTopFilmesMenosAlugados();
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
