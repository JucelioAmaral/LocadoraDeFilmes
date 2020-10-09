using LocadoraDeFilmes.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace LocadoraDeFilmes.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Filme> tblFilme { get; set; }
        public DbSet<Cliente> tblCliente { get; set; }
        public DbSet<Locacao> tblLocacao { get; set; }
        public object Locacoes { get; internal set; }
    }
}
