using LocadoraDeFilmes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraDeFilmes.Repository
{
    public interface IRelatoriosRepository
    {
        public IEnumerable<Filme> GetTop5FilmesAlugados();

        public IEnumerable<Filme> GetTop3FilmesMenosAlugados();

        public IEnumerable<Cliente> GetSegundoClienteMaisAlugou();
    }
}
