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
		public DbSet<Hotel> Hotel { get; set; }
		public DbSet<Cabania> Cabania { get; set; }
		public DbSet<Reserva> Reservas { get; set; }
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
				reserva.Property(r => (r.alojamiento).ToString()).HasColumnType("varchar(50)").IsRequired(true);
				reserva.Property(r => (r.usuario).ToString()).HasColumnType("varchar(50)").IsRequired(true);
				reserva.Property(r => r.precio).HasColumnType("int").IsRequired(true);
			});

			modelBuilder.Entity<Hotel>(hotel =>
			{
				hotel.Property(h => h.codigo).HasColumnType("int").IsRequired(true);
				hotel.HasIndex(h => h.codigo).IsUnique();

				hotel.Property(h => h.ciudad).HasColumnType("varchar(50)").IsRequired(true);
				hotel.Property(h => h.barrio).HasColumnType("varchar(50)").IsRequired(true);
				hotel.Property(h => h.estrellas).HasColumnType("int").IsRequired(true);
				hotel.Property(h => h.cantidadDePersonas).HasColumnType("int").IsRequired(true);
				hotel.Property(h => h.tv).HasColumnType("bit").IsRequired(true);
				hotel.Property(h => h.precioPorPersona).HasColumnType("double").IsRequired(true);
			});
			modelBuilder.Entity<Cabania>(cabania =>
			{
				cabania.Property(c => c.codigo).HasColumnType("int").IsRequired(true);
				cabania.HasIndex(c => c.codigo).IsUnique();

				cabania.Property(c => c.ciudad).HasColumnType("varchar(50)").IsRequired(true);
				cabania.Property(c => c.barrio).HasColumnType("varchar(50)").IsRequired(true);
				cabania.Property(c => c.estrellas).HasColumnType("int").IsRequired(true);
				cabania.Property(c => c.cantidadDePersonas).HasColumnType("int").IsRequired(true);
				cabania.Property(c => c.tv).HasColumnType("bit").IsRequired(true);
				cabania.Property(c => c.precioPorDia).HasColumnType("double").IsRequired(true);
				cabania.Property(c => c.habitaciones).HasColumnType("int").IsRequired(true);
				cabania.Property(c => c.banios).HasColumnType("int").IsRequired(true);
			});

			//    modelBuilder.Entity<Usuario>().HasData(new Usuario[]{
			//        new Usuario { Dni=1234, Nombre="Pedro", Email="pedro@gmail.com", Password="1234", IsAdmin=true, Bloqueado=false },
			//  });

			//
		}
    }
}
