using LocadoraDeFilmes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraDeFilmes.Repository
{
    public interface IRelatoriosRepository
    {
        public IEnumerable<Filme> GetTopFilmesAlugados();

        public IEnumerable<Filme> GetTopFilmesMenosAlugados();

        public IEnumerable<Cliente> GetSegundoClienteMaisAlugou();
    }
}
