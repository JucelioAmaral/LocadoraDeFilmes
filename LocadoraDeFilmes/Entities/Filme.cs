using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraDeFilmes.Entities
{
    public class Filme
    {
        public Filme()
        {

        }
        public Filme(int idFilme, string titulo, int classficacaoIndicativa, byte lancamento)
        {
            Id = idFilme;
            Titulo = titulo;
            ClassificacaoIndicativa = classficacaoIndicativa;
            Lancamento = lancamento;
        }
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Titulo { get; set; }

        [Required]
        public int ClassificacaoIndicativa { get; set; }

        public Byte Lancamento { get; set; } = 0;

        public IEnumerable<Filme> Filmes { get; set; }
    }
}
