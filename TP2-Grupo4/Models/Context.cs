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
            });
        }
    }
}
