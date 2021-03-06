﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlaceMyBet.Models;

namespace PlaceMyBet.Migrations
{
    [DbContext(typeof(PlaceMyBetContext))]
    [Migration("20201109162929_m1")]
    partial class m1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PlaceMyBet.Models.Apuesta", b =>
                {
                    b.Property<int>("ApuestaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Cuota")
                        .HasColumnType("double");

                    b.Property<double>("DineroApostado")
                        .HasColumnType("double");

                    b.Property<int>("MercadoId")
                        .HasColumnType("int");

                    b.Property<double>("MercadoOverUnder")
                        .HasColumnType("double");

                    b.Property<string>("TipoOverUnder")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ApuestaId");

                    b.HasIndex("MercadoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Apuesta");

                    b.HasData(
                        new
                        {
                            ApuestaId = 1,
                            Cuota = 1.8999999999999999,
                            DineroApostado = 25.0,
                            MercadoId = 1,
                            MercadoOverUnder = 1.5,
                            TipoOverUnder = "over",
                            UsuarioId = "juan@gmail.com",
                            fecha = new DateTime(2020, 11, 9, 17, 29, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("PlaceMyBet.Models.Cuenta", b =>
                {
                    b.Property<string>("CuentaId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("NombreBanco")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<double>("Saldo")
                        .HasColumnType("double");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("CuentaId");

                    b.HasIndex("UsuarioId")
                        .IsUnique();

                    b.ToTable("Cuenta");
                });

            modelBuilder.Entity("PlaceMyBet.Models.Evento", b =>
                {
                    b.Property<int>("EventoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("EquipoLocal")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("EquipoVisitante")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime(6)");

                    b.HasKey("EventoId");

                    b.ToTable("Evento");

                    b.HasData(
                        new
                        {
                            EventoId = 1,
                            EquipoLocal = "valencia",
                            EquipoVisitante = "espanyol",
                            Fecha = new DateTime(2020, 11, 9, 17, 29, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("PlaceMyBet.Models.Mercado", b =>
                {
                    b.Property<int>("MercadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("CuotaOver")
                        .HasColumnType("double");

                    b.Property<double>("CuotaUnder")
                        .HasColumnType("double");

                    b.Property<double>("DineroApostadoOver")
                        .HasColumnType("double");

                    b.Property<double>("DineroApostadoUnder")
                        .HasColumnType("double");

                    b.Property<int>("EventoId")
                        .HasColumnType("int");

                    b.Property<double>("OverUnder")
                        .HasColumnType("double");

                    b.HasKey("MercadoId");

                    b.HasIndex("EventoId");

                    b.ToTable("Mercado");

                    b.HasData(
                        new
                        {
                            MercadoId = 1,
                            CuotaOver = 2.2000000000000002,
                            CuotaUnder = 1.8,
                            DineroApostadoOver = 221.0,
                            DineroApostadoUnder = 143.0,
                            EventoId = 1,
                            OverUnder = 2.5
                        });
                });

            modelBuilder.Entity("PlaceMyBet.Models.Usuario", b =>
                {
                    b.Property<string>("UsuarioId")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Apellido")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("edad")
                        .HasColumnType("int");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuario");

                    b.HasData(
                        new
                        {
                            UsuarioId = "juan@gmail.com",
                            Apellido = "lujan",
                            Nombre = "juan",
                            edad = 33
                        });
                });

            modelBuilder.Entity("PlaceMyBet.Models.Apuesta", b =>
                {
                    b.HasOne("PlaceMyBet.Models.Mercado", "Mercado")
                        .WithMany("Apuestas")
                        .HasForeignKey("MercadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlaceMyBet.Models.Usuario", "Usuario")
                        .WithMany("Apuestas")
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("PlaceMyBet.Models.Cuenta", b =>
                {
                    b.HasOne("PlaceMyBet.Models.Usuario", "Usuario")
                        .WithOne("Cuenta")
                        .HasForeignKey("PlaceMyBet.Models.Cuenta", "UsuarioId");
                });

            modelBuilder.Entity("PlaceMyBet.Models.Mercado", b =>
                {
                    b.HasOne("PlaceMyBet.Models.Evento", "Evento")
                        .WithMany("Mercados")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
