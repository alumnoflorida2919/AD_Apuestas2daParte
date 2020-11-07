using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class PlaceMyBetContext : DbContext
    {
        public DbSet<Cuenta> Cuenta { get; set; } //Taula
        public DbSet<Usuario> Usuario { get; set; } //Taula
        public DbSet<Apuesta> Apuesta { get; set; } //Taula
        public DbSet<Mercado> Mercado { get; set; } //Taula
        public DbSet<Evento> Evento { get; set; } //Taula

        public PlaceMyBetContext()
        {
        }

        public PlaceMyBetContext(DbContextOptions options)
        : base(options)
        {
        }

        //Mètode de configuració
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=127.0.0.1;Port=3306;Database=placemybet_2;uid=root;pwd=;Convert Zero Datetime=true;SslMode=none");//màquina retos

            }
        }

        //Inserció inicial de dades
        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grupo>().HasData(new Grupo(1, "Iron Maiden"));
            modelBuilder.Entity<Grupo>().HasData(new Grupo(2, "Gamma Ray"));
            modelBuilder.Entity<Grupo>().HasData(new Grupo(3, "Stratovarius"));
            modelBuilder.Entity<Disco>().HasData(new Disco(1, "The number of the beast", 1982, 1));
            modelBuilder.Entity<Disco>().HasData(new Disco(2, "Land of the free", 1998, 2));
        }*/
    }
}