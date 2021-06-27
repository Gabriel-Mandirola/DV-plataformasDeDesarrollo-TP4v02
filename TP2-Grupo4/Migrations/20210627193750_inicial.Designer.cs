﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TP2_Grupo4.Models;

namespace TP2_Grupo4.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210627193750_inicial")]
    partial class inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("TP2_Grupo4.Models.Alojamiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Banios")
                        .HasColumnType("int");

                    b.Property<string>("Barrio")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("CantidadDePersonas")
                        .HasColumnType("int");

                    b.Property<string>("Ciudad")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Estrellas")
                        .HasColumnType("int");

                    b.Property<int>("Habitaciones")
                        .HasColumnType("int");

                    b.Property<double>("PrecioPorDia")
                        .HasColumnType("double");

                    b.Property<double>("PrecioPorPersona")
                        .HasColumnType("double");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<bool>("Tv")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("Codigo")
                        .IsUnique();

                    b.ToTable("Alojamientos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Banios = 0,
                            Barrio = "Recoleta",
                            CantidadDePersonas = 2,
                            Ciudad = "Buenos Aires",
                            Codigo = "123456",
                            Estrellas = 3,
                            Habitaciones = 0,
                            PrecioPorDia = 0.0,
                            PrecioPorPersona = 2400.0,
                            Tipo = "hotel",
                            Tv = true
                        });
                });

            modelBuilder.Entity("TP2_Grupo4.Models.Reserva", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("AlojamientoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaDesde")
                        .HasColumnType("date");

                    b.Property<DateTime>("FechaHasta")
                        .HasColumnType("date");

                    b.Property<double>("Precio")
                        .HasColumnType("double");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlojamientoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("TP2_Grupo4.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Bloqueado")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Dni")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("Dni")
                        .IsUnique();

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Bloqueado = false,
                            Dni = 11111111,
                            Email = "admin@admin.com",
                            IsAdmin = true,
                            Nombre = "admin",
                            Password = "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4"
                        },
                        new
                        {
                            Id = 2,
                            Bloqueado = false,
                            Dni = 12312312,
                            Email = "prueba1@gmail.com",
                            IsAdmin = false,
                            Nombre = "prueba1",
                            Password = "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4"
                        });
                });

            modelBuilder.Entity("TP2_Grupo4.Models.Reserva", b =>
                {
                    b.HasOne("TP2_Grupo4.Models.Alojamiento", "Alojamiento")
                        .WithMany()
                        .HasForeignKey("AlojamientoId");

                    b.HasOne("TP2_Grupo4.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Alojamiento");

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
