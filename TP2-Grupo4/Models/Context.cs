using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TP2_Grupo4.Helpers;

namespace TP2_Grupo4.Models
{
    class Context : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Alojamiento> Alojamientos { get; set; }
        public Context() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(Credenciales.GetConnectionString(), new MySqlServerVersion(new Version(8, 0, 11)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(usuario =>
            {
                usuario.Property(u => u.Nombre).HasColumnType("varchar(80)").IsRequired(true);
                usuario.Property(u => u.Dni).HasColumnType("int").IsRequired(true);
                usuario.HasIndex(u => u.Dni).IsUnique();
                usuario.Property(u => u.Email).HasColumnType("varchar(30)").IsRequired(true);
                usuario.HasIndex(u => u.Email).IsUnique();
                usuario.Property(u => u.Password).HasColumnType("varchar(200)").IsRequired(true);
            });
            modelBuilder.Entity<Alojamiento>(alojamiento =>
            {
                alojamiento.Property(a => a.Codigo).HasColumnType("varchar(50)").IsRequired(true);
                alojamiento.HasIndex(a => a.Codigo).IsUnique();
                alojamiento.Property(a => a.Ciudad).HasColumnType("varchar(50)").IsRequired(true);
                alojamiento.Property(a => a.Barrio).HasColumnType("varchar(50)").IsRequired(true);
                //alojamiento.Property(a => a.CantidadDePersonas).HasColumnType("int").IsRequired(true);
                //alojamiento.Property(a => a.Tv).HasColumnType("tinyint").IsRequired(true);
                alojamiento.Property(a => a.Tipo).HasColumnType("varchar(10)").IsRequired(true);
                /*alojamiento.Property(a => a.PrecioPorPersona).HasColumnType("double");
                alojamiento.Property(a => a.PrecioPorDia).HasColumnType("double");
                alojamiento.Property(a => a.Habitaciones).HasColumnType("int");
                alojamiento.Property(a => a.Banios).HasColumnType("int");*/
            });
            modelBuilder.Entity<Reserva>(reserva =>
            {
                reserva.Property(r => r.FechaDesde).HasColumnType("date").IsRequired(true);
                reserva.Property(r => r.FechaHasta).HasColumnType("date").IsRequired(true);
            });

            modelBuilder.Entity<Usuario>().HasData(new Usuario[]{
                new Usuario{Id=1, Dni = 11111111, Nombre = "admin", Email = "admin@admin.com", Password = Utils.Encriptar("1234"), IsAdmin=true, Bloqueado=false},
                new Usuario{Id=2, Dni = 12312312, Nombre = "prueba1", Email = "prueba1@gmail.com", Password = Utils.Encriptar("1234"), IsAdmin=false, Bloqueado=false},
            }); ;
            modelBuilder.Entity<Alojamiento>().HasData(new Alojamiento[] {
                new Alojamiento{
                    Id=1,
                    Codigo="123456",
                    Ciudad="Buenos Aires",
                    Barrio="Recoleta",
                    Estrellas=3,
                    Tv = true,
                    Tipo="hotel" ,
                    CantidadDePersonas=2,
                    PrecioPorPersona=2400
                },
                new Alojamiento{
                    Id=2,
                    Codigo="111111",
                    Ciudad="Neuquen",
                    Barrio="Sur",
                    Estrellas=4,
                    Tv = true,
                    Tipo="cabaña" ,
                    CantidadDePersonas=2,
                    PrecioPorPersona=2400,
                    PrecioPorDia = 1200,
                    Habitaciones = 4,
                    Banios = 2
                },
            });

        }

    }
}
