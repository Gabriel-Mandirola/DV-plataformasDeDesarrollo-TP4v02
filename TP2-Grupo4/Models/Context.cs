using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;

namespace TP2_Grupo4.Models
{
    class Context : DbContext
    {
		public DbSet<Usuario> Usuarios { get; set; }
		public DbSet<Reserva> Reservas { get; set; }
		public DbSet<Alojamiento> Alojamientos { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;user=root;database=inicio-proyecto;port=3306;password=", new MySqlServerVersion(new Version(8, 0, 11)));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(usuario =>
            {
                usuario.Property(u => u.Nombre).HasColumnType("varchar(80)").IsRequired(true);

                usuario.Property(u => u.Dni).HasColumnType("varchar(10)").IsRequired(true);
                usuario.HasIndex(u => u.Dni).IsUnique();

                usuario.Property(u => u.Email).HasColumnType("varchar(30)").IsRequired(true);
                usuario.HasIndex(u => u.Email).IsUnique();
                usuario.Property(u => u.Password).HasColumnType("varchar(200)").IsRequired(true);
				usuario.Property(u => u.IsAdmin).HasColumnType("bit").IsRequired(true);
				usuario.Property(u => u.Bloqueado).HasColumnType("bit").IsRequired(true);
			});

			modelBuilder.Entity<Reserva>(reserva =>
			{
				reserva.Property(r => r.id).HasColumnType("varchar(20)").IsRequired(true);
				reserva.HasIndex(r => r.id).IsUnique();

				reserva.Property(r => r.fechaDesde).HasColumnType("date").IsRequired(true);
				reserva.Property(r => r.fechaHasta).HasColumnType("date").IsRequired(true);
				reserva.Property(r => r.hotel).IsRequired(false);
				reserva.Property(r => r.cabania).IsRequired(false);
				reserva.Property(r => r.usuario).IsRequired(true);
				reserva.Property(r => r.precio).HasColumnType("int").IsRequired(true);
			});

			modelBuilder.Entity<Alojamiento>(alojamiento =>
			{
				alojamiento.Property(a => a.codigo).HasColumnType("int").IsRequired(true);
				alojamiento.HasIndex(a => a.codigo).IsUnique();

				alojamiento.Property(a => a.ciudad).HasColumnType("varchar(50)").IsRequired(true);
				alojamiento.Property(a => a.barrio).HasColumnType("varchar(50)").IsRequired(true);
				alojamiento.Property(a => a.estrellas).HasColumnType("int").IsRequired(true);
				alojamiento.Property(a => a.cantidadDePersonas).HasColumnType("int").IsRequired(true);
				alojamiento.Property(a => a.tv).HasColumnType("bit").IsRequired(true);
				alojamiento.Property(a => a.precioPorPersona).HasColumnType("double").IsRequired(true);
				alojamiento.Property(a => a.precioPorDia).HasColumnType("double").IsRequired(true);
				alojamiento.Property(a => a.habitaciones).HasColumnType("int").IsRequired(true);
				alojamiento.Property(a => a.banios).HasColumnType("int").IsRequired(true);
			});

			//    modelBuilder.Entity<Usuario>().HasData(new Usuario[]{
			//        new Usuario { Dni=1234, Nombre="Pedro", Email="pedro@gmail.com", Password="1234", IsAdmin=true, Bloqueado=false },
			//  });

			//
		}
    }
}
