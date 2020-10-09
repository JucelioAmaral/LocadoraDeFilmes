using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraDeFilmes.Entities
{
    public class Cliente
    {


        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nome { get; set; }
        
        [Required]
        [MaxLength(11)]
        public string CPF { get; set; }
        [Required]
        public DateTime DataDeNasc { get; set; }

        //public IEnumerable<Cliente> ListCLientes { get; set; }

        public Cliente()
        {

        }
        public Cliente(int idCliente, string nome, string cPF, DateTime dataDeNasc)
        {
            Id = idCliente;
            Nome = nome;
            CPF = cPF;
            DataDeNasc = dataDeNasc;
        }
    }
}
