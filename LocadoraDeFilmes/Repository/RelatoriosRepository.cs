using Dapper;
using LocadoraDeFilmes.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraDeFilmes.Repository
{
    public class RelatoriosRepository : IRelatoriosRepository
    {
        private readonly string _connectionString;

        public RelatoriosRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        public IEnumerable<Filme> GetTopFilmesAlugados()
        {
            using var connection = new SqlConnection(_connectionString);
            var data = connection.Query<Filme>("select * from tblFilme where id in(select top 5 IdFilme from tblLocacao where DataLocaccao BETWEEN DATEADD(Year,-1,GETDATE()) AND GetDATE() group by IdFilme having COUNT(IdFilme) > 0)");
            return data;
        }

        public IEnumerable<Filme> GetTopFilmesMenosAlugados()
        {
            using var connection = new SqlConnection(_connectionString);
            var data = connection.Query<Filme>("select * from tblFilme where id in(select top 3 IdFilme from tblLocacao where DataLocaccao BETWEEN DATEADD(Year,-1,GETDATE()) AND GetDATE() group by IdFilme having COUNT(IdFilme) > 0 order by IdFilme desc)");
            return data;
        }


        public IEnumerable<Cliente> GetSegundoClienteMaisAlugou()
        {
            using var connection = new SqlConnection(_connectionString);
            var data = connection.Query<Cliente>("select * from tblCliente where id in( select top 2  IdCliente from tblLocacao where DataLocaccao BETWEEN DATEADD(Year,-1,GETDATE()) AND GetDATE() group by IdCliente having COUNT(IdCliente) > 0 )");
            return data;
        }
    }
}
