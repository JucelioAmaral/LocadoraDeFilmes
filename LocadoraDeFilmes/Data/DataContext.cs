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
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{


        //    modelBuilder.Entity<Locacao>()
        //                .HasKey(AD => new { AD.IdCliente, AD.IdFilme });

        //    //modelBuilder.Entity<Filme>()
        //    //        .HasData(new List<Filme>(){
        //    //        new Filme(1,"Filme A",18, 1),
        //    //        new Filme(2, "Filme B", 30, 1),
        //    //        new Filme(3, "Filme C", 16, 1),

        //    //});
        //    //modelBuilder.Entity<Cliente>()
        //    //    .HasData(new List<Cliente>(){
        //    //        new Cliente(1,"João","111.222.333-44", DateTime.Now),
        //    //        new Cliente(2, "Maria","111.222.333-44",DateTime.Now ),
        //    //        new Cliente(3, "Ana", "111.222.333-44", DateTime.Now),

        //    //});

        //    //modelBuilder.Entity<Locacao>()
        //    //    .HasData(new List<Locacao>(){
        //    //        new Locacao(1, 1, 1, DateTime.Now, DateTime.Now.AddDays( + 1)),
        //    //        new Locacao(2, 2, 3, DateTime.Now, DateTime.Now.AddDays( + 2)),

        //    //});


        //   }
    }
}
