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
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DateTime time = DateTime.Now;
            DateTime timeDate;
            string timeNow;
            timeNow = time.ToString("yyyy-MM-dd HH:mm tt");
            //me chilla el timNow y lo intento parsear a dateTime
            timeDate=Convert.ToDateTime(timeNow);



            //modelBuilder.Entity<Cuenta>().HasData(new Cuenta(1,"Santander",1000,"juan@gmail.com")); no tengo creado el constructor, lo creo para introducir datos??
            modelBuilder.Entity<Usuario>().HasData(new Usuario("juan@gmail.com", "juan", "lujan", 33));
            modelBuilder.Entity<Evento>().HasData(new Evento(1,"valencia","espanyol",timeDate));
            modelBuilder.Entity<Mercado>().HasData(new Mercado(1, 2.5, 2.2, 1.8, 221, 143, 1));
            modelBuilder.Entity<Apuesta>().HasData(new Apuesta(1, 1.5, "over", 1.9, 25, timeDate,"juan@gmail.com",1));
        }
    }
}