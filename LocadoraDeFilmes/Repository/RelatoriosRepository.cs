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

        public IEnumerable<Filme> GetTop5FilmesAlugados()
        {
            using var connection = new SqlConnection(_connectionString);
            var data = connection.Query<Filme>("SELECT * FROM tblFilme WHERE id in(select top 5 IdFilme FROM tblLocacao WHERE DataLocaccao BETWEEN DATEADD(Year,-1,GETDATE()) AND GetDATE() group by IdFilme having COUNT(IdFilme) > 0)");
            return data;
        }

        public IEnumerable<Filme> GetTop3FilmesMenosAlugados()
        {
            using var connection = new SqlConnection(_connectionString);
            var data = connection.Query<Filme>("SELECT * FROM tblFilme WHERE id in(select top 3 IdFilme FROM tblLocacao WHERE DataLocaccao BETWEEN DATEADD(Year,-1,GETDATE()) AND GetDATE() group by IdFilme having COUNT(IdFilme) > 0 order by IdFilme desc)");
            return data;
        }


        public IEnumerable<Cliente> GetSegundoClienteMaisAlugou()
        {
            using var connection = new SqlConnection(_connectionString);
            var data = connection.Query<Cliente>("SELECT * FROM tblCliente WHERE id in( select top 2  IdCliente FROM tblLocacao WHERE DataLocaccao BETWEEN DATEADD(Year,-1,GETDATE()) AND GetDATE() group by IdCliente having COUNT(IdCliente) > 0 )");
            return data;
        }
    }
}
