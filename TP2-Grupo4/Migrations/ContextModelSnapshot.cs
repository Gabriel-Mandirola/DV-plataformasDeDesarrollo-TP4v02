﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TP2_Grupo4.Models;

namespace TP2_Grupo4.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("TP2_Grupo4.Models.Alojamiento", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("banios")
                        .HasColumnType("int");

                    b.Property<string>("barrio")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("cantidadDePersonas")
                        .HasColumnType("int");

                    b.Property<string>("ciudad")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("codigo")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("estrellas")
                        .HasColumnType("int");

                    b.Property<int>("habitaciones")
                        .HasColumnType("int");

                    b.Property<double>("precioPorDia")
                        .HasColumnType("double");

                    b.Property<double>("precioPorPersona")
                        .HasColumnType("double");

                    b.Property<string>("tipo")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<ulong>("tv")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("codigo")
                        .IsUnique();

                    b.ToTable("Alojamientos");
                });

            modelBuilder.Entity("TP2_Grupo4.Models.Reserva", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("alojamientoid")
                        .HasColumnType("int");

                    b.Property<DateTime>("fechaDesde")
                        .HasColumnType("date");

                    b.Property<DateTime>("fechaHasta")
                        .HasColumnType("date");

                    b.Property<int>("precio")
                        .HasColumnType("int");

                    b.Property<int?>("usuarioId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("alojamientoid");

                    b.HasIndex("id")
                        .IsUnique();

                    b.HasIndex("usuarioId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("TP2_Grupo4.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<ulong>("Bloqueado")
                        .HasColumnType("bit");

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<ulong>("IsAdmin")
                        .HasColumnType("bit");

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
                });

            modelBuilder.Entity("TP2_Grupo4.Models.Reserva", b =>
                {
                    b.HasOne("TP2_Grupo4.Models.Alojamiento", "alojamiento")
                        .WithMany()
                        .HasForeignKey("alojamientoid");

                    b.HasOne("TP2_Grupo4.Models.Usuario", "usuario")
                        .WithMany()
                        .HasForeignKey("usuarioId");

                    b.Navigation("alojamiento");

                    b.Navigation("usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
