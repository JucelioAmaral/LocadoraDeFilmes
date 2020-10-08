using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraDeFilmes.Entities
{
    public class Locacao
    {
        public Locacao()
        {
        }
        public Locacao(int idLocacao, int idCliente, int idFilme, DateTime dataLocaccao, DateTime? dataDevolucao)
        {
            Id = idLocacao;
            IdCliente = idCliente;
            IdFilme = idFilme;
            DataLocaccao = dataLocaccao;
            DataDevolucao = dataDevolucao;
        }

        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdFilme { get; set; }
        public DateTime DataLocaccao { get; set; }
        public DateTime? DataDevolucao { get; set; }

    }
}
